using Astana.BLL.ModelAccount;
using Astana.BLL.ModelClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astana.BLL
{
    public class ServiceAccount
    {
        private Random rndAccount = new Random();
        public bool CreateAccount(out string message, ref Client client)
        {
            Account account = new Account();
            account.AccountType = AccountType.loan;
            account.Balance = 0;
            account.currency = currency.KZT;
            account.No_Account = string.Format("{0}{1}", account.currency.ToString(), rndAccount.Next());

            client.accounts.Add(account);

            if (rndAccount.Next(1, 10) % 2 == 0)
            {
                message = "ok";
                return true;
            }
            else
            {
                throw new Exception(message: "Error create account");
            }
        }

        public bool SetBalance(out string message, ref Client client, string No_Account, double sum)
        {
            Account account = client.accounts.FirstOrDefault(f => f.No_Account == No_Account);
            if (account != null)
            {
                account.Balance += sum;
                message = "Счет пополнен корректно.";
                return true;
            }
            else
            {
                message = "ошибка пополнения";
                return false;
            }
        }
    }
}
