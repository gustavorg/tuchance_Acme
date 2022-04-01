using System;
using System.Collections.Generic;
using System.Data;
using TuChance.Library;
using TuChance.Entities;
using TuChance.Models;
using Microsoft.Extensions.Options;
using TuChance.Helpers;
using System.Data.SqlClient;
using TuChance.Dtos;

namespace TuChance.Data
{
    public class AuthenticateData : MsSqlExtensions
	{
        public AuthenticateData(IOptions<AppSettings> appSettings) : base(appSettings)
        {

        }

		public UserDto GetByEmail(AuthenticateRequest model)
		{
			UserDto rtn = null;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pemail", Value = model.Email, DbType = DbType.String}
			};

			DataTable dt = base.ExecuteDataTable("usp_user_s_email", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				rtn = new UserDto
				{
					Id = Int32.Parse(dr["id"].ToString()),
					Name = dr["name"].ToString(),
					LastName = dr["lastName"].ToString(),
					Email = dr["email"].ToString(),
					Role = dr["role"].ToString()
				};
			}

			return rtn;
		}

		public bool Register(RegisterRequest model)
		{
			bool rtn = false;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pemail", Value = model.Email},
				new SqlParameter{ ParameterName= "@pname", Value = model.Names},
				new SqlParameter{ ParameterName= "@plastname", Value = model.LastName},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_user_i_client", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = Convert.ToBoolean(outputs[0].Value);
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
					Role = dr["role"].ToString()
				};
			}
			return rtn;
		}

		public bool SaveToken(int idUser, string token)
		{
			bool rtn = false;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pidUser", Value = idUser},
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
