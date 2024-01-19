using System;

public class cardholder
{
    string cardnum;
    int pin;
    string firstname;
    string lastname;
    double balance;

    public cardholder(string cardnum, int pin, string firstname, string lastname, double balance)
    {
        this.cardnum = cardnum;
        this.pin = pin;
        this.firstname = firstname;
        this.lastname = lastname;
        this.balance = balance;
    }

    public string getnum()
    {
        return cardnum;
    }

    public int getpin()
    {
        return pin;
    }

    public string getfirstname()
    {
        return firstname;
    }

    public string getlastname()
    {
        return lastname;
    }

    public double getbalance()
    {
        return balance;
    }

    public void setnum(string newcardnum)
    {
        cardnum = newcardnum;
    }

    public void setpin(int newpin)
    {
        pin = newpin;
    }

    public void setfirstname(string newfirstname)
    {
        firstname = newfirstname;
    }
    public void setlastname(string newlastname)
    {
        lastname = newlastname;
    }
    public void setbalance(double newbalance)
    {
        balance = newbalance;
    }
    public static void Main(String[] args)
    {
        void printoptions()
        {
            Console.WriteLine("Please choose from one of the following options....");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4.Exit");
        }

        void deposit(cardholder currentuser)
        {
            Console.WriteLine("how much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentuser.setbalance(currentuser.getbalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is" + currentuser.getbalance());
        }
        void withdraw(cardholder currentuser)
        {
            Console.WriteLine("How much $$ would you like to withdraw?");
            double withdrawl = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if (currentuser.getbalance() < withdrawl)
            {
                Console.WriteLine("insufficient balance");
            }
            else
            {
                currentuser.setbalance(currentuser.getbalance() - withdrawl);
                Console.WriteLine("You are good to go. Thank you");
            }
        }
        void balance(cardholder currentuser)
        {
            Console.WriteLine("current balance" + currentuser.getbalance());
        }
        List<cardholder> cardholders = new List<cardholder>();
        cardholders.Add(new cardholder("123455666777777", 1234, "subina", "dhakal", 150.31));
        cardholders.Add(new cardholder("123455444777777", 1234, "Beesal", "Nepal", 153.01));
        cardholders.Add(new cardholder("123455777777777", 1234, "sishant", "shrestha", 120.00));
        cardholders.Add(new cardholder("123455222777777", 1234, "riya", "das", 10.50));
        cardholders.Add(new cardholder("123455000777777", 1234, "prajita", "paudel", 13555.40));

        //prompt user
        Console.WriteLine("welcome to simple Atm");
        Console.WriteLine("please enter your debit card:");
        String debitcardnum = "";
        cardholder currentuser;
        while (true)
        {
            try
            {
                debitcardnum = Console.ReadLine();
                //check against our db
                currentuser = cardholders.FirstOrDefault(a => a.cardnum == debitcardnum);
                if (currentuser != null)
                {
                    break;
                }
                else { Console.WriteLine("card is not recognized.please try again"); }

            }
            catch
            {
                Console.WriteLine("card is not recognized.please try again");
            }

        }
        Console.WriteLine("please enter your pin: ");
        int userpin = 0;
        while (true)
        {
            try
            {
                userpin = int.Parse(Console.ReadLine());
                //check against our db

                if (currentuser.getpin() == userpin)
                {
                    break;
                }
                else { Console.WriteLine("incorrect pin.please try again"); }

            }
            catch
            {
                Console.WriteLine("incorrect pin.please try again");
            }

        }
        Console.WriteLine(" welcome" + currentuser.getfirstname() + ":)");
        int option = 0;
        do
        {
            printoptions();
            try
            {
                option = int.Parse(Console.ReadLine());

            }
            catch
            { }
            if (option == 1)
            {
                deposit(currentuser);
            }
            else if (option == 2)
            {
                withdraw(currentuser);
            }
            else if (option == 3)
            {
                balance(currentuser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }

        } while (option != 4);
        Console.WriteLine("Thank You! Have a nice day :)");
    }
}
