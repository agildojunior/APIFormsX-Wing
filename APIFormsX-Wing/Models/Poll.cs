using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFormsX_Wing.Models
{
    public class Poll
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }

        // User navigation property
        public User User { get; set; }
    }
}