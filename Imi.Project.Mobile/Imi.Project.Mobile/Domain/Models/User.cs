using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool PrivacyConsent { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        public bool TermsAndConditions { get; set; }
    }
}
