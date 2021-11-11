namespace IsAxtaris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_kategoriya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_kategoriya()
        {
            tbl_CCVV = new HashSet<tbl_CCVV>();
            tbl_vakansiya = new HashSet<tbl_vakansiya>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string kategoriyaadi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CCVV> tbl_CCVV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_vakansiya> tbl_vakansiya { get; set; }
    }
}
