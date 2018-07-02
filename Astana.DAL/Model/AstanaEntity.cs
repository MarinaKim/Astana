using Astana.BLL.ModelClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astana.DAL.Model
{
    public class AstanaEntity
    {
        public List<Client> GetClients()
        {
            List<Client> clients=new List<Client>();

            Client client1 = new Client();
            client1.login = "admin";
            client1.password = "admin";
            clients.Add(client1);

            Client client2 = new Client() { login = "user", password = "user" };
            clients.Add(client2);

            Client client3 = new Client("user2", "user2");
            clients.Add(client3);

            return clients;
        }
    }
}
