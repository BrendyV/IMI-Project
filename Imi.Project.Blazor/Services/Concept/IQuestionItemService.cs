using System.Collections.Generic;
using System.Threading.Tasks;
using Imi.Project.Blazor.Models.Concept;

namespace Imi.Project.Blazor.Services.Concept
{
    public interface IQuestionItemService
    {
        Task<List<QuestionItem>> GetAllAsync();
    }

}