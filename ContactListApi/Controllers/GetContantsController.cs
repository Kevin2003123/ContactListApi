using ContactListApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactListApi.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class GetContantsController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public dynamic GetContacts()
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact{
                    Id = 1,
                    Name="sad",
                    LastName="asdasd",
                    Email="sadasdasd@asdasd",
                    Cellphone="123434",
                    dateOfRegistration =DateTime.Now,
                },new Contact{
                    Id = 2,
                    Name="sad",
                    LastName="asdasd",
                    Email="sadasdasd@asdasd",
                    Cellphone="123434",
                    dateOfRegistration =DateTime.Now,
                }
            };

            return contacts;
        }
    }
}