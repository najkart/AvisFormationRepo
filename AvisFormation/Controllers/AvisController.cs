using AvisFormation.Models;
using Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        public ActionResult Index()
        {
        
            

          
                return View();
           
           
        }
        [Authorize]
        public ActionResult LaissezUnAvis(string nomSeo)
        {
            var idUser = User.Identity.GetUserId();
            var avisRepository = new AvisRepository();
            var liste = avisRepository.GetAvisByIdUser(idUser);
            return View(model:nomSeo);
        }
        [Authorize]
        public ActionResult SaveComment(SaveCommentViewModel saveCommentVM)
        {
           
            var avis = new Avis();
            var fRepository = new FormationRepository();
            var formation = fRepository.GetFormationById(saveCommentVM.NomSeo);
            avis.Id_users = User.Identity.GetUserId();//get userid from identity created by asp.net
            avis.Description = saveCommentVM.Description;
            if (float.TryParse(saveCommentVM.Note, NumberStyles.Any,CultureInfo.InvariantCulture,out float result))
            {
                avis.Note = result;
            }
            avis.IdFormation = formation.Id;
            avis.DateAvis = DateTime.Now;

            var avisRepository = new AvisRepository();
            avisRepository.InsertAvis(avis);
            TempData["Message"] = "Merci pour votre avis";
            return RedirectToAction("DetailFormation","Formation", new { nomSeo= saveCommentVM.NomSeo });
        }

    }
}