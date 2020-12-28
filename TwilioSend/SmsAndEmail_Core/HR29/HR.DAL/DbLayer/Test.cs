namespace DataFromHrDb.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Test")]
    public partial class Test
    {
        public Guid TestId { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
