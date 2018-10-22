using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    public class PostWedding : BaseEntity
    {
        [Key]
        public int wedding_id {get;set;}
        [Required(ErrorMessage="Wedder One is required")]
        [MinLength(2, ErrorMessage="Wedder One has a min length of 3")]
        [MaxLength(15, ErrorMessage="Wedder One has a max length of 15")]
        public string wedder_one {get;set;}
        [Required(ErrorMessage="Wedder Two is required")]
        [MinLength(2, ErrorMessage="Wedder Two has a min length of 3")]
        [MaxLength(15, ErrorMessage="Wedder Two has a max length of 15")]
        public string wedder_two {get;set;}
        [Required(ErrorMessage="Event Date is required")]
        public DateTime event_date {get;set;}
        [Required(ErrorMessage="Address is required")]
        [MinLength(5, ErrorMessage="Adress has a min length of 5")]
        [MaxLength(30, ErrorMessage="Address has a max length of 30")]
        public string address {get;set;}
        public int user_id {get;set;}
    }
}