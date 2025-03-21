using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Function.Interface
{
    public interface IATM
    {
        void CreateAccount(string username, string password, long accountNumber, string role, decimal minimumBlnc);

        double CheckBalance(string username);

        void WithdrawMoney(double withdrawamount, string username);

        void Deposite(double deposite_amount, string username);

        string AccountHolderisExist(string username, string password);

        string AccountHolderRole(string username);

        string AccountNumberisExist(long accountNumber);

        string UpdatePassword(string oldPassword);


    }
}
