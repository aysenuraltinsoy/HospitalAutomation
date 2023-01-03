using Hastane.Business.Models.DTOs;
using Hastane.Business.Services.AdminService;
using Hastane.Core.Enums;
using Hastane.DataAccess.Abstract;
using Hastane.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NRM1_HastaneOtomasyon.Models;


namespace NRM1_HastaneOtomasyon.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {     
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService=adminService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //    public IActionResult ShowAdminInfo()
        //    {
        //        var bilgi = HttpContext.Session.GetString("adminSession");
        //        var adminInfo = JsonConvert.DeserializeObject<Admin>(bilgi);
        //        return View(adminInfo);
        //    }

        public IActionResult AddManager()
        {
            return View(); //Burası yönetici ekleme sayfasını açacak olan HttpGet!!
        }

        [HttpPost]
        public async Task<IActionResult> AddManager(AddManagerDTO addManagerDTO)
        {
            
            if (ModelState.IsValid)
            {
                await _adminService.AddManager(addManagerDTO);
                return RedirectToAction("ListOfManagers");
            }

            return View(addManagerDTO);
        }

        public async Task<IActionResult> ListOfManagers()
        {
            var managerList = await _adminService.ListOfManager();
            return View(managerList);

        }



        //Güncelleme

        [HttpGet]
        public async Task<IActionResult> UpdatedPersonel(Guid id)
        {
            ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Roles)), Roles.Personel);
            return View(await _adminService.EmployeeGetByID(id));
        }



        [HttpPost]
        public async Task<IActionResult> UpdatedPersonel(Employee employee)
        {
            await _adminService.UpdateEmployee(employee);
            
            return RedirectToAction("ListOfPersonel");
        }


        public async Task<IActionResult> DeletePersonel(Guid id)
        {
            await _adminService.DeleteEmployee(id);
            return RedirectToAction("ListOfPersonel");
        }

        [HttpGet]
        public IActionResult AddPersonel()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonel(AddPersonelDTO addPersonelDTO)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddPersonel(addPersonelDTO);
                return RedirectToAction("ListOfPersonel");
            }

            return View(addPersonelDTO); //Bunu yapmasanda hatalı veri girişi olursa sana tekrardan aynı sayfayı döner.Veriler sabit kalır ama biz işimizi garantiye aldık.

        }
        public async Task<IActionResult> ListOfPersonel()
        {
            var personelList = await _adminService.ListOfPersonel();
            return View(personelList);

        }

        //Burada kullanıcının tipinin Personel olup olmadığını kontrol ettik Personel olanları bir listede topladık. Bu listeyi return view derken parametre olarak verdik.
       

        //    //Burada TempData - ViewBag - ViewData kullanacağız
        //    public IActionResult ListOfPersonnels3()
        //    {
        //        List<Personnel> myPersonnels = new List<Personnel>();
        //        foreach (var item in HomeController._myUser)
        //        {
        //            if (item is Personnel)
        //            {
        //                myPersonnels.Add((Personnel)item);

        //            }
        //        }

        //        ViewBag.ourPersonnels = myPersonnels;
        //        ViewData["ourPersonnels2"] = myPersonnels;


        //        //TempData veri ataması yaptığın zaman arka planda kendisi için bir çerez(cookie) oluşturur.Sen bu cookie sayesinde burada bulunan verileri başka bir View ekranında'da çağırabilirsin.!!!
        //        TempData["ourPersonnels3"] = myPersonnels;

        //        return View();
        //    }

        //    public IActionResult ShowUsAll()
        //    {
        //        PersonelManagerVM personelManagerVM = new PersonelManagerVM();

        //        List<Personnel> myPersonnels = new List<Personnel>();
        //        List<Manager> myManagers = new List<Manager>();
        //        foreach (var item in HomeController._myUser)
        //        {
        //            if (item is Personnel)
        //            {
        //                myPersonnels.Add((Personnel)item);

        //            }
        //            if(item is Manager)
        //            {
        //                myManagers.Add((Manager)item);  
        //            }
        //        }

        //        personelManagerVM.PersonnelList = myPersonnels;
        //        personelManagerVM.ManagerList = myManagers;

        //        return View(personelManagerVM);
        //    }

        //    public IActionResult ShowUsAll2()
        //    {

        //        List<Personnel> myPersonnels = new List<Personnel>();
        //        List<Manager> myManagers = new List<Manager>();
        //        foreach (var item in HomeController._myUser)
        //        {
        //            if (item is Personnel)
        //            {
        //                myPersonnels.Add((Personnel)item);

        //            }
        //            if (item is Manager)
        //            {
        //                myManagers.Add((Manager)item);
        //            }
        //        }

        //        ViewBag.ourManagers = myManagers;

        //        return View(myPersonnels);

        //        //@model --> myPersonnels
        //        //ViewBag.ourManageer --> myManagers 
        //    }




    }
}
