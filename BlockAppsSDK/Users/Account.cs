using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        public static async Task<Account> GetAccount(string address)
        {
            if (address == null || address.Equals(""))
            {
                throw new ArgumentException("Address is null or empty", nameof(address));
            }
            var accountResponse = await Utils.getRequest(BlockAppsSDK.StratoUrl );

            return JsonConvert.DeserializeObject<Account>(accountResponse);
        } 

        public static async Task<List<Account>> GetAccounts()
        {
            var addresses = await GetAccountAddresses();
            List<Task<string>> accountTasks = (from address in addresses
                select Utils.getRequest(BlockAppsSDK.StratoUrl + "account?address=")).ToList();
            List<string> accountJsonList = (await Task.WhenAll(accountTasks)).ToList();
           
            return accountJsonList.Select(x => JsonConvert.DeserializeObject<Account>(x)).ToList();
        }

        public static async Task<List<string>> GetAccountAddresses()
        {
            var res = await Utils.getRequest(BlockAppsSDK.BlocUrl + "users");
            return JsonConvert.DeserializeObject<List<string>>(res);
        }

        public static Task<Account> CreateAccount(string name)
        {
            if (name == null || name.Equals(""))
            {
                throw new ArgumentException("Address is null or empty", nameof(name));
            }


        }
    }
}
