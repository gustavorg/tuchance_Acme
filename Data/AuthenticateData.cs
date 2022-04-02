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
    public class AuthenticateData : MsSqlExtensions
	{
        public AuthenticateData(IOptions<AppSettings> appSettings) : base(appSettings)
        {

        }

		public AuthenticateEmailDto GetByEmail(GetAuthenticatePayload payload)
		{
			AuthenticateEmailDto rtn = null;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pemail", Value = payload.Email, DbType = DbType.String}
			};

			DataTable dt = base.ExecuteDataTable("usp_user_s_email", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				rtn = new AuthenticateEmailDto
				{
					Id = Int32.Parse(dr["id"].ToString()),
					Password = dr["password"].ToString(),
					Role = dr["role"].ToString()
				};
			}

			return rtn;
		}

		public UserDto GetSeed(int idUser, string token)
		{
			UserDto rtn = null;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@piduser", Value = idUser},
				new SqlParameter{ ParameterName= "@ptoken", Value = token, DbType = DbType.String}
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
					IdRole = Int32.Parse(dr["idRole"].ToString())
				};
			}
			return rtn;
		}
		public bool SaveToken(int idUser, string token)
		{
			bool rtn = false;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pid", Value = idUser},
				new SqlParameter{ ParameterName= "@ptoken", Value = token},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_user_u_token", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = Convert.ToBoolean(outputs[0].Value);
			}

			return rtn;
		}
	}
}
