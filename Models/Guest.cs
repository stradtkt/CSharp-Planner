using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Planner.Models
{
    public class Guest : BaseEntity
    {
        [Key]
        public int guest_id {get;set;}
        public int wedding_id {get;set;}
        public int user_id {get;set;}
        public User User {get;set;}
        public Wedding Wedding {get;set;}
        public byte pending {get;set;}
        public Guest()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
            pending = 0;
        }
    }
}