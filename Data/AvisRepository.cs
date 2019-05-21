using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AvisRepository
    {
      

        public void InsertAvis(Avis avis)
        {
            using(var Context = new AvisFormationDbEntities())
            {
                Context.Avis.Add(avis);
                Context.SaveChanges();
            }
        }
        public List<Avis> GetAvisOfFormation( int IdFormation)
        {
            using (var Context = new AvisFormationDbEntities())
            {
                return Context.Avis.Where(a => a.IdFormation == IdFormation).ToList();
            }

            }
    }
}
