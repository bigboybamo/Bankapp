using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    public class Account
    {
        public string AccountName;
        public float balance;
        public int AccountNo;

        public Account(string _accountName, float deposit)
        {
            AccountName = _accountName;
            balance = deposit;
            Random rnd = new Random();
            AccountNo = rnd.Next(10000,19999);
           

        }
        public  void checkBalance(int accountNo)
        {
            if (accountNo == this.AccountNo)
            {
                Console.WriteLine( $"your balance is {this.balance}");
            }
            else
            {
                Console.WriteLine("Invalid account Number");
            }
        }

        public void initialdeposit(int deposit)
        {
            this.balance += deposit;
            Console.WriteLine($"Thank You, your account Number has been generated {this.AccountNo} your new balance is {balance}");

        }

        public void makedeposit(int Youraccount,int deposit)
        {
            if (Youraccount == this.AccountNo) {

                this.balance += deposit;
                Console.WriteLine($"Thank You, your new balance is {balance}");
            }
            else
            {
                Console.WriteLine("Please reconfirm account number");
            }

        }

        public void withrawal(int yourAccount, int withdrawamount)
        {
            if (yourAccount == this.AccountNo)
            {
                if(withdrawamount <= this.balance)
                {
                    Console.WriteLine("Please that your cash");
                    Console.WriteLine($"YOur balance is {this.balance - withdrawamount}");
                }
                else
                {
                    Console.WriteLine("insufficient funds");
                }

            }
            else
            {
                Console.WriteLine("PLease reconfirm account number");
            }

        }



    }
    class Program
    {

        static void Main(string[] args)
        {
            
            List<Account> customers = new List<Account>();
            bool Notfinshied = true;
            while (Notfinshied == true)
            {

                Console.WriteLine("Welcome");
                Console.WriteLine("Please press 1 to create new account");
                Console.WriteLine("Please press 2 to check balance on existing account");
                Console.WriteLine("Please press 3 to withdraw from existing account");
                Console.WriteLine("Please press 4 to deposit into account");
                Console.WriteLine("Press 5 if you are done with your transactions");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Please enter your name");
                        string name = Console.ReadLine();
                        Console.WriteLine($"Hello {name} ");
                        customers.Add(new Account(name,0));
                                                
                        Console.WriteLine("Please make initial deposit");
                        int inideposit = Convert.ToInt32(Console.ReadLine());
                        var thiscustomeR = customers.Where(i => i.AccountName == name).FirstOrDefault();
                        //list.Where(i => i.Property == value).FirstOrDefault();
                        thiscustomeR.initialdeposit(inideposit);

                        break;
                    case 2:
                        Console.WriteLine("Enter account number to checkbalance");
                        int accountno = Convert.ToInt32(Console.ReadLine());
                        var thiscustomer = customers.SingleOrDefault(item => item.AccountNo == accountno);
                        thiscustomer.checkBalance(accountno);
                        break;
                    case 3:
                        Console.WriteLine("Enter account number");
                        int customeracc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount you want to withdraw");
                        int withraw = Convert.ToInt32(Console.ReadLine());
                        var thisCustomer = customers.SingleOrDefault(item => item.AccountNo == customeracc);
                        thisCustomer.withrawal(customeracc, withraw);
                        break;
                    case 4:
                        Console.WriteLine("Enter account number");
                        int customerAcc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount you want to deposit");
                        int deposit = Convert.ToInt32(Console.ReadLine());
                        var ThisCustomer = customers.SingleOrDefault(item => item.AccountNo == customerAcc);
                        ThisCustomer.makedeposit(customerAcc, deposit);
                        break;
                    case 5:
                        Notfinshied = false;
                        break;

                }

            }
        }
    }
}
