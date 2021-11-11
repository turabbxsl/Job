namespace IsAxtaris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_vakansiya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_vakansiya()
        {
            tbl_istifadeci = new HashSet<tbl_istifadeci>();
            tbl_resm = new HashSet<tbl_resm>();
        }

        public int id { get; set; }

        [StringLength(37)]
        public string isinadi { get; set; }

        [StringLength(40)]
        public string sirketadi { get; set; }

        public int? kategoriyaid { get; set; }

        [StringLength(50)]
        public string maxemekhaqqi { get; set; }

        [StringLength(50)]
        public string minemekhaqqi { get; set; }

        [StringLength(1500)]
        public string isbaresindemelumat { get; set; }

        [StringLength(1500)]
        public string telebler { get; set; }

        [StringLength(20)]
        public string seher { get; set; }

        [StringLength(20)]
        public string minyas { get; set; }

        [StringLength(20)]
        public string maxyas { get; set; }

        [StringLength(50)]
        public string elaqedarsexs { get; set; }

        [StringLength(1500)]
        public string sirkethaqqinda { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(15)]
        public string telefon { get; set; }

        public int? resmid { get; set; }

        [StringLength(50)]
        public string tarix { get; set; }

        [StringLength(50)]
        public string bitmetarixi { get; set; }

        public int? goruntulenme { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_istifadeci> tbl_istifadeci { get; set; }

        public virtual tbl_kategoriya tbl_kategoriya { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_resm> tbl_resm { get; set; }

        public virtual tbl_resm tbl_resm1 { get; set; }
    }
}
