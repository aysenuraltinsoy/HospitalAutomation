using Hastane.Core.Entities.Abstract;
using Hastane.Core.Enums;
using Hastane.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRM1_HastaneOtomasyon.Models.DTOs
{
    public class AddManagerDTO 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public Status Status { get; set; } = Status.Active;
        public decimal Salary { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
