using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.BLL.Models
{
    public class EmployeeDTO
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateBirthday { get; set; }

        [Required]
        [StringLength(24)]
        public string INN { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(13)]
        public string Telephone { get; set; }
    }
}
