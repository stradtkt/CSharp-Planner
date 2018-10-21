using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Planner.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int wedding_id {get;set;}
        public int user_id {get;set;}
        public User User {get;set;}
        public string wedder_one {get;set;}
        public string wedder_two {get;set;}
        public DateTime event_date {get;set;}
        public string location {get;set;}

        public List<Guest> Guests {get;set;}

        public Wedding()
        {
            Guests = new List<Guest>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}