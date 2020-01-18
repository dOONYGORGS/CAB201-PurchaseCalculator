using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseApp
{
    class PurchaseCalc
    {
        public static void Main()
        {
            //tax rate of 10%
            double taxRate = 0.1;
            //tax values
            double tax;
            //shipping charge
            double shippingCharge = 0;
            //Holds Total of Purchases
            double totalPurch = 0;
            //Holds Quantity of Purchases
            int numPurch = 0;
            //Total
            double total;

            //Welcome Message
            Console.WriteLine("This application computes the total due for your purchases.");
            Console.WriteLine("It will allow you to enter an number of purchase amounts, and then display a receipt.");
            Console.WriteLine("Press enter when you are ready to begin...\n");
            Console.ReadLine();

            //PRICES
            string amount;
            string error = "Invalid data entered - please re-enter the amount of the item - ";
            double doubleInput;
            bool gameEnd = false;

            while (gameEnd == false)
            {

                //Ask user for further input; only if they have first entered something
                //Prompt for input
                Console.Write("What is the amount of the item? - ");
                amount = Console.ReadLine();
                //Parse from string to double
                if (double.TryParse(amount, out doubleInput))
                {
                    //Append item to array
                    totalPurch += doubleInput;
                    //increment the total number of purchases
                    numPurch++;
                    Console.Write("Do you want to enter more purchases? - Y or N ");
                    char test;
                    char.TryParse(Console.ReadLine(), out test);
                    if (test == 'N' || test == 'n')
                    {
                        gameEnd = true;
                    }
                    else if (test == 'Y' || test == 'y')
                    {
                        //continue loop
                    }
                    else
                    {
                        gameEnd = true;
                    }
                }
                else
                {
                    Console.Write(error);
                    amount = Console.ReadLine();
                }
            }

            //Calculates Total Tax
            tax = taxRate * totalPurch;

            //Determine Shipping Cost
            if (numPurch < 3)
            {
                shippingCharge = 3.5;
            }
            else if (numPurch >= 3 && numPurch <= 6)
            {
                shippingCharge = 5;
            }
            else if (numPurch >= 7 && numPurch <= 10)
            {
                shippingCharge = 7;
            }
            else if (numPurch >= 11 && numPurch <= 15)
            {
                shippingCharge = 9;
            }
            else if (numPurch > 15)
            {
                shippingCharge = 10;
            }

            total = totalPurch + tax + shippingCharge;

            //RECEIPT
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("\t   Sales Receipt\n");
            Console.WriteLine("Total Purchases: \t\t    {0:C2}\n", totalPurch);
            Console.WriteLine("Sales Tax: \t\t\t    {0:C2}\n", tax);
            Console.WriteLine("Number of Items Purchased: \t\t{0}\n", numPurch);
            Console.WriteLine("Shipping charge: \t\t    {0:C2}\n", shippingCharge);
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Grand total:\t\t\t    {0:C2}\n", total);

            Console.WriteLine("\nHit enter to exit");
            Console.ReadLine();
        }
    }
}