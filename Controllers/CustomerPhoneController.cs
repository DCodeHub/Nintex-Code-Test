using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIForCustomerTelephone.Model;

namespace APIForCustomerTelephone.Controllers
{
    public class CustomerPhoneController : ApiController
    {
        private CustomerPhoneEntities db = new CustomerPhoneEntities();

        // GET: api/CustomerPhone
        public IQueryable<CustomerPhone> GetCustomerPhones()
        {
            return db.CustomerPhones;
        }

        // GET: api/CustomerPhone/5
        [ResponseType(typeof(CustomerPhone))]
        public IHttpActionResult GetCustomerPhone(int id)
        {
            CustomerPhone customerPhone = db.CustomerPhones.Find(id);
            if (customerPhone == null)
            {
                return NotFound();
            }

            return Ok(customerPhone);
        }

        // PUT: api/CustomerPhone/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerPhone(int id, CustomerPhone customerPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerPhone.phoneId)
            {
                return BadRequest();
            }

            db.Entry(customerPhone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerPhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerPhone
        [ResponseType(typeof(CustomerPhone))]
        public IHttpActionResult PostCustomerPhone(CustomerPhone customerPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerPhones.Add(customerPhone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerPhone.phoneId }, customerPhone);
        }

        // DELETE: api/CustomerPhone/5
        [ResponseType(typeof(CustomerPhone))]
        public IHttpActionResult DeleteCustomerPhone(int id)
        {
            CustomerPhone customerPhone = db.CustomerPhones.Find(id);
            if (customerPhone == null)
            {
                return NotFound();
            }

            db.CustomerPhones.Remove(customerPhone);
            db.SaveChanges();

            return Ok(customerPhone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerPhoneExists(int id)
        {
            return db.CustomerPhones.Count(e => e.phoneId == id) > 0;
        }
    }
}