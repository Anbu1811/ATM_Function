using ATM_Function.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Function.Classes
{
    public class ATM : IATM
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-QRDJP05\\SQLEXPRESS; Initial Catalog = WebApplication; Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

       

        public void CreateAccount(string username, string password, long accountNumber ,string role,decimal minimumBlnc)
        {
            try
            {
               

                con.Open();
                //cmd = new SqlCommand(" insert into BankManagement(UserName,Password,Role,Balance) values('@username','@password','@role','@balance')", con);
                //cmd = new SqlCommand("Create_Account1", con);

               // cmd = new SqlCommand(" insert into BankManagement(UserName,Password,Role,Balance) values('"+username+ "','"+password+ "','"+role+ "','"+minimumBlnc+"')", con);
                cmd = new SqlCommand(" insert into BankManagement(UserName, Password, AccountNumber, Role, Balance) values(@username,@password, @accountNumber,@role,@balance)", con);
                
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@balance", Convert.ToDecimal(minimumBlnc));


                cmd.ExecuteNonQuery();
               

                Console.WriteLine("Account Create Successfully");


            }
            catch (Exception ex)
            {

                Console.WriteLine("Account Create Failed..." + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
                
            }



        }

        public void Deposite(double deposite_amount, string username)
        {
            
            try
            {

                double balance = 0;
                con.Open();


                //Reterive Existing Balance

                cmd = new SqlCommand("select Balance from BankManagement where UserName  = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    double newbalance = Convert.ToDouble(reader["Balance"]);

                    balance = newbalance;
                }

                cmd.Parameters.Clear();
                reader.Close();




                //Update Balance

                cmd = new SqlCommand("update BankManagement set Balance = @deposite where UserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@deposite",(balance + deposite_amount));

                
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                Console.WriteLine("Amount Deposite Successfully");
                Console.WriteLine("Your Current Balance is : " +(balance+deposite_amount));


               





            }
            catch (Exception ex)
            {

                Console.WriteLine("Amount Deposite Failed..." + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public double CheckBalance(string username)
        {
            double balance = 0;
            try
            {


                con.Open();
               

                cmd = new SqlCommand("select Balance from BankManagement where UserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    double newbalance = Convert.ToDouble(reader["Balance"]);

                    balance = newbalance;
                }

                return balance;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Balance Check Function Failed..." + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

            return balance;
        }



        public void WithdrawMoney(double withdrawamount,string username)
        {
            
            double balance1 = 0;
            try
            {


                //Reterive Existing Balance
                con.Open();
                cmd = new SqlCommand("select Balance from BankManagement where UserName  = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    double Available_balance = Convert.ToDouble(reader["Balance"]);

                    cmd.Parameters.Clear();
                    reader.Close();



                    if (Available_balance > withdrawamount)
                    {
                        double balance = (Available_balance - withdrawamount);


                        //update current Balance
                        cmd = new SqlCommand("update BankManagement set Balance = @balance where UserName = @username", con);
                        cmd.Parameters.AddWithValue("@balance", balance);
                        cmd.Parameters.AddWithValue("@username", username);

                        cmd.ExecuteNonQuery();



                        Console.WriteLine("Please Collect Your Cash : " + withdrawamount);
                        Console.WriteLine("Your Current Balance is  : " + balance);


                    }
                    else if (withdrawamount > Available_balance)
                    {
                        Console.WriteLine("Insuficient Fund...");
                    }

                   
                }

             

            }
            catch (Exception ex)
            {

                Console.WriteLine("Amount Withdraw Failed..." + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

            
        }


        public string UpdatePassword(string oldPassword)
        {
            throw new NotImplementedException();
        }

        public string AccountHolderisExist(string username, string password)
        {
            string accountHolderName = "";
            try
            {


                con.Open();


                cmd = new SqlCommand("select UserId,UserName,Password,Role,Balance from BankManagement where UserName = @username and Password = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string Current_accountHolderName = reader["UserName"].ToString();

                    accountHolderName = Current_accountHolderName;

                    return accountHolderName;
                }
                else
                {
                    Console.WriteLine("Your Username and Password is Incorrect...");
                }

             

            }
            catch (Exception ex)
            {

                Console.WriteLine("Balance Check Function Failed..." + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

            return accountHolderName;

        }

        public string AccountHolderRole(string username)
        {
            string accountHolderRole = "";
            try
            {


                con.Open();


                cmd = new SqlCommand("select Role from BankManagement where UserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string Current_accountHolderRole = reader["Role"].ToString();

                    accountHolderRole = Current_accountHolderRole;

                    return accountHolderRole;
                }
                else
                {
                    Console.WriteLine("Your Role does not exist...");
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Account holder Role error..." + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

            return accountHolderRole;

        }

        public string AccountNumberisExist(long accountNumber)
        {
            string accountHolderName = "";
            try
            {


                con.Open();


                cmd = new SqlCommand("select UserId,UserName,AccountNumber,Role,Balance from BankManagement where AccountNumber = @accountNumber", con);
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string Current_accountHolderName = reader["UserName"].ToString();

                    accountHolderName = Current_accountHolderName;

                    return accountHolderName;
                }
                else
                {
                    Console.WriteLine("Your Username and Password is Incorrect...");
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Balance Check Function Failed..." + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

            return accountHolderName;

        }
    }
}
