﻿namespace ContactListApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public DateTime dateOfRegistration { get; set; }
    }
}