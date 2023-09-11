using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public bool TermsAndConditions { get; set; }

    }
}
