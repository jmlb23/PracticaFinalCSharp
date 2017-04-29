using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Sql;
using System.Data.Common;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service : IService
    {

        public List<Cliente> GetClients(string id)
        {
            
            return DataAcess.Set.Tables["Cliente"].Select().Where(row => id == null ? true : row[0].Equals(id)).Select(row => new Cliente { CustomerID = row[0].ToString(),
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

        }
    }
}
