using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Concept
{
    public class QuestionService : IQuestionItemService
    {
        private static readonly List<QuestionItem> _questions = new List<QuestionItem>
        {
            new QuestionItem
            {
                ImagePath = "images/vis1.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 0,
                Score = 1
            },
            new QuestionItem
            {
                ImagePath = "images/vis11.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 2,
                Score = 1
            },
            new QuestionItem
            {
                ImagePath = "images/vis12.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 2,
                Score = 1
            },
            new QuestionItem
            {
                ImagePath = "images/vis4.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 0,
                Score = 1
            },
            new QuestionItem
            {
                ImagePath = "images/vis6.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 1,
                Score = 1
            },
            new QuestionItem
            {
                ImagePath = "images/vis2.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 0,
                Score = 1
            },
            new QuestionItem
            {
                ImagePath = "images/vis8.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 1,
                Score = 1
            },
            new QuestionItem
            {
                ImagePath = "images/vis9.png",
                Question = "In welk soort water leeft deze vis?",
                Answers = new List<string> { "Zoetwater", "Zouwater", "Beiden", "Nergens" },
                CorrectAnswerIndex = 1,
                Score = 1
            }
        };
        
        public Task<List<QuestionItem>> GetAllAsync()
        {
            return Task.FromResult(_questions);
        }
    }
}