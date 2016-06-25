using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            using (TouchContext db = new TouchContext())
            {
                var result = new ContactViewModel() { ContactUs = db.ContactUs.FirstOrDefault() };
                return View(result);
            }
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel input)
        {
            using (TouchContext db = new TouchContext())
            {
                input.Message.SendDate = DateTime.Now;
                input.Message.IsRead = false;
                db.ContactUsMessages.Add(input.Message);
                db.SaveChanges();
            }
            return View();
        }
    }
}