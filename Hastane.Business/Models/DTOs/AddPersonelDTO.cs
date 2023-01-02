﻿using Hastane.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Business.Models.DTOs
{
    public class AddPersonelDTO
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public Status Status { get; set; } = Status.Active;
        public decimal Salary { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Roles Roles { get; set; } = Roles.Personel;
    }
}
