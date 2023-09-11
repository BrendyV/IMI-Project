using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Imi.Project.Mobile.Domain.Models;

namespace Imi.Project.Mobile.Domain.Dtos
{
    public class AnimalDto
    {
        public Guid Id { get; set; }
        public string NameDutch { get; set; }
        public string NameFamily { get; set; }
        public Uri Image { get; set; }



    }
}