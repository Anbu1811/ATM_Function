

using ATM_Function.Classes;
using ATM_Function.Interface;
using System;

public class ATMFunction
{
    private readonly IATM _atm;

    public ATMFunction(IATM atm)
    {
            _atm = atm;
    }

    public void CreateSavingAccount()
    {
        Console.WriteLine("Create Account Holder Name      : ");
        string username = Console.ReadLine();

        Console.WriteLine("Create Account Holder password  : ");
        string password = Console.ReadLine();

        Console.WriteLine("Create New Account Number       : ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());


        Console.WriteLine("Create Account Holder Role      : ");
        string role = Console.ReadLine();

        Console.WriteLine("Enter Initial Amount  : ");
        decimal initialBalance = Convert.ToDecimal(Console.ReadLine());


        _atm.CreateAccount(username,password,accountNumber,role,initialBalance);


    }

    public void BalanceChecking()
    {
        Console.WriteLine("Enter Account Number  : ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());


        //string exist_username = _atm.AccountHolderisExist(username, password);
        string exist_username = _atm.AccountNumberisExist(accountNumber);
        
        if (exist_username != null)
        {
            Console.WriteLine($"Account Holder Name : {exist_username}");
            Console.WriteLine($"Account Number      : {accountNumber}");

            double currentBalance = _atm.CheckBalance(exist_username);

            Console.WriteLine($"{exist_username} Account Balance is : {currentBalance}");
        }
        else
        {
            Console.WriteLine("This account number does not exist...");
        }
        


    }

    public void AmountDeposite()
    {
        Console.WriteLine("Enter Account Number  : ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());


        //string exist_username = _atm.AccountHolderisExist(username, password);
        string exist_username = _atm.AccountNumberisExist(accountNumber);

        if (exist_username != null)
        {
            Console.WriteLine($"Account Holder Name : {exist_username}");
            Console.WriteLine($"Account Number      : {accountNumber}");


            Console.WriteLine("Enter Deposite Amount  : ");
            double depositeAmount = Convert.ToDouble(Console.ReadLine());
            _atm.Deposite(depositeAmount,exist_username);
        }
        else
        {
            Console.WriteLine("This account number does not exist...");
        }

    }

    public void AmountWithDraw()
    {
        Console.WriteLine("Enter Account Number  : ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());


        //string exist_username = _atm.AccountHolderisExist(username, password);
        string exist_username = _atm.AccountNumberisExist(accountNumber);



        if (exist_username != null)
        {
            Console.WriteLine($"Account Holder Name : {exist_username}");
            Console.WriteLine($"Account Number      : {accountNumber}");


            Console.WriteLine("Enter Withdraw Amount  : ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());
            
            _atm.WithdrawMoney(withdrawAmount,exist_username);
        }
        else
        {
            Console.WriteLine("This account number does not exist...");
        }
    }

    public void BankFunction()
    {
        while (true)
        {
            Console.WriteLine("Enter your option  : 1.Create Account, 2.Deposite Amount, 3.Check Balance, 4.WithDraw, 5.Exit  ");
            
            int input = Convert.ToInt32(Console.ReadLine());

            switch(input)
            {
                case 1:
                    CreateSavingAccount();
                    break;
                case 2:
                    AmountDeposite();
                    break;
                case 3:
                    BalanceChecking();
                    break;
                case 4:
                    AmountWithDraw();
                    break;
                case 5:
                    Console.WriteLine("Thank You...");
                    break;
                default:
                    Console.WriteLine("Please Select Correct option..");
                    break;
            }

            if (input == 5)
            {
                break;
            }
        }
    }

    public void RoleBased()
    {
        Console.WriteLine("Enter Account Holder Name  : ");
        string username = Console.ReadLine();

        Console.WriteLine("Enter Your password        : ");
        string password = Console.ReadLine();

        string Exist_username = _atm.AccountHolderisExist(username, password);
        if (Exist_username != null)
        {
            string role =  _atm.AccountHolderRole(Exist_username);

            switch (role)
            {
                case "Manager":
                    Console.WriteLine($"Welcome ({role})  {Exist_username}...  ");
                    Role_Manager();
                    break;
                case "Cashier":
                    Console.WriteLine($"Welcome ({role})  {Exist_username}...  ");
                    Role_Cashier(); 
                    break;
                case "Customer":
                    Console.WriteLine($"Welcome ({role})  {Exist_username}...  ");
                    Role_Customer(Exist_username);
                    break;

            }

        }
        
        
    }


    public void Role_Manager()
    {
        while (true)
        {
            Console.WriteLine("Enter your option  : 1.Create Account, 2.Deposite Amount, 3.Check Balance, 4.WithDraw, 5.Exit  ");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    CreateSavingAccount();
                    break;
                case 2:
                    AmountDeposite();
                    break;
                case 3:
                    BalanceChecking();
                    break;
                case 4:
                    AmountWithDraw();
                    break;
                case 5:
                    Console.WriteLine("Thank You...");
                    break;
                default:
                    Console.WriteLine("Please Select Correct option..");
                    break;
            }

            if (input == 5)
            {
                break;
            }
        }
    }

    public void Role_Cashier()
    {
        while (true)
        {
            Console.WriteLine("Enter your option  : 1.Deposite Amount, 2.Check Balance, 3.WithDraw, 4.Exit  ");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                
                case 1:
                    AmountDeposite();
                    break;
                case 2:
                    BalanceChecking();
                    break;
                case 3:
                    AmountWithDraw();
                    break;
                case 4:
                    Console.WriteLine("Thank You...");
                    break;
                default:
                    Console.WriteLine("Please Select Correct option..");
                    break;
            }

            if (input == 4)
            {
                break;
            }
        }
    }

    public void Role_Customer(string existusername)
    {
     

        while (true)
        {
            Console.WriteLine("Enter your option  : 1.Deposite Amount, 2.Check Balance, 3.WithDraw, 4.Exit  ");

            int input = Convert.ToInt32(Console.ReadLine());

            switch(input)
            {
                case 1:
                    AmountDepositeCus(existusername);
                    break;
                case 2:
                    BalanceCheckingCus(existusername);
                    break;
                case 3:
                    AmountWithDrawCus(existusername);
                    break;
                case 4:
                    Console.WriteLine("Thank You...");
                    break;
            }

            if (input == 4)
            {
                break;
            }
        }
    }

    public void AmountWithDrawCus(string existusername)
    {
      



        if (existusername != null)
        {
            Console.WriteLine("Enter your Withdraw Amount  : ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());

            _atm.WithdrawMoney(withdrawAmount, existusername);
        }
    }
    public void BalanceCheckingCus(string existusername)
    {
        
        double currentBalance = _atm.CheckBalance(existusername);

        Console.WriteLine($"Your Current Account Balance is : {currentBalance}");

    }

    public void AmountDepositeCus(string existusername)
    {
        
        if (existusername != null)
        {
            Console.WriteLine("Enter your Deposite Amount  : ");
            double depositeAmount = Convert.ToDouble(Console.ReadLine());
            _atm.Deposite(depositeAmount, existusername);
        }


    }

    
}