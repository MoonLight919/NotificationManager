namespace DataFromHrDb.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            EmpPromotions = new HashSet<EmpPromotion>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpPromotion> EmpPromotions { get; set; }
    }
}
