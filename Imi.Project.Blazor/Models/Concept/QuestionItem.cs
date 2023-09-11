using System.Collections.Generic;

namespace Imi.Project.Blazor.Models.Concept
{
    public class QuestionItem
    {
        public string ImagePath { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public int Score { get; set; }
    }
}