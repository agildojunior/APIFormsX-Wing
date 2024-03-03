using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFormsX_Wing.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Poll")]
        public int PollId { get; set; }
        public string QuestionText { get; set; }
        public string Type { get; set; }
    }
}