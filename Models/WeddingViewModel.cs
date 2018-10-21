using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    public class PostWedding : BaseEntity
    {
        [Key]
        public int wedding_id {get;set;}
        public string wedder_one {get;set;}
        public string wedder_two {get;set;}
        public DateTime event_date {get;set;}
        public string location {get;set;}
    }
}