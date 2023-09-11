using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Response
{
    public class LoginUserResponseDto
    {
        public string Token { get; set; }
        public string[] Roles { get; set; }
    }
}
