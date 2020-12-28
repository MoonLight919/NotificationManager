using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HR.BLL.Models
{
    public class JobTitleDTO
    {
        [Key]
        public int JobTitleId { get; set; }

        [Required]
        [StringLength(100)]
        public string NameJobTitle { get; set; }

    }
}
