using ContactListApi.Data;
using ContactListApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactListApi.Controllers
{
    [Route("contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Contact> Get()
        {
            return ContactData.GetAllContacts();
        }
        
        [HttpGet]
        [Route("page")]
        public List<Contact> Get(int PageNumber, string Order, string OrderBy)
        {
            return ContactData.GetContactsPerPage(PageNumber, Order, OrderBy);
        }


        [HttpGet]
        [Route("search")]
        public List<Contact> Get(int PageNumber,string SearchTerm ,string Order, string OrderBy)
        {
            return ContactData.SearchContactsPerPage(PageNumber,SearchTerm,Order, OrderBy);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return ContactData.GetContactById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool Post([FromBody] Contact contact)
        {
            return ContactData.InsertContact(contact);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public bool Put([FromBody] Contact contact)
        {
            return ContactData.UpdateContact(contact);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return ContactData.DeleteContact(id);
        }
    }
}