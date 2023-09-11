using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class ApiLoginTokenAndRoles
    {
        public string Token { get; set; }
        public Guid Id { get; set; }
        public string[] Roles { get; set; }
    }
}
