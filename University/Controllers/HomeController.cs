using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Университет - Стартовая страница";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //TODO: add navigation in View
            ViewBag.Title = "Университет - Логин";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAuthViewModel userAuth)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataModel())
                {
                    var user = (from u in db.Users
                                where userAuth.Login == u.Login && userAuth.Password == u.Password
                                select u).FirstOrDefault();

                    //Check, if user exists in database
                    if (user == null)
                    {
                        return RedirectToAction("UserNotFound", "Home");
                    }

                    //Check, if account is administrative
                    if (user.AdminAccount)
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    var student = (from s in db.Students
                                   where user.ID == s.UserID
                                   select s).FirstOrDefault();

                    var teacher = (from t in db.Teachers
                                   where user.ID == t.UserID
                                   select t).FirstOrDefault();

                    //Check, if user is student
                    if (student != null)
                    {
                        return RedirectToAction("Index", "Student");
                    }

                    //Check, if user is teacher
                    if (teacher != null)
                    {
                        return RedirectToAction("Index", "Teacher");
                    }

                    return RedirectToAction("UserNotFound", "Home");
                }
            }
            else
            {
                ViewBag.Title = "Университет - Логин";
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserNotFound()
        {
            ViewBag.Title = "Университет - Пользователь не найден";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            ViewBag.Title = "Университет - Восстановление пароля";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(PasswordRecoveryViewModel passRecovery)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataModel())
                {
                    var user = (from u in db.Users
                                where u.Email == passRecovery.Email
                                select u).FirstOrDefault();

                    if (user != null)
                    {
                        MailMessage mail = new MailMessage();

                        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                        smtpServer.Credentials = new System.Net.NetworkCredential("university.system.mailer", "ptkbycrbq");
                        smtpServer.EnableSsl = true;
                        smtpServer.Port = 587; // Gmail works on this port

                        mail.From = new MailAddress("university.system.mailer@gmail.com");
                        mail.To.Add(passRecovery.Email);
                        mail.Subject = "University System - Password recovery";
                        mail.Body = "Your login: " + user.Login + "\n" + "Your password: " + user.Password;

                        try
                        {
                            smtpServer.Send(mail);
                        }
                        catch
                        {
                            return RedirectToAction("SendMailFailure", "Home");
                        }

                        return RedirectToAction("SendMailSuccess", "Home");
                    }
                    else
                    {
                        return RedirectToAction("EmailNotFound", "Home");
                    }
                }
            }
            else
            {
                ViewBag.Title = "Университет - Восстановление пароля";
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SendMailFailure()
        {
            ViewBag.Title = "Университет - Ошибка отправки e-mail";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SendMailSuccess()
        {
            ViewBag.Title = "Университет - Письмо отправлено";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult EmailNotFound()
        {
            ViewBag.Title = "Университет - Адрес не найден";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Title = "Университет - Регистрация";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AddTeacher()
        {
            using (var db = new DataModel())
            {
                List<SelectListItem> dept = new List<SelectListItem>();
                var query = from u in db.Departments select u;
                if (query.Count() > 0)
                {
                    foreach (var v in query)
                    {
                        dept.Add(new SelectListItem { Text = v.Name, Value = v.ID.ToString() });
                    }
                }
                ViewBag.Departments = dept;
                ViewBag.Title = "Университет - Регистрация преподавателя";
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadCathedrasByDepartment(string deptId)
        {
            using (var db = new DataModel())
            {
                //Your Code For Getting Physicans Goes Here
                //var phyList = this.GetPhysicans(Convert.ToInt32(deptId));
                var cathList = from c in db.Cathedras
                              where c.DepartmentID == Convert.ToInt32(deptId)
                              select c;

                List<SelectListItem> cathData = new List<SelectListItem>();
                foreach (var c in cathList)
                {
                    cathData.Add(new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.ID.ToString()
                    });
                }


                //var phyData = classesList.Select(m => new SelectListItem()
                //{
                //    Text = m.phyName,
                //    Value = m.phyId.ToString(),
                //});

                return Json(cathData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
