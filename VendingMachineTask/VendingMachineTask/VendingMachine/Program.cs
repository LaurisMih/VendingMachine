using System;
using System.Linq;
using VendingMachineNameSpace;

namespace VendingMachineNameSpace
{
    internal class Program
    {
        static VendingMachine Samsung123 = new("Samsung123", 6);
        static bool loop = true;

        static public void Main(string[] args)
        {
            Samsung123.AddProduct("Mask", new Money(1, 00), 5);
            Samsung123.AddProduct("Twix", new Money(1, 50), 5);
            Samsung123.AddProduct("Snickers", new Money(1, 50), 11);
            Samsung123.AddProduct("Fanta", new Money(1, 60), 8);
            Samsung123.AddProduct("Sprite", new Money(1, 70), 4);
            Samsung123.AddProduct("Coca-Cola", new Money(2, 00), 20);

            while (loop)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome please choose the option:");
                Console.WriteLine("1) Show products");
                Console.WriteLine("2) Purchase a product");
                Console.WriteLine("3) Check earning");
                Console.WriteLine("4) Update items");
                Console.WriteLine("5) Exit");
                var userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Product();
                        break;
                    case 2:
                        Purchase();
                        break;
                    case 3:
                        Console.WriteLine("Enter password");
                        var userPassword = int.Parse(Console.ReadLine());
                        if (userPassword == 123)
                        {
                            Console.WriteLine("Total earnings:");
                            GetEarnings();
                        }
                        else
                        {
                            Console.WriteLine("Wrong password!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter password");
                        var password = int.Parse(Console.ReadLine());
                        if (password == 123)
                        {
                            Console.WriteLine("Password is correct you can update items");
                            Console.WriteLine();
                           Update();
                        }
                        else
                        {
                            Console.WriteLine("Wrong password!");
                        }
                        break;
                    case 5:
                        loop = false;
                        break;
                }
            }
        }

        static void Product()
        {
            Samsung123.GetProducts();

        }

        static void Purchase()
        {
            Console.Clear();
            Samsung123.GetProducts();
            Console.WriteLine("Input a product number:");
            int userInput = int.Parse(Console.ReadLine());
            Samsung123.ChooseProduct(userInput);


            while (!Samsung123.PurchaseConfirm())
            {
                var input = Array.ConvertAll(Console.ReadLine().Split('.'), int.Parse);
                Samsung123.InsertCoin(new Money(input[0], input[1]));
            }

            Samsung123.ReturnMoney();
            Samsung123.SellProduct();
        }

        static void Update()
        {
            Samsung123.GetProducts();
            Console.WriteLine("Input index of item what you want to chage");
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine("Input new name");
            string newName = Console.ReadLine();

            Console.WriteLine("Input new price in '0.00' format");
            int[] newPrice = Array.ConvertAll(Console.ReadLine().Split('.'), int.Parse);

            Console.WriteLine("Input new amount");
            int newAmount = int.Parse(Console.ReadLine());

            if (Samsung123.UpdateProduct(index, newName, new Money(newPrice[0], newPrice[1]), newAmount))
            {
                Console.WriteLine($"Product {index} updated!");
            }
            else
            {
                Console.WriteLine($"Product {index} is not updated");
            }
        }

        static void GetEarnings()
        {
            Console.WriteLine(Samsung123.Amount);
        }
    }
}