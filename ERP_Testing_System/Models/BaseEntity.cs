using System;

namespace ERP_Testing_System.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string Username { get; set; } = "Admin";
    }
}
