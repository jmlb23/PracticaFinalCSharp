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
            var list = DataAcess.Set.Tables["Cliente"]
                .Select()
                .Where(row => id == "ALL" ? true : row[0].Equals(id))
                .Select(row =>
                    new Cliente
                    {
                        CustomerID = row[0].ToString(),
                        CompanyName = row[1].ToString(),
                        ContactName = row[2].ToString(),
                        ContactTitle = row[3].ToString(),
                        Address = row[4].ToString(),
                        City = row[5].ToString(),
                        Region = row[6].ToString(),
                        PostalCode = row[7].ToString(),
                        Country = row[8].ToString(),
                        Phone = row[9].ToString(),
                        Fax = row[10].ToString()
                    }
                ).ToList();
            var resp = context.Response;
            var jss = new JavaScriptSerializer();
            var jsonString = jss.Serialize(list);
            resp.ContentType = "application/json";
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