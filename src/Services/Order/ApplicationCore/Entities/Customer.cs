﻿namespace ApplicationCore.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string ProfilePic { get; set; }
        public Guid UserId { get; set; }
        
        // public ICollection<Address> Address { get; set; }
    }
}
