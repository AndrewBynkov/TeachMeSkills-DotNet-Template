using System.Collections.Generic;
using TeachMeSkills.BusinessLogicLayer.Models;

namespace TeachMeSkills.WebApi.Contracts.Responses
{
    public class TodoAllResponse
    {
        public IEnumerable<TodoDto> Todos { get; set; }
    }
}
