using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFormsX_Wing.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("Answeroption")]
        public int AnsweroptionId { get; set; }
        public string AnswerText { get; set; }
    }
}