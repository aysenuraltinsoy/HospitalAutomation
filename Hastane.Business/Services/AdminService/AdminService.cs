using Hastane.Business.Models.DTOs;
using Hastane.Business.Models.VMs;
using Hastane.DataAccess.Abstract;
using Hastane.Entities.Abstract;
using Hastane.Entities.Concrete;
using Hastane.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Business.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public AdminService()
        {

        }
        public async Task AddManager(AddManagerDTO addManagerDTO)
        {
            Employee employee=new Employee();
            employee.Id= addManagerDTO.Id;
            employee.Salary= addManagerDTO.Salary;
            employee.Name= addManagerDTO.Name;
            employee.Surname= addManagerDTO.Surname;
            employee.CreatedTime = addManagerDTO.CreatedDate;
            employee.Status= addManagerDTO.Status;
            employee.EmailAddress= addManagerDTO.EmailAddress;
            employee.Password = GivePassword();
            await _employeeRepo.Add(employee);
            
        }

        public async Task<List<ListOfManagersVM>> ListOfManager()
        {
            var managers = await _employeeRepo.GetFilteredList(
                select : x=> new ListOfManagersVM
                {
                    Name=x.Name,
                    Surname=x.Surname,
                    EmailAddress=x.EmailAddress,
                    Salary=x.Salary
                },where: x=>x.Status==Status.Active,
                orderBy: x=>x.OrderBy(x=>x.Name));

            return managers;
        }

       
        private string GivePassword()
        {
            Random rastgele = new Random();
            string sifre = String.Empty;



            for (int i = 1; i <= 6; i++)
            {
                int sayi1 = rastgele.Next(65, 91);
                //65 dahil, 91 dahil değil A ile Z arasında
                sifre += (char)sayi1;
            }



            return sifre;
        }
    }
}
