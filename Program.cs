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
        public int pin;

        public Account(string _accountName, float deposit, int _pin)
        {
            AccountName = _accountName;
            balance = deposit;
            Random rnd = new Random();
            AccountNo = rnd.Next(10000, 19999);
            pin = _pin;

        }
        public void checkBalance(int accountNo, int pin)
        {
            if (accountNo == this.AccountNo && pin == this.pin)
            {
                Console.WriteLine($"your balance is {this.balance}");
            }
            else if (accountNo != this.AccountNo)
            {
                Console.WriteLine("Invalid account Number");
            }
            else
            {
                Console.WriteLine("Invalid pin");
            }
        }

        public void initialdeposit(int deposit)
        {
            this.balance += deposit;
            Console.WriteLine($"Thank You, your account Number has been generated {this.AccountNo} your new balance is ${balance}");

        }

        public void makedeposit(int Youraccount, int deposit, int pin)
        {
            if (Youraccount == this.AccountNo && pin == this.pin)
            {

                this.balance += deposit;
                Console.WriteLine($"Thank You, your new balance is ${balance}");
            }
            else if (Youraccount != this.AccountNo)
            {
                Console.WriteLine("Please reconfirm account number");
            }
            else
            {
                Console.WriteLine("Please reconfirm account pin");
            }

        }

        public void withrawal(int yourAccount, int withdrawamount, int pin)
        {
            if (yourAccount == this.AccountNo && pin == this.pin)
            {
                if (withdrawamount <= this.balance)
                {
                    Console.WriteLine("Please that your cash");
                    Console.WriteLine($"YOur balance is {this.balance - withdrawamount}");
                }
                else
                {
                    Console.WriteLine($"insufficient funds, you are trying to withdraw ${withdrawamount} and you only have ${this.balance} in your Account");
                }

            }
            else if (yourAccount != this.AccountNo)
            {
                Console.WriteLine("PLease reconfirm account number");
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
            Console.WriteLine("Welcome");
            //List of all the customers 
            List<Account> customers = new List<Account>();
            bool Notfinshied = true;
            while (Notfinshied == true)
            {


                Console.WriteLine("Please press 1 to create new account");
                Console.WriteLine("Please press 2 to check balance on existing account");
                Console.WriteLine("Please press 3 to withdraw from existing account");
                Console.WriteLine("Please press 4 to deposit into account");
                Console.WriteLine("Press 5 if you are done with your transactions");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    //To create a new account
                    case 1:
                        Console.WriteLine("Please enter your name");
                        string name = Console.ReadLine();
                        Console.WriteLine($"Hello {name} ");
                        Console.WriteLine("Please select a four digit pin");
                        int thispin = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        customers.Add(new Account(name, 0, thispin));

                        Console.WriteLine("Please make initial deposit");
                        int inideposit = Convert.ToInt32(Console.ReadLine());
                        var thiscustomeR = customers.Where(i => i.AccountName == name).FirstOrDefault();
                        //list.Where(i => i.Property == value).FirstOrDefault();
                        thiscustomeR.initialdeposit(inideposit);
                        Console.WriteLine();

                        break;
                    //To Check account balance
                    case 2:
                        bool accCorrect = true;

                        while (accCorrect)
                        {
                            Console.WriteLine("Enter account number to check balance");
                            int accountno = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter your four digit pin");
                            int thisPin = Convert.ToInt32(Console.ReadLine());
                            var thiscustomer = customers.Where(i => i.AccountNo == accountno).FirstOrDefault();
                            if (thiscustomer != null && thisPin == thiscustomer.pin)
                            {
                                thiscustomer.checkBalance(accountno, thisPin);
                                Console.WriteLine();
                                accCorrect = false;
                            }
                            else if (thiscustomer != null && thisPin != thiscustomer.pin)
                            {
                                Console.WriteLine("incorrect pin");
                                Console.WriteLine();

                            }
                            else
                            {
                                Console.WriteLine("incorrect Account number");
                                Console.WriteLine();
                            }
                        }



                        break;
                    //To make withdrawal from account
                    case 3:
                        bool accCorrectt = true;
                        while (accCorrectt)
                        {
                            Console.WriteLine("Enter account number");
                            int customeracc = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter your four digit pin");
                            int ThisPin = Convert.ToInt32(Console.ReadLine());
                            var thisCustomer = customers.SingleOrDefault(item => item.AccountNo == customeracc);
                            if (thisCustomer != null && ThisPin == thisCustomer.pin)
                            {
                                Console.WriteLine("Enter amount you want to withdraw");
                                int withraw = Convert.ToInt32(Console.ReadLine());
                                thisCustomer.withrawal(customeracc, withraw, ThisPin);
                                Console.WriteLine();
                                accCorrectt = false;
                            }
                            else if (thisCustomer != null && ThisPin != thisCustomer.pin)
                            {
                                Console.WriteLine("incorrect pin");
                                Console.WriteLine();

                            }
                            else
                            {
                                Console.WriteLine("incorrect Account number");
                                Console.WriteLine();
                            }
                        }


                        break;
                    //To make deposit into account
                    case 4:
                        bool accCorrecttt = true;
                        while (accCorrecttt)
                        {
                            Console.WriteLine("Enter account number");
                            int customeracc = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter your four digit pin");
                            int thisPinn = Convert.ToInt32(Console.ReadLine());
                            var thisCustomer = customers.SingleOrDefault(item => item.AccountNo == customeracc);
                            if (thisCustomer != null && thisPinn == thisCustomer.pin)
                            {
                                Console.WriteLine("Enter amount you want to deposit");
                                int deposit = Convert.ToInt32(Console.ReadLine());
                                thisCustomer.makedeposit(customeracc, deposit, thisPinn);
                                Console.WriteLine();
                                accCorrecttt = false;
                            }
                            else if (thisCustomer != null && thisPinn != thisCustomer.pin)
                            {
                                Console.WriteLine("incorrect pin");
                                Console.WriteLine();

                            }
                            else
                            {
                                Console.WriteLine("incorrect Account number");
                                Console.WriteLine();
                            }
                        }

                        break;
                    case 5:
                        Notfinshied = false;
                        break;

                }

            }
        }
    }
}
