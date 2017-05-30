using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Sql;
using System.Data.Common;
using DataAccess;


namespace WcfService
{
    public class Service : IService
    {

        public List<Cliente> GetClients(string id)
        {
            
            return DataAcess.Set.Tables["Cliente"]
                .Select()
                .Where(row => id == null || id == "" ? true : row[0].Equals(id))
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

        }
    }
}
