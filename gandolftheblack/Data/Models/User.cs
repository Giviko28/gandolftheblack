﻿using System.ComponentModel.DataAnnotations;

namespace gandolftheblack.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } 

        [Required]
        public string Role { get; set; }
    }
}
