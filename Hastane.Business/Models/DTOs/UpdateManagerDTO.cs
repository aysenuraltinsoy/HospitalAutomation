using Hastane.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Business.Models.DTOs
{
    public class UpdateManagerDTO
    {
        public Guid Id { get; set; }
        public Roles? Roles { get; set; } 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? EmailAddress { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public string? IdentityNumber { get; set; }
    }
}
