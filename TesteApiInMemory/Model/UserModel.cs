using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteApiInMemory.Model
{
    public class UserModel
    {
        public int UserModelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public virtual Address Address { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public int UserModelId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zipcode { get; set; }
    }
}
