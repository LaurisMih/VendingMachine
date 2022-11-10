using VendingMachineNameSpace;
using VendingMachineNameSpace.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VendingMachineTests
{
    [TestClass]
    public class VendingMachineTests
    {
        private Money _money;
        private Product product;
        private VendingMachine _vendingMachine;
        private int productBougthIndex;
        private bool _hasProducts;

        [TestInitialize]
        public void SetUp()
        {
            _vendingMachine = new VendingMachine("Samsung", 2);
            _hasProducts = false;

        }

        [TestMethod]
        public void VendingMachine_UpdateProduct()
        {
            _vendingMachine.UpdateProduct(1, "Cola", new Money(0, 90), 2);
            var x = new Product("Cola", new Money(0, 90), 2).ToString();
            var y = _vendingMachine.Products[0];
            y.Should().Be(new Product("Cola", new Money(0, 90), 2));
        }

        [TestMethod]
        public void VendingMachine_UpdateProduct_InvalidProductNumber()
        {         
            Action act = () => _vendingMachine.UpdateProduct(0, "Pringles", new Money(1, 5), 1);
            act.Should().Throw<InvalidProductNumber>()
                .WithMessage("Invalid product number");
        }

        [TestMethod]
        public void VendingMachine_MoneyCount()
        {
            var money1 = new Money(0, 20);
            var money2 = new Money(0, 20);
            var money3 = new Money(0, 20);

            _vendingMachine.InsertCoin(money1);
            _vendingMachine.InsertCoin(money2);
            _vendingMachine.InsertCoin(money3);

            _vendingMachine.Amount.Should().Be(new Money(0, 60));
        }

        [TestMethod]
        public void VendingMachine_IncorrectCoinValue()
        {
            var money1 = new Money(0, 30);
            Action act = () => _vendingMachine.InsertCoin(money1);
            act.Should().Throw<IncorrectCoinValue>()
                .WithMessage("Machine dont accept this coin value");
        }

        [TestMethod]
        public void VendingMachine_AddProduct_NoSpaceAviable()
        {
            _vendingMachine = new VendingMachine("Samsung", 0);
            Action act = () => _vendingMachine.AddProduct("Snickers", new Money(0, 5), 1);
            act.Should().Throw<MachineDontHaveSpace>()
                .WithMessage("Vending machine dont have free space");
        }


        [TestMethod]
        public void VendingMachine_PurchaseConfirm()
        {
            _vendingMachine.AddProduct("Twix", new Money(0, 20), 6);
            var money1 = new Money(0, 20);
            var moneyInsert = _vendingMachine.InsertCoin(money1);
            _vendingMachine.PurchaseConfirm().Should().BeTrue();
        }

        [TestMethod]
        public void VendingMachine_GetProducts_NoProductInMachine()
        {
            _hasProducts = false;
            Action act = () => _vendingMachine.GetProducts();
            act.Should().Throw<MachineDontHaveProducts>()
                .WithMessage("Vending machine dont have products");
        }

        [TestMethod]
        public void VendingMachine_SellProduct()
        {
            _vendingMachine.SellProduct();
            _vendingMachine.Products[productBougthIndex].Available--;
        }

    }
}
