using System;
using System.Data;
using TuChance.Library;
using Microsoft.Extensions.Options;
using TuChance.Helpers;
using System.Data.SqlClient;
using TuChance.Dtos;
using TuChance.Payloads;
using System.Collections.Generic;

namespace TuChance.Data
{
    public class QuestionData : MsSqlExtensions
	{
        public QuestionData(IOptions<AppSettings> appSettings) : base(appSettings)
        {

        }

		public List<QuestionTypeDto> GetQuestionTypes()
		{
			List<QuestionTypeDto> rtn = new();
			DataTable dt = ExecuteDataTable("usp_question_s_types", null);

			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					rtn.Add(new QuestionTypeDto
					{
						Id = int.Parse(dr["id"].ToString()),
						Name = dr["name"].ToString()
					});
				}
			}
			return rtn;
		}
	}
}
