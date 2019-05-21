using AvisFormation.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult Index()
        {
            var repository = new FormationRepository();
            var liste = repository.GetRandomFormations();
            return View(liste);
        }
        public ActionResult ToutesLesFormations()
        {
            var repository = new FormationRepository();
            var formationVM = new ToutesLesFormationsVM();
            formationVM.ListeFormations  =repository.GetFormation();
            formationVM.City = "Lyon";

            return View(formationVM);
        }
        
        public ActionResult DetailFormation(string nomSeo )
        {
            var repository = new FormationRepository();
           
           var formation=repository.GetFormationById(nomSeo);
            if (formation == null)
            {
                return RedirectToAction("Index","Formation");
            }
            var moyenne =Math.Round(formation.Avis.Select(f => f.Note).DefaultIfEmpty(0).Average());
            var detailVM = new DetailFormationVM();
            detailVM.FormationInstance = formation;
            detailVM.moyenne = moyenne;

            return View(detailVM);
        }
    }
}