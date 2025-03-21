

using ATM_Function.Classes;
using ATM_Function.Interface;
using System;

public class Program
{
    

    public static void Main(string[] args)
    {
        IATM atm = new ATM();
        ATMFunction atmfuction = new ATMFunction(atm);

        atmfuction.RoleBased();
        
    }
}