using Data;
using AvisFormation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveMessage(SaveMessageViewModel comment)
        {
            var message = new MessageDb();
            var repository = new MessageRepository();
            message.nom = comment.Nom;
            message.email = comment.Email;
            message.Description = comment.Description;
            repository.InsertMessage(message);
            TempData["Message"] = "Votre message a bien été envoyé";
            return RedirectToAction("Index", "Contact");
        }
       
    }
}