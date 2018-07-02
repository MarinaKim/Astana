using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asatana.Web
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static List<Client> GetClients()
        {
            Astana.DAL.Model.AstanaEntity db = new Astana.DAL.Model.AstanaEntity();
            return db.GetClients();
        }
    }
}
