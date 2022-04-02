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

		public int CreateClient()
		{
			int rtn = 0;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_user_i_client", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = Convert.ToInt32(outputs[0].Value);
			}

			return rtn;
		}

		public UserDto CreateUser(CreateUserPayload payload)
		{
			UserDto rtn = null;
			DateTime datetime = DateTime.UtcNow;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pemail", Value = payload.Email},
				new SqlParameter{ ParameterName= "@pname", Value = payload.Name},
				new SqlParameter{ ParameterName= "@plastname", Value = payload.LastName},
				new SqlParameter{ ParameterName= "@pidrole", Value = payload.IdRole},
				new SqlParameter{ ParameterName= "@ppassword", Value = payload.Password},
				new SqlParameter{ ParameterName= "@pdate", Value = datetime},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_user_i_user", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				int id = Convert.ToInt32(outputs[0].Value);
                if (id > 0)
                {
					rtn = new UserDto()
					{
						Id = id,
						Email = payload.Email,
						IdRole = Convert.ToInt32(payload.IdRole),
						Name = payload.Name,
						LastName = payload.LastName,
						CreatedAt = datetime,
						UpdatedAt = datetime
					};
				}
			}

			return rtn;
		}

	}
}
