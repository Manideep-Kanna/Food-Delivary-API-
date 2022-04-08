using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        [MaxLength(200)]
        public string? Address { get; set; }

    }
}
