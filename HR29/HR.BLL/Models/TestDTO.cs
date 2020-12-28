using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HR.BLL.Models
{
    public class TestDTO
    {
        [Key]
        public Guid TestId { get; set; }

        [Key]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
