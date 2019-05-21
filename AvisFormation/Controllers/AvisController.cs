using Data;
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
            return View(model:nomSeo);
        }
        [Authorize]
        public ActionResult SaveComment(string nom, string description, string note, string nomSeo)
        {
            var avis = new Avis();
            var fRepository = new FormationRepository();
            var formation = fRepository.GetFormationById(nomSeo);
            avis.Nom = nom;
            avis.Description = description;
            if (float.TryParse(note,NumberStyles.Any,CultureInfo.InvariantCulture,out float result))
            {
                avis.Note = result;
            }
            avis.IdFormation = formation.Id;
            avis.DateAvis = DateTime.Now;

            var avisRepository = new AvisRepository();
            avisRepository.InsertAvis(avis);
            TempData["Message"] = "Merci pour votre avis";
            return RedirectToAction("DetailFormation","Formation", new { nomSeo= nomSeo });
        }

    }
}