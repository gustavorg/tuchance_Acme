using System.Collections.Generic;
using System.Data;
using TuChance.Library;
using TuChance.Entities;
using TuChance.Helpers;
using Microsoft.Extensions.Options;
using TuChance.Dtos;
using System;
using System.Data.SqlClient;
using TuChance.Payloads;
using Newtonsoft.Json;

namespace TuChance.Data
{
    public class SurveyData : MsSqlExtensions
	{
		public SurveyData(IOptions<AppSettings> appSettings) : base(appSettings)
        {
		}
		public List<GetSurveyDto> All()
		{
			List<GetSurveyDto> rtn = new();

			DataTable dt = ExecuteDataTable("usp_survey_s_surveys", null);

			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					rtn.Add(new GetSurveyDto
					{
						Id = int.Parse(dr["id"].ToString()),
						Name = dr["name"].ToString(),
						Description = dr["description"].ToString(),
						Token = dr["token"].ToString(),
						Questions = ConvertJsonToListQuestion(dr["question"].ToString()),
						Users = AllSurveyUsers(int.Parse(dr["id"].ToString())),
						CreatedAt = Convert.ToDateTime(dr["createdAt"].ToString()),
						UpdatedAt = Convert.ToDateTime(dr["updatedAt"].ToString())
					});
				}
			}
			return rtn;
		}

		public List<SurveyUserDto> AllSurveyUsers(int idSurvey)
		{
			List<SurveyUserDto> rtn = new();
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pid", Value = idSurvey}
			};

			DataTable dt = ExecuteDataTable("usp_survey_s_user", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					rtn.Add(new SurveyUserDto
					{
						IdSurvey = idSurvey,
						IdUser = Convert.ToInt32(dr["idUser"].ToString()),
						Answers = ConvertJsonToListAnswer(dr["answerQuestion"].ToString())
					});
				}
			}
			return rtn;
		}

		public SurveyTokenDto GetSurveyByToken(string token)
        {
			SurveyTokenDto rtn = null;
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@ptoken", Value = token}
			};

			DataTable dt = ExecuteDataTable("usp_survey_s_token", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				rtn = new SurveyTokenDto
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Name = dr["name"].ToString(),
					Description = dr["description"].ToString(),
					Questions = ConvertJsonToListQuestion(dr["question"].ToString()),
				};
			}
			return rtn;
		}

		public SurveyDto Get(int id)
		{
			SurveyDto rtn = null;
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pid", Value = id}
			};

			DataTable dt = ExecuteDataTable("usp_survey_s_survey", parameters);

			if (dt != null && dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				rtn = new SurveyDto
				{
					Id = Convert.ToInt32(dr["id"].ToString()),
					Name = dr["name"].ToString(),
					Description = dr["description"].ToString(),
					Questions = ConvertJsonToListQuestion(dr["question"].ToString()),
				};
			}
			return rtn;
		}

		public SurveyDto CreateSurvey(CreateSurveyPayload payload, string token)
		{
			SurveyDto rtn = null;
			DateTime datetime = DateTime.UtcNow;
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pname", Value = payload.Name},
				new SqlParameter{ ParameterName= "@pdescription", Value = payload.Description},
				new SqlParameter{ ParameterName= "@ptoken", Value = token},
				new SqlParameter{ ParameterName= "@pquestion", Value = ConvertListQuestionToJson(payload.Questions)},
				new SqlParameter{ ParameterName= "@pdate", Value = datetime},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_survey_i_survey", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = new SurveyDto
				{
					Id = Convert.ToInt32(outputs[0].Value),
					Name = payload.Name,
					Description = payload.Description,
					Token = token,
					Questions = payload.Questions,
					CreatedAt = datetime,
					UpdatedAt = datetime
				};
			}

			return rtn;
		}

		public SurveyUserDto SaveAnswerSurvey(SurveyUserPayload payload, int idUser)
		{
			SurveyUserDto rtn = null;
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pidsurvey", Value = payload.IdSurvey},
				new SqlParameter{ ParameterName= "@piduser", Value = idUser},
				new SqlParameter{ ParameterName= "@answerquestion", Value = ConvertListAnswerToJson(payload.Answers)},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_user_i_survey", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = new SurveyUserDto
				{
					IdUser = idUser,
					IdSurvey = payload.IdSurvey,
					Answers = payload.Answers
				};
			}

			return rtn;
		}

		public SurveyDto UpdateSurvey(UpdateSurveyPayload payload)
		{
			SurveyDto rtn = null;
			DateTime datetime = DateTime.UtcNow;
			SqlParameter[] parameters = {
				new SqlParameter{ ParameterName= "@pid", Value = payload.Id},
				new SqlParameter{ ParameterName= "@pname", Value = payload.Name},
				new SqlParameter{ ParameterName= "@pdescription", Value = payload.Description},
				new SqlParameter{ ParameterName= "@pquestion", Value = ConvertListQuestionToJson(payload.Questions)},
				new SqlParameter{ ParameterName= "@pdate", Value = datetime},
				new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
			};

			SqlParameter[] outputs = base.ExecuteNonQuery("usp_survey_u_survey", parameters);

			if (outputs != null && outputs.Length > 0)
			{
				rtn = new SurveyDto
				{
					Id = payload.Id,
					Name = payload.Name,
					Description = payload.Description,
					Questions = payload.Questions,
					CreatedAt = datetime,
					UpdatedAt = datetime
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

		private String ConvertListQuestionToJson(List<QuestionDto> questions)
		{
			return JsonConvert.SerializeObject(questions);
		}

		private String ConvertListAnswerToJson(List<AnswerPayload> questions)
		{
			return JsonConvert.SerializeObject(questions);
		}

		private List<QuestionDto> ConvertJsonToListQuestion(string json)
		{
			return JsonConvert.DeserializeObject<List<QuestionDto>>(json);
		}

		private List<AnswerPayload> ConvertJsonToListAnswer(string json)
		{
			return JsonConvert.DeserializeObject<List<AnswerPayload>>(json);
		}
	}
}
