using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astana.BLL.ModelAccount
{
    public enum currency { KZT, USD, EUR }
    public enum AccountType { loan, debit }
    public class Account
    {
        public string No_Account { get; set; }
        public currency currency { get; set; }
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }
        public List<Transaction> Transactions { get; set; }
    }

    public class Transaction
    {
        public DateTime dateTran { get; set; }
        public int NoTransaction { get; set; }
        public double SumTransaction { get; set; }
    }
}
