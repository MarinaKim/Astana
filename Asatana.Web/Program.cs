using Astana.BLL;
using Astana.BLL.ModelAccount;
using Astana.BLL.ModelClient;
using Astana.BLL.ModelClient.Astana.BLL.UserMenu;
using Astana.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asatana.Web
{
    class Program
    {
        private static Client client; //найти клиента и можно обращаться из других методов
        private static AstanaEntity db = new AstanaEntity();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();

            client = db.GetClients().FirstOrDefault(f => f.login == login && f.password == password);

            if (client != null)
            {
                Console.Clear();
                Console.WriteLine("Welcome, {0} ", client.fullname);
                Console.WriteLine("Choose: ");
                char ent;
                do
                {
                    ent = Console.ReadLine().ToLower()[0];
                    Menu.GetMenu();
                    switch (ent)
                    {
                        case 'a':
                            {
                                string message = "";
                                ServiceAccount sa = new ServiceAccount();
                                try
                                {
                                    sa.CreateAccount(out message, ref client);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Account create correct");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(ex.Message);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                            break;

                        case 'b':
                            {
                                foreach (Account item in client.accounts)
                                {
                                    Console.WriteLine("{0}\t{1} {0}", item.No_Account, item.Balance, item.currency);
                                }

                            }
                            break;

                        case 'c':
                            {
                                string mess = "";
                                string acc = "";
                                double sum = 0;
                                ServiceAccount sa = new ServiceAccount();

                                Console.WriteLine("Введите номер счета: ");
                                acc = Console.ReadLine();
                                Console.WriteLine("Введите сумму: ");
                                sum = double.Parse(Console.ReadLine());

                                sa.SetBalance(out mess, ref client, acc, sum);
                            }
                            break;
                    }
                    Console.ReadLine();
                    Console.Clear();
                } while (ent != 'e');
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect login or password. Try again.");
            }

        }
    }
}
