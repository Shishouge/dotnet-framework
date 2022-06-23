using CodeDLL;
using login_CLR.Models;
using login_CLR.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace login_CLR.Controllers
{
    [RoutePrefix("api/index")]
    public class IndexController : ApiController
    {
        AdminRepo admin = new AdminRepo();
        [HttpGet]
        [Route("Encode")]
        public string Encode(string str)
        {
            unsafe
            {
                
                string s = str;
                IntPtr intPtrStr = (IntPtr)Marshal.StringToHGlobalAnsi(s);
                sbyte* sbyteStr = (sbyte*)intPtrStr;
                sbyte* result = code.Encode(sbyteStr);
                string tmp = new string(result);
                return tmp;
            }
        }

        [HttpGet]
        [Route("Decode")]
        public IHttpActionResult Decode(string str)
        {
            unsafe
            {
                string s = str;
                IntPtr intPtrStr = (IntPtr)Marshal.StringToHGlobalAnsi(s);
                sbyte* sbyteStr = (sbyte*)intPtrStr;
                sbyte* result = code.Decode(sbyteStr);
                string tmp = new string(result);
                return Json(tmp);
            }


        }

        [HttpGet]
        [Route("login")]
        public IHttpActionResult login(int ID, string password)
        {
            string pcode = Encode(password);
            List<admin> admins = admin.login(ID,pcode);
            System.Diagnostics.Debug.Write(admins.Count);
            System.Diagnostics.Debug.Write(ID);
            System.Diagnostics.Debug.Write(password);
            
            if (admins.Count == 1)
                return Json(true);
            return Json(false);
            
        }
    }
}
