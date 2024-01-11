﻿using System.ComponentModel.DataAnnotations;

namespace ALabs.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int challengeprogress { get; set; }
        public int lesson2progress { get; set; }


    }
}