using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIForCustomerTelephone.Model;

namespace APIForCustomerTelephone.Controllers
{
    public class CustTelephoneController : ApiController
    {
        private CustomerPhoneEntities dbContext = new CustomerPhoneEntities();

    
        [HttpGet]
        public List<CustomerPhone> GetAllTelephoneNumbers()
        {
            return dbContext.CustomerPhones.ToList();
        }


        [HttpGet]

        public string[] GetTelephoneNumbersByCustomer(int customerID)
        {
            return dbContext.CustomerPhones.Select(c => c.customerPhone).ToArray();
        }


        [HttpPost]

        public void AddTelephoneNumbers(int customerID, string phoneNumber)
        {
            var p = new CustomerPhone { customerPhone = phoneNumber, customerId = customerID };
            dbContext.CustomerPhones.Add(p);
            dbContext.SaveChanges();

        }

        /// <summary>
        /// Activate Telephone number for a customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void ActivateTelephoneNumbers(int customerID, string phoneNumber, string status)
        {
            using (var db = new CustomerPhoneEntities())
            {
                var result = db.CustomerPhones.SingleOrDefault(b => b.customerId == customerID);
                if (result != null)
                {
                    try
                    {
                        db.CustomerPhones.Attach(result);
                        result.customerId = customerID;
                        result.phoneStaus = status;
                        db.Entry(result).State = System.Data.Entity.EntityState.Modified; 
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            //var p = new CustomerPhone { customerPhone = phoneNumber, customerId = customerID, phoneStaus = status };
            //dbContext.CustomerPhones.Attach(p);
            //dbContext.Entry(p).State = System.Data.Entity.EntityState.Modified;
            //dbContext.SaveChanges();
        }
    }
}
