using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int user_id {get;set;}
        public string first_name {get;set;}
        public string last_name {get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public List<Wedding> Weddings {get;set;}
        public User()
        {
            Weddings = new List<Wedding>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }   
}