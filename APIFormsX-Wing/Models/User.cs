using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFormsX_Wing.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool Active { get; set; }
        public bool Administrator { get; set; }
        public string Password { get; set; }
    }
}
