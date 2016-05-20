using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockAppsSDK.Users
{
    public class Account
    {
        //Properties
        public string ContractRoot { get; set; }

        public string Kind { get; set; }

        public string Balance { get; set; }

        public string Addres { get; set; }

        public string LatestBlockNum { get; set; }

        public string LatestBlockId { get; set; }

        //Methods
        public bool Send(uint value)
        {
            throw new NotImplementedException();
        }

        //Static Methods
        public static Account GetAccount(string address)
        {
            throw new NotImplementedException();
        } 

        public static List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public static List<string> GetAccountAddresses()
        {
            throw new NotImplementedException();
        }

        public static Account CreateAccount(string name)
        {
            throw new NotImplementedException();
        }
    }
}
