using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallyBook_Store_Management_System.Controllers;
using TallyBook_Store_Management_System.Models;

namespace TallyBook_Test_UserController
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_UserLogin()
        {
            //Arrange
            UserController controller = new UserController();
            //Act
            ViewResult result = controller.Login() as ViewResult;
            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestDashboard()
        {
            UserController controller = new UserController();
            CreateMockSession(controller);

            ViewResult result = controller.Dashboard() as ViewResult;

            try
            {
                Assert.AreEqual("Welcome to Dashboard", controller.ViewBag.Msg);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_ViewInventory()
        {
            var inventory = new List<Inventory>() {
                    new Inventory(){id=28, name="Rice",quantity= 45, price=35.0000},
                    new Inventory(){id=29, name="Egg",quantity= 144, price=8.0000},
                    new Inventory(){id=30, name="Flour",quantity= 50, price=40.0000}
                };


            UserController controller = new UserController();
            CreateMockSession(controller);

            ViewResult result = controller.ViewInventory() as ViewResult;

            try
            {
                Assert.AreEqual(inventory, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_UpdateInventory()
        {
            var inventory = new List<Inventory>() {
                    new Inventory(){id=28, name="Rice",quantity= 45, price=35.0000},
                    new Inventory(){id=29, name="Egg",quantity= 144, price=8.0000}
                    
                };


            UserController controller = new UserController();
            CreateMockSession(controller);
            inventory.Add(new Inventory() { id = 30, name = "Flour", quantity = 50, price = 40.0000 });
            
            ViewResult result = controller.UpdateInventory() as ViewResult;

            try
            {
                Assert.AreEqual(inventory, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_EditInventory()
        {
            var inventory = new List<Inventory>() {
                    new Inventory(){id=28, name="Rice",quantity= 40, price=45.0000},
                    new Inventory(){id=29, name="Egg",quantity= 144, price=8.0000},
                    new Inventory(){id=30, name="Flour",quantity= 50, price=40.0000}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new InventoryTb();
            ViewResult result = controller.EditInventory(28,inv) as ViewResult;
            inventory = new List<Inventory>() {
                    new Inventory(){id=28, name="Rice",quantity= 45, price=35.0000},
                    new Inventory(){id=29, name="Egg",quantity= 144, price=8.0000},
                    new Inventory(){id=30, name="Flour",quantity= 50, price=40.0000}
                };

            try
            {
                Assert.AreEqual(inventory, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_DeleteInventory()
        {
            var inventory = new List<Inventory>() {
                    new Inventory(){id=28, name="Rice",quantity= 40, price=45.0000},
                    new Inventory(){id=29, name="Egg",quantity= 144, price=8.0000},
                    new Inventory(){id=30, name="Flour",quantity= 50, price=40.0000},
                     new Inventory(){id=40, name="Four",quantity= 5, price=30.0000}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new InventoryTb();
            ViewResult result = controller.DeleteInventory(40, inv) as ViewResult;
            
            inventory.RemoveAt(3);

            try
            {
                Assert.AreEqual(inventory, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_ViewSupplier()
        {
            var supply = new List<People>() {
                    new People(){id=4, name="Tahmid", Num= "01879514785"}  
                };


            UserController controller = new UserController();
            CreateMockSession(controller);

            ViewResult result = controller.ViewSupplier() as ViewResult;

            try
            {
                Assert.AreEqual(supply, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_UpdateSupplier()
        {
            var supply = new List<People>() {
                    new People(){id=4, name="Tahmid", Num= "01879514785"}
                };


            UserController controller = new UserController();
            CreateMockSession(controller);
            supply.Add(new People() { id = 5, name = "Raphael", Num = "01477814785" });

            ViewResult result = controller.UpdateSupplier() as ViewResult;

            try
            {
                Assert.AreNotEqual(supply, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_EditSupplier()
        {
            var supply = new List<People>() {
                    new People(){id=4, name="Taid", Num= "01879514785"}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new SupplierTb();
            ViewResult result = controller.EditSupplier(28, inv) as ViewResult;
            supply = new List<People>() {
                    new People(){id=4, name="Tahmid", Num= "01879514785"}
                };

            try
            {
                Assert.AreEqual(supply, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_DeleteSupplier()
        {
            var supply = new List<People>() {
                    new People(){id=4, name="Tahmid", Num= "01879514785"},
                    new People(){id=5, name="mid", Num= "01679514874"}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new SupplierTb();
            ViewResult result = controller.DeleteSupplier(5, inv) as ViewResult;

            supply.RemoveAt(1);

            try
            {
                Assert.AreEqual(supply, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_ViewCustomer()
        {
            var supply = new List<People>() {
                    new People(){id=22, name="Nizam", Num= "01998756475"}
                };


            UserController controller = new UserController();
            CreateMockSession(controller);

            ViewResult result = controller.ViewCustomer() as ViewResult;

            try
            {
                Assert.AreEqual(supply, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_UpdateCustomer()
        {
            var supply = new List<People>() {
                   new People(){id=22, name="Nizam", Num= "01998756475"}
                };


            UserController controller = new UserController();
            CreateMockSession(controller);
            supply.Add(new People() { id = 5, name = "Raphael", Num = "01477814785" });

            ViewResult result = controller.UpdateCustomer() as ViewResult;

            try
            {
                Assert.AreNotEqual(supply, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_EditCustomer()
        {
            var supply = new List<People>() {
                    new People(){id=22, name="Niam", Num= "01998756475"}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new CustomerTb();
            ViewResult result = controller.EditCustomer(28, inv) as ViewResult;
            supply = new List<People>() {
                    new People(){id=22, name="Nizam", Num= "01998756475"}
                };

            try
            {
                Assert.AreEqual(supply, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_DeleteCustomer()
        {
            var supply = new List<People>() {
                    new People(){id=22, name="Nizam", Num= "01998756475"},
                    new People(){id=24, name="Izam", Num= "01459056475"}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new CustomerTb();
            ViewResult result = controller.DeleteCustomer(24, inv) as ViewResult;

            supply.RemoveAt(1);

            try
            {
                Assert.AreEqual(supply, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_ViewInvoice()
        {
            var invoice = new List<Invoice>() {
                    new Invoice(){id=28, name="Rice",quantity= 8, price=280.0000},
                    new Invoice(){id=29, name="Egg",quantity= 10, price=80.0000}
                };


            UserController controller = new UserController();
            CreateMockSession(controller);
            double total=invoice.Sum(item => item.price);
            ViewResult result = controller.ViewInventory() as ViewResult;

            try
            {
                Assert.AreEqual(total, controller.ViewBag.Total);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_UpdateInvoice()
        {
            var invoice = new List<Invoice>() {
                    new Invoice(){id=28, name="Rice",quantity= 8, price=280.0000}
                    
                };


            UserController controller = new UserController();
            CreateMockSession(controller);
            invoice.Add(new Invoice() { id = 29, name = "Egg", quantity = 10, price = 80.0000 });

            ViewResult result = controller.UpdateInvoice() as ViewResult;

            try
            {
                Assert.AreEqual(invoice, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_EditInvoice()
        {
            var invoice = new List<Invoice>() {
                     new Invoice(){id=28, name="Rice",quantity= 8, price=280.0000},
                    new Invoice(){id=29, name="Egg",quantity= 9, price=72.0000}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new InvoiceTb();
            ViewResult result = controller.EditInvoice(28, inv) as ViewResult;
            invoice = new List<Invoice>() {
                     new Invoice(){id=28, name="Rice",quantity= 8, price=280.0000},
                    new Invoice(){id=29, name="Egg",quantity= 10, price=80.0000}
                };

            try
            {
                Assert.AreEqual(invoice, controller.ViewBag.data);
                
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_DeleteInvoice()
        {
            var invoice = new List<Invoice>() {
                     new Invoice(){id=28, name="Rice",quantity= 8, price=280.0000},
                    new Invoice(){id=29, name="Egg",quantity= 10, price=80.0000},
                    new Invoice(){id=30, name="Bread",quantity= 10, price=30.0000}
                };
            UserController controller = new UserController();
            CreateMockSession(controller);
            var inv = new InvoiceTb();
            ViewResult result = controller.DeleteInvoice(30,inv) as ViewResult;

            invoice.RemoveAt(2);

            try
            {
                Assert.AreEqual(invoice, controller.ViewBag.data);
               
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_userLogout()
        {
            //Arrange
            UserController controller = new UserController();
            CreateMockSessionOut(controller);
            //Act
            ViewResult result = controller.Logout() as ViewResult;
            //Assert
            Assert.IsNull(result);

        }


        public void CreateMockSession(UserController controller)
        {
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            controller.Session["User"] = 1;
        }

        public void CreateMockSessionOut(UserController controller)
        {
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            controller.Session["User"] = null;
        }

        public class Inventory{
            public int id { get; set; }
            public string name { get; set; }
            public int quantity { get; set; }
            public double price { get; set; }

        }

        public class People
        {
            public int id { get; set; }
            public string name { get; set; }
            public String Num { get; set; }
        }

        public class Invoice
        {
            public int id { get; set; }
            public string name { get; set; }
            public int quantity { get; set; }
            public double price { get; set; }
        }

    }

    
}

