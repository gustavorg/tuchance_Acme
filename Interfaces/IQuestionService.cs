using System.Collections.Generic;
using TuChance.Dtos;

namespace TuChance.Interfaces
{
   public interface IQuestionService
    {
        List<QuestionTypeDto> GetQuestionTypes();
    }
}
