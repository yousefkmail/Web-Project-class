using System.ComponentModel.DataAnnotations;

namespace Web_Project.Models
{
    public class Admin
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Admin name.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Admin password.")]

        public string Password { get; set; }
    }
}
