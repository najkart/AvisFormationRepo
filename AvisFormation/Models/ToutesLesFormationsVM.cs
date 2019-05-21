using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisFormation.Models
{
    public class ToutesLesFormationsVM
    {
        public string City { get; set; }

        public List<Formation> ListeFormations { get; set; }
        public ToutesLesFormationsVM()
        {
            ListeFormations = new List<Formation>();
        }
        //public List<Formation> Get5RandomFormations()
        //{
        //    var repository = new FormationRepository();
        //    var liste = repository.GetFormation();
        //    var rand = new Random();
        //    rand.Next()


        //    return null;
        //}

    }
}