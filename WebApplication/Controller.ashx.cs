using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DataAccess;

namespace WebApplication
{
    public class Controller : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request.Params["id"];
            var list = DataAcess.Set.Tables["Cliente"].Select().Where(row => id == "ALL" ? true : row[0].Equals(id)).Select(row => new Cliente
            {
                CustomerID = row[0].ToString(),
                CompanyName = row[1].ToString(),
                ContactTitle = row[2].ToString(),
                Address = row[3].ToString(),
                City = row[4].ToString(),
                Region = row[5].ToString(),
                PostalCode = row[6].ToString(),
                Country = row[7].ToString(),
                Phone = row[8].ToString(),
                Fax = row[9].ToString()
            }).ToList();
            var resp = context.Response;
            var jss = new JavaScriptSerializer();
            var jsonString = jss.Serialize(list);
            resp.ContentType = "application/javascript";
            resp.Write(jsonString);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}