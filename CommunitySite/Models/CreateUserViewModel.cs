﻿
using System.ComponentModel.DataAnnotations;

namespace CommunitySite.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
