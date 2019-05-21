using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MessageRepository
    {
        public void InsertMessage(MessageDb message)
        {
            using (var Context = new AvisFormationDbEntities())
            {
                Context.MessageDb.Add(message);
                Context.SaveChanges();
            }
        }
    }
}
