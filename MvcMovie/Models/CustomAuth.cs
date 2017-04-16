﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;

namespace MvcMovie.Models
{
    public class CustomAuth : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                filterContext.Result = new RedirectResult("~/Unauthorized/Index");
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
               
            }
        }
    }
}
