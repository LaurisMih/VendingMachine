using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineNameSpace.Exceptions;

namespace VendingMachineNameSpace
{
    public class VendingMachine : IVendingMachine
    {
        private string _manufacturer;
        private bool _hasProducts;
        private Money _amount;
        public Product[] Products { get; set; }
        private string[] acceptCoins = new string[] { "0.10", "0.20", "0.50", "1.00", "2.00" };
        private Money totalMoneyInsert;
        private int productBougthIndex;
        public string Manufacturer => _manufacturer;
        public bool HasProducts => _hasProducts;
        public Money Amount => _amount;

        public VendingMachine(string manufacturer, int slotAmount)
        {
            _manufacturer = manufacturer;
            _hasProducts = false;
            _amount = new Money(0, 0);
            Products = new Product[slotAmount];
        }

        public Money InsertCoin(Money amount)
        {

            if (!acceptCoins.Contains(amount.ToString()))
            {
                throw new IncorrectCoinValue();
            }

            if (acceptCoins.Contains(amount.ToString()))
            {
                _amount = new Money(_amount.Euros + amount.Euros, _amount.Cents + amount.Cents);
                totalMoneyInsert = new Money(totalMoneyInsert.Euros + amount.Euros, totalMoneyInsert.Cents + amount.Cents);

                Console.WriteLine($"You have inserted: {totalMoneyInsert}€\nPrice of the product: {Products[productBougthIndex].Price}€");
                return amount;
            }

            else
            {

                Console.WriteLine($"Sorry use only  {string.Join(" , ", acceptCoins)} coins.");
                return amount;
            }
        }

        public Money ReturnMoney()
        {
            if (ToCents(totalMoneyInsert) == ToCents(Products[productBougthIndex].Price))
            {
                return _amount;
            }

            Money returnAmount = new Money(totalMoneyInsert.Euros - Products[productBougthIndex].Price.Euros,
                totalMoneyInsert.Cents - Products[productBougthIndex].Price.Cents);
            _amount = new Money(_amount.Euros - returnAmount.Euros, _amount.Cents - returnAmount.Cents);

            if (returnAmount.Cents < 0)
            {
                returnAmount = new Money(returnAmount.Euros - 1, returnAmount.Cents + 100);
            }

            if (_amount.Cents < 0)
            {
                _amount = new Money(_amount.Euros - 1, _amount.Cents + 100);
            }

            Console.WriteLine($"{returnAmount}€ returned");
            return _amount;
        }

        public bool AddProduct(string name, Money price, int num)
        {
            int space = -1;

            for (var i = 0; i < Products.Length; i++)
            {
                if (Products[i].Name == null)
                {
                    space = i;
                    break;
                }
            }

            if (space == -1)
            {
                throw new MachineDontHaveSpace();               
            }

            else
            {
                Products[space] = new Product(name, price, num);
                _hasProducts = true;
                return true;
            }
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            if (productNumber > Products.Length || productNumber < 1)
            {
                throw new InvalidProductNumber();               
            }

            else
            {
                Products[productNumber - 1] = new Product(name, price, amount);
                return true;
            }
        }

        public void ChooseProduct(int index)
        {
            if (IsValidProduct(index))
            {
                productBougthIndex = index - 1;
                totalMoneyInsert = new Money(0, 0);
                Console.WriteLine($"You have chosen {Products[productBougthIndex].Name}, " +
                    $"which costs {Products[productBougthIndex].Price}€. Please input a coin in format '0.00' :");
            }

            else
            {
                throw new ItemIsNotValid();               
            }
        }

        public void SellProduct()
        {
            Products[productBougthIndex].Available--;

            Console.WriteLine($"Enjoy your {Products[productBougthIndex].Name}!");
        }

        public void GetProducts()
        {
            if (_hasProducts == false)
            {
                throw new MachineDontHaveProducts();               
            }

            else
            {
                Console.WriteLine("Available products:");
                for (int i = 0; i < Products.Length; i++)
                {
                    if (Products[i].Name != null)
                    {
                        Console.WriteLine($"{i + 1}. {Products[i]}");
                    }
                }
            }
        }

        public bool PurchaseConfirm()
        {
            if (ToCents(totalMoneyInsert) == ToCents(Products[productBougthIndex].Price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidProduct(int index)
        {           
            return Products[index - 1].Available > 0 && Products[index - 1].Name != null && index - 1 < Products.Length;
        }

        public int ToCents(Money money)
        {
            var cents = money.Euros * 100 + money.Cents;
            return cents;
        }
    }
}