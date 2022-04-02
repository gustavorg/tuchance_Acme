using System;
namespace TuChance.Dtos
{
    public class QuestionDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int IdQuestionType { get; set; }
        public bool IsRequired { get; set; }
    }
}
