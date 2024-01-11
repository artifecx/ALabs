using System.ComponentModel.DataAnnotations;

namespace ALabs.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // User Score
        public int userScore { get; set; }

        // Lesson 1
        public int lesson1progress { get; set; }

        // Lesson 2
        public int challengeprogress { get; set; }
        public int lesson2progress { get; set; }

        
    }
}