using DormWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DormWebApp.Classes
{
    public class DormIdentity
    {
        public static User CurrentUser { get; set; }
        public Role Role { get; set; }
        public Boolean IsSuperUser { get; set; }
        public string Language { get; set; }

        public System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                System.Web.SessionState.HttpSessionState mySession = null;
                if(System.Web.HttpContext.Current != null)
                    mySession = System.Web.HttpContext.Current.Session;
                
                return mySession;
            }
        }
        public static DormIdentity Current
        {
            get
            {
                if(Core.Session["Identity"] == null)
                {
                    Core.Session["Identity"] = new DormIdentity();
                }
                return (DormIdentity)Core.Session["Identity"];
            }
            set
            {
                Core.Session["Identity"] = value;
            }
        }
    }

}