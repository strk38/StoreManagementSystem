using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallyBook_Store_Management_System.Models;


namespace TallyBook_Store_Management_System.Controllers
{
    public class UserController : Controller
    {
        DbEntities db = new DbEntities();
        int i;

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserTb user)
        {
            if (db.UserTbs.Any(a => a.UName.Equals(user.UName) || a.UEmail.Equals(user.UEmail)))
            {
                ViewBag.error = "User already Exist";
                return RedirectToAction("SignUp");
            }
            else
            {
                db.UserTbs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserTb user)
        {

            var verify = db.UserTbs.Where(a => a.UEmail.Equals(user.UEmail) && a.UPassword.Equals(user.UPassword)).SingleOrDefault();

            if (verify != null)
            {
                Session["User"] = verify.UId;
                i = verify.UId;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.error = "Password or Email is Wrong";
                return View(ViewBag.error);
            }

        }

        public ActionResult Dashboard()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult ViewInventory()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {    //need uid query
                /*var inv= (from str in db.InventoryTbs where str.User==i select str).ToList() ;
                ViewBag.data = inv;*/
                return View(db.InventoryTbs.ToList());
            }
        }

        public ActionResult UpdateInventory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateInventory(InventoryTb idetail)
        {

            if (Session["User"] == null) 
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    db.InventoryTbs.Add(idetail);
                    db.SaveChanges();
                    return RedirectToAction("ViewInventory");
                }
                catch
                {
                    return View();
                }
            }
        }
        public ActionResult EditInventory(int id)
        {
            return View(db.InventoryTbs.Where(a => a.PId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditInventory(int id, InventoryTb inventory)
        {
            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    db.Entry(inventory).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ViewInventory");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult DeleteInventory(int id)
        {
            return View(db.InventoryTbs.Where(a => a.PId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeleteInventory(int id, InventoryTb inventory)
        {
            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {

                    db.InventoryTbs.Remove(db.InventoryTbs.Where(a => a.PId == id).FirstOrDefault());
                    db.SaveChanges();
                    return RedirectToAction("ViewInventory");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult ViewSupplier()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(db.SupplierTbs.ToList());
            }
        }
        public ActionResult UpdateSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSupplier(SupplierTb sdetail)
        {

            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    db.SupplierTbs.Add(sdetail);
                    db.SaveChanges();
                    return RedirectToAction("ViewSupplier");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult EditSupplier(int id)
        {
            return View(db.SupplierTbs.Where(a => a.SId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditSupplier(int id, SupplierTb sList)
        {
            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    db.Entry(sList).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ViewSupplier");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult DeleteSupplier(int id)
        {
            return View(db.SupplierTbs.Where(a => a.SId == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult DeleteSupplier(int id, SupplierTb sData)
        {
            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {

                    db.SupplierTbs.Remove(db.SupplierTbs.Where(a => a.SId == id).FirstOrDefault());
                    db.SaveChanges();
                    return RedirectToAction("ViewSupplier");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult ViewCustomer()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(db.CustomerTbs.ToList());
            }
        }

        public ActionResult UpdateCustomer()
        {
            /*var v = db.UserTbs.Where(a => a.UId == id).Select(a => a.UId).SingleOrDefault();*/
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCustomer(CustomerTb cdetail)
        {
            //var v = db.UserTbs.Where(a => a.UId == i).FirstOrDefault();//1
            //var i = db.UserTbs.Select(a=>a.UId);

            if (Session["User"] == null) // works need message
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    //cdetail.User = i;
                    db.CustomerTbs.Add(cdetail);
                    db.SaveChanges();
                    return RedirectToAction("ViewCustomer");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult EditCustomer(int id)
        {
            return View(db.CustomerTbs.Where(a => a.CId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditCustomer(int id, CustomerTb cList)
        {
            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    db.Entry(cList).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ViewCustomer");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult DeleteCustomer(int id)
        {
            return View(db.CustomerTbs.Where(a => a.CId == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult DeleteCustomer(int id, CustomerTb cData)
        {
            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {

                    db.CustomerTbs.Remove(db.CustomerTbs.Where(a => a.CId == id).FirstOrDefault());
                    db.SaveChanges();
                    return RedirectToAction("ViewCustomer");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult ShowInvoice() {
            if (Session["User"] == null) 
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Total =db.InvoiceTbs.Sum(s => s.Bill);
                return View(db.InvoiceTbs.ToList());
            }
        }
             
        public ActionResult UpdateInvoice()
        {
            if (Session["User"] == null) //doesnt work
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    var getProduct = db.InventoryTbs.ToList();
                    SelectList list = new SelectList(getProduct, "PId", "PName", "PPrice");
                    ViewBag.Product = list;
                    return View();
                }
                catch
                {
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult UpdateInvoice(InvoiceTb idetail)
        {

            if (Session["User"] == null) 
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    string strDDLValue = Request.Form["Product"].ToString();

                    int ddl = Int32.Parse(strDDLValue);
                    var item = (from Invent in db.InventoryTbs where Invent.PId == ddl select Invent.PName).FirstOrDefault();
                    string product = item.ToString();

                    var cost = (from Invent in db.InventoryTbs where Invent.PId == ddl select Invent.PPrice).FirstOrDefault();
                    decimal price=Convert.ToDecimal(cost);

                    idetail.ListName = product;
                    idetail.Bill =idetail.LQuantity*price;
                    db.InvoiceTbs.Add(idetail);
                    db.SaveChanges();
                    return RedirectToAction("ShowInvoice");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult DeleteInvoice(int id)
        {
            return View(db.InvoiceTbs.Where(a => a.InvoiceId == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult DeleteInvoice(int id, InvoiceTb iData)
        {
            if (Session["User"] == null) 
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {

                    db.InvoiceTbs.Remove(db.InvoiceTbs.Where(a => a.InvoiceId == id).FirstOrDefault());
                    db.SaveChanges();
                    return RedirectToAction("ShowInvoice");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult EditInvoice(int id)
        {
            return View(db.InvoiceTbs.Where(a => a.InvoiceId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditInvoice(int id, InvoiceTb invoice)
        {
            if (Session["User"] == null) 
            {
                return RedirectToAction("Login");
            }
            else
            {
                try
                {
                    var cost = (from Invent in db.InventoryTbs where Invent.PId == id select Invent.PPrice).FirstOrDefault();
                    decimal price = Convert.ToDecimal(cost);

                    
                    invoice.Bill = invoice.LQuantity * price;

                    db.Entry(invoice).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ShowInvoice");
                }
                catch
                {
                    return View();
                }
            }
        }

    }

}
