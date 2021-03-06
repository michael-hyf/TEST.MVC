﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST.MVC.IBLL;
using TEST.MVC.Web.Models;

namespace TEST.MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userSvc = BLLContainer.Container.Resolve<IUserService>();

        [ValidateInput(false)]
        public ActionResult Index(FormCollection fc)
        {
            var content = fc["editor"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetAllUsers(int curPage = 1, int pageSize = 10)
        {
            int total = userSvc.GetModels(u => true).Count();
            var pages = new PageList(curPage, total, pageSize);
            var list = (from u in userSvc.GetModelsByPage(pageSize, curPage, true, u => u.Id, u => true).ToList()
                        select new
                        {
                            Name = u.Name,
                            Id = u.Id
                        }).ToList();
            var data = new { list = list, pages = pages };
            return View("~/Views/UserApi/Index.cshtml", data);
        }
    }
}