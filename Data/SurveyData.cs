using System.Collections.Generic;
using System.Data;
using TuChance.Library;
using TuChance.Entities;
using TuChance.Helpers;
using Microsoft.Extensions.Options;
using TuChance.Models;
using System;
using System.Data.SqlClient;
using TuChance.Payloads;

namespace TuChance.Data
{
    public class SurveyData : MsSqlExtensions
	{
        public SurveyData(IOptions<AppSettings> appSettings) : base(appSettings)
        {

        }
		public List<SurveyDto> All()
		{
			List<SurveyDto> rtn = new();

			DataTable dt = ExecuteDataTable("usp_survey_s_survey", null);

			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					rtn.Add(new SurveyDto
					{
						Id = int.Parse(dr["id"].ToString()),
						Name = dr["name"].ToString(),
						Description = dr["description"].ToString(),
						Token = dr["token"].ToString(),
						CreatedAt = Convert.ToDateTime(dr["createdAt"].ToString()),
						UpdatedAt = Convert.ToDateTime(dr["updatedAt"].ToString())
					});
				}
			}
			return rtn;
		}

		public SurveyDto CreateSurvey(CreateSurveyPayload payload)
		{
			SurveyDto rtn = null;

			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pname", Value = payload.Name},
				new SqlParameter{ ParameterName= "@pdescription", Value = payload.Description},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			DataTable dt = base.ExecuteDataTable("usp_survey_i_survey", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				rtn = new SurveyDto
				{
					Id = int.Parse(dr["id"].ToString()),
					Name = dr["name"].ToString(),
					Description = dr["description"].ToString(),
					Token = dr["token"].ToString(),
					CreatedAt = Convert.ToDateTime(dr["createdAt"].ToString()),
					UpdatedAt = Convert.ToDateTime(dr["updatedAt"].ToString())
				};
			}

			return rtn;
		}

		public SurveyDto UpdateSurvey(UpdateSurveyPayload payload)
		{
			SurveyDto rtn = null;
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pid", Value = payload.Id},
				new SqlParameter{ ParameterName= "@pname", Value = payload.Name},
				new SqlParameter{ ParameterName= "@pdescription", Value = payload.Description},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			DataTable dt = base.ExecuteDataTable("usp_survey_u_survey", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				rtn = new SurveyDto
				{
					Id = int.Parse(dr["id"].ToString()),
					Name = dr["name"].ToString(),
					Description = dr["description"].ToString(),
					Token = dr["token"].ToString(),
					CreatedAt = Convert.ToDateTime(dr["createdAt"].ToString()),
					UpdatedAt = Convert.ToDateTime(dr["updatedAt"].ToString())
				};
			}

			return rtn;
		}

		public bool DeleteSurvey(DeleteSurveyPayload payload)
		{
			bool rtn = false;
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pid", Value = payload.Id},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_survey_d_survey", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = Convert.ToBoolean(outputs[0].Value);
			}
			return rtn;
		}
	}
}
