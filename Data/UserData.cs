using System;
using System.Data;
using TuChance.Library;
using Microsoft.Extensions.Options;
using TuChance.Helpers;
using System.Data.SqlClient;
using TuChance.Dtos;
using TuChance.Payloads;

namespace TuChance.Data
{
    public class UserData : MsSqlExtensions
	{
        public UserData(IOptions<AppSettings> appSettings) : base(appSettings)
        {

        }

		public UserDto Register(CreateUserPayload payload)
		{
			UserDto rtn = null;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pemail", Value = payload.Email},
				new SqlParameter{ ParameterName= "@pname", Value = payload.Name},
				new SqlParameter{ ParameterName= "@plastname", Value = payload.LastName},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_user_i_client", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = new UserDto()
				{
					Id = Convert.ToInt32(outputs[0].Value),
					Email = payload.Email,
					IdRole = 2,
					Name = payload.Name,
					LastName = payload.LastName
				};
			}

			return rtn;
		}

		public UserDto GetSeed(string token)
		{
			UserDto rtn = null;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pemail", Value = token, DbType = DbType.String}
			};

			DataTable dt = base.ExecuteDataTable("usp_user_s_token", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				rtn = new UserDto
				{
					Id = Int32.Parse(dr["id"].ToString()),
					Name = dr["name"].ToString(),
					LastName = dr["lastName"].ToString(),
					Email = dr["email"].ToString(),
					IdRole = Int32.Parse(dr["role"].ToString())
				};
			}
			return rtn;
		}

	}
}
