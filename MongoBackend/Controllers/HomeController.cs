using Microsoft.AspNetCore.Mvc;
using MongoBackend.Models;
using System.Diagnostics;

namespace MongoBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {



            return View();
        }

        public IActionResult NewUser()
        {


            return View();
        }

        [HttpPost]
        public IActionResult SaveUser(string txtname,
                                    string txtemail,
                                    Int32 txtphone,
                                    string txtadress
                                    )
        {
            DatabaseHelper.DataBase dbHelper = new DatabaseHelper.DataBase();



            dbHelper.InsertUser(new Users()
            {

                name = txtname,
                email = txtemail,
                phone = txtphone,
                adress = txtadress,
                dateIn = DateTime.Now
            });



            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult UpdateUsuario(string txtname,
                                    string txtemail,
                                    Int32 txtphone,
                                    string txtadress
                                    )
        {
            DatabaseHelper.DataBase dbHelper = new DatabaseHelper.DataBase();

     

            dbHelper.UpdateUser(new Users()
            {

                name = txtname,
                email = txtemail,
                phone = txtphone,
                adress = txtadress,
                dateIn = DateTime.Now
            });



            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListUsuarios()
        {

            DatabaseHelper.DataBase dbHelper = new DatabaseHelper.DataBase();
            ViewBag.userList = dbHelper.GetUsers();

            return View();
        }

        public IActionResult delete(String txtname)
        {

            DatabaseHelper.DataBase dbHelper = new DatabaseHelper.DataBase();

            dbHelper.DeleteUser(txtname);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}