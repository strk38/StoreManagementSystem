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

namespace TallyBook_UnitTest
{
    [TestClass]
    public class Test_AdminController
    {
        [TestMethod]
        public void Test_Login()
        {
            //Arrange
            AdminController controller = new AdminController();
            //Act
            ViewResult result = controller.AdminLogin() as ViewResult;
            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestDashboard()
        {
            AdminController controller = new AdminController();
            CreateMockSession(controller);

            ViewResult result = controller.AdminDashboard() as ViewResult;

            try
            {
                Assert.AreEqual("Welcome to Admin Dashboard", controller.ViewBag.Msg);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_ViewAdmin()
        {
            var admins = new List<Admins>() {
                    new Admins(){id=1, name="Admin1", Email= "admin1@gmail.com",Password="admin1234"},
                    new Admins(){id=3, name="Admin2", Email= "admin2@gmail.com",Password="admin321"}
                };

            AdminController controller = new AdminController();
            CreateMockSession(controller);

            ViewResult result = controller.ViewAdmin() as ViewResult;

            try
            {
                Assert.AreEqual(admins, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_UpdateAdmin()
        {
            var admins = new List<Admins>() {
                    new Admins(){id=1, name="Admin1", Email= "admin1@gmail.com",Password="admin1234"}
                    
                };


            AdminController controller = new AdminController();
            CreateMockSession(controller);
            admins.Add(new Admins() { id = 3, name = "Admin2", Email = "admin2@gmail.com", Password = "admin321" });

            ViewResult result = controller.UpdateAdmin() as ViewResult;

            try
            {
                Assert.AreNotEqual(admins, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_EditAdmin()
        {
            var admins = new List<Admins>() {
                    new Admins(){id=1, name="Admin1", Email= "admin1@gmail.com",Password="admin1234"},
                    new Admins(){id=3, name="Admin3", Email= "admin3@gmail.com",Password="admin321"}
                };
            AdminController controller = new AdminController();
            CreateMockSession(controller);
            var adm = new AdminTb();
            ViewResult result = controller.EditAdmin(3, adm) as ViewResult;
            admins = new List<Admins>() {
                    new Admins(){id=1, name="Admin1", Email= "admin1@gmail.com",Password="admin1234"},
                    new Admins(){id=3, name="Admin2", Email= "admin2@gmail.com",Password="admin321"}
                };

            try
            {
                Assert.AreEqual(admins, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_DeleteAdmin()
        {
            var admins = new List<Admins>() {
                    new Admins(){id=1, name="Admin1", Email= "admin1@gmail.com",Password="admin1234"},
                    new Admins(){id=3, name="Admin2", Email= "admin2@gmail.com",Password="admin321"},
                    new Admins(){id=4, name="Admin3", Email= "admin3@gmail.com",Password="admin3214"}
                };
            AdminController controller = new AdminController();
            CreateMockSession(controller);
            var inv = new AdminTb();
            ViewResult result = controller.DeleteAdmin(4, inv) as ViewResult;

            admins.RemoveAt(2);

            try
            {
                Assert.AreEqual(admins, controller.ViewBag.msg);
                //Debug.WriteLine("Success");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_ViewUser()
        {
            var users = new List<Users>() {
                    new Users(){id=1, name="Ash", Email= " user1@gmail.com", Shopname="Ash Shop"},
                    new Users(){id=2, name="Tahmid", Email= "tahmid@gmail.com", Shopname="Akatski"},
                    new Users(){id=4, name="Tahmid Ibnul", Email= "ibnul@gmail.com", Shopname="Ta Store"}
                };

            AdminController controller = new AdminController();
            CreateMockSession(controller);

            ViewResult result = controller.ViewUser() as ViewResult;

            try
            {
                Assert.AreEqual(users, controller.ViewBag.data);
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }

        [TestMethod]
        public void Test_Logout()
        {
            //Arrange
            AdminController controller = new AdminController();
            CreateMockSessionOut(controller);
            //Act
            ViewResult result = controller.AdminLogout() as ViewResult;
            //Assert
            Assert.IsNull(result);

        }

        public void CreateMockSession(AdminController controller)
        {
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            controller.Session["Admin"] = 1;
        }

        public void CreateMockSessionOut(AdminController controller)
        {
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            controller.Session["Admin"] = null;
        }

        public class Admins
        {
            public int id { get; set; }
            public string name { get; set; }
            public String Email { get; set; }
            public String Password { get; set; }
        }

        public class Users
        {
            public int id { get; set; }
            public string name { get; set; }
            public String Email { get; set; }
            public String Shopname { get; set; }
        }
    }
}
