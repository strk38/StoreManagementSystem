using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallyBook_Store_Management_System.Models;

namespace TallyBook_Store_Management_System.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbEntities db = new DbEntities();
        // GET: User
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminTb admin)
        {
            var verify = db.AdminTbs.Where(a => a.Email.Equals(admin.Email) && a.Password.Equals(admin.Password)).SingleOrDefault();
            if (verify != null)
            {
                Session["Admin"] = verify.Id;
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                ViewBag.error = "Password or Email is Wrong";
                return View();
            }

        }
        public ActionResult AdminDashboard()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                return View();
            }

        }
        public ActionResult ViewAdmin()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                return View(db.AdminTbs.ToList());
            }
        }

        public ActionResult UpdateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateAdmin(AdminTb aDetail)
        {

            if (Session["Admin"] == null) 
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                try
                {
                    db.AdminTbs.Add(aDetail);
                    db.SaveChanges();
                    return RedirectToAction("ViewAdmin");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult EditAdmin(int id)
        {
            return View(db.AdminTbs.Where(a => a.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditAdmin(int id, AdminTb adEdit)
        {
            if (Session["Admin"] == null) 
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                try
                {
                    db.Entry(adEdit).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ViewAdmin");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult DeleteAdmin(int id)
        {
            return View(db.AdminTbs.Where(a => a.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeleteAdmin(int id, AdminTb adDetail)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                try
                {

                    db.AdminTbs.Remove(db.AdminTbs.Where(a => a.Id == id).FirstOrDefault());
                    db.SaveChanges();
                    return RedirectToAction("ViewAdmin");
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult AdminLogout()
        {
            Session.Abandon();
            return RedirectToAction("AdminLogin");
        }

        public ActionResult ViewUser()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                return View(db.UserTbs.ToList());
            }
        }
    }



}