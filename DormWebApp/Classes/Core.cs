using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DormWebApp.Classes
{
    public class Core
    {
        #region
        public enum Roles
        {
            Admin = 1,
            User = 2,
        }
        #endregion
        #region Properties
        public static HttpContext GlobalHttpContext { get; set; }
        public static System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                System.Web.SessionState.HttpSessionState mySession = null;
                if(System.Web.HttpContext.Current != null)
                {
                    mySession = System.Web.HttpContext.Current.Session;
                }
                return mySession;
            }
        }
        public static System.Web.Caching.Cache Cache
        {
            get
            {
                return System.Web.HttpContext.Current.Cache;
            }
        }
        public static System.Web.HttpApplicationState Application
        {
            get
            {
                return System.Web.HttpContext.Current.Application;
            }
        }
        public static System.Web.HttpServerUtility Server
        {
            get
            {
                return System.Web.HttpContext.Current.Server;
            }
        }
        #endregion
    }
}