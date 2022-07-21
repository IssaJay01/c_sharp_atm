using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_atm
{
    internal class Program
    {
        static void Main(string[] args)
        {
			string title = "~~~~~ ATM MACHINE ~~~~~";
			Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title)); //learned a new format trick lol

			int cardNumber = 1002003000, pinNumber = 1234, balance = 50000, userChoice = 0;

			Console.Write("\n\nHello! Please enter your card number here: "); //card number is 1002003000;
			int inputCN = Convert.ToInt32(Console.ReadLine());

			string validateCN = inputCN.ToString();

			//checking to make sure the user entered 10 digits
			if (validateCN.Length != 10) {
				Console.WriteLine("\nCard number must be 10 digits long. You entered {0} digits... Program Closing.", validateCN.Length);
				Console.ReadLine();
				Environment.Exit(0);
			} 
			//checking the card number
			else if (inputCN != cardNumber) {
				Console.WriteLine("\nInvalid card number... Program Closing.");
				Console.ReadLine();
				Environment.Exit(0);
			}

			Console.Write("Please enter your PIN Number: "); // pin is 1234
			Console.ForegroundColor = ConsoleColor.Black; //Hiding the pin number for security reasons
			int inputP = Convert.ToInt32(Console.ReadLine());
			Console.ResetColor(); //reset so everything doesnt end up hidden

			string validateP = inputP.ToString();

			//checking to make sure the user entered 4 digits
			if (validateP.Length != 4) {
				Console.WriteLine("\nPIN must be 4 digits long. You entered {0} digits... Program Closing.", validateP.Length);
				Console.ReadLine();
				Environment.Exit(0);
			}
			//checking the PIN number
			else if (inputP != pinNumber) {
				Console.WriteLine("\nInvalid PIN... Program Closing.");
				Console.ReadLine();
				Environment.Exit(0);
			}

			//While loop is so we return to the main menu everytime until user chooses to log out
			while (userChoice != 4) {
				string intro = "~~~~~~~~~~ MAIN MENU ~~~~~~~~~~";
				Console.WriteLine(String.Format("\n\n{0," + ((Console.WindowWidth / 2) + (intro.Length / 2)) + "}", intro));

				Console.WriteLine("\t1. View Balance");
				Console.WriteLine("\t2. Deposit Cash");
				Console.WriteLine("\t3. Withdraw Cash");
				Console.WriteLine("\t4. Logout");

				Console.Write("\nOption: ");
				userChoice = Convert.ToInt32(Console.ReadLine());

				//Switch-case better than if-else here
				switch (userChoice) {
					//view balance
					case 1:
						Console.WriteLine("\n\t\tYour Balance is: {0:C}", balance);
						Console.ReadLine();
						break;
					//Deposit cash
					case 2:
						Console.WriteLine("\nYou may deposit up to $50,000 at a time");
						Console.Write("How much would you like to deposit into your account? ");
						int deposit = Convert.ToInt32(Console.ReadLine());

						if(deposit < 0 && deposit > 50000)
                        {
							Console.WriteLine("\n\t\tIm sorry but the value you entered is invalid.");
							Console.ReadLine();
                        }
						else if(deposit == 0)
                        {
							Console.WriteLine("\n\t\tYou think you're so funny huh...");
							Console.WriteLine("\t\tYour balance is still {0:C}. >=( ", balance);
							Console.ReadLine();
                        }
                        else
                        {
							balance = balance + deposit;
							Console.WriteLine("\n\t\tYou are depositing {0:C}. Success! Your balance has been updated to {1:C}", deposit, balance);
							Console.ReadLine();
                        }
						break;
					//Withdraw cash
					case 3:
						Console.WriteLine("Your current balance is: {0:C}", balance);
						Console.Write("How much would you like to withdraw? ");
						int withdraw = Convert.ToInt32(Console.ReadLine());

						if (withdraw < 0 && withdraw > balance)
						{
							Console.WriteLine("\n\t\tIm sorry but the value you entered is either less than zero or over your current balance.");
							Console.ReadLine();
						}
						else if (withdraw == 0)
						{
							Console.WriteLine("\n\t\t...Do you... think I'm a joke?");
							Console.WriteLine("\t\tYour balance is still {0:C}. >=( ", balance);
							Console.ReadLine();
						}
						else
						{
							balance = balance - withdraw;
							Console.WriteLine("\n\t\tYou are withdrawing {0:C}. Success! Your balance has been updated to {1:C}", withdraw, balance);
							Console.ReadLine();
						}
						break;
					//Logout
					case 4:
						Console.WriteLine("\n\t\tLogging you out now Thank you for banking with... um... Bank of Banks? Yea Bank of Banks!");
						break;
					//Invalid option input
					default:
						Console.WriteLine("\n\t\tInvalid Option selected...");
						Console.ReadLine();
						break;
				}
			}
			Console.ReadLine();
        }
    }
}
