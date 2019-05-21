using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class FormationRepository
    {
       
        public List<Formation> GetFormation()
        {
            using ( var Context = new AvisFormationDbEntities())
            {
                var result = Context.Formation.ToList();
                return result;

            }
        }
        public Formation GetFormationById( string nomSeo)
        {
            using (var Context = new AvisFormationDbEntities())
            {
                var result = Context.Formation.Include("Avis").FirstOrDefault(f=> f.NomSeo== nomSeo);
                return result;

            }

        }
        public List<Formation> GetRandomFormations()
        {
            using (var Context = new AvisFormationDbEntities())
            {
                //var random = new Random();
                return Context.Formation.OrderBy(f => Guid.NewGuid()).Take(5).ToList();
                //return Context.Formation.OrderBy(f => random.Next()).ToList();
            }


        }
    }
}