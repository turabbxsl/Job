namespace IsAxtaris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_resm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_resm()
        {
            tbl_CCVV = new HashSet<tbl_CCVV>();
            tbl_vakansiya1 = new HashSet<tbl_vakansiya>();
        }

        public int id { get; set; }

        [StringLength(3000)]
        public string kicikolculu { get; set; }

        [StringLength(3000)]
        public string boyukolculu { get; set; }

        public int? cvid { get; set; }

        public int? vakansiyaid { get; set; }

        public bool? varsayilan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CCVV> tbl_CCVV { get; set; }

        public virtual tbl_CCVV tbl_CCVV1 { get; set; }

        public virtual tbl_vakansiya tbl_vakansiya { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_vakansiya> tbl_vakansiya1 { get; set; }
    }
}
