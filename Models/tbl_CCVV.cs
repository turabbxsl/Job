namespace IsAxtaris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CCVV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CCVV()
        {
            tbl_istifadeci = new HashSet<tbl_istifadeci>();
            tbl_resm1 = new HashSet<tbl_resm>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string adi { get; set; }

        [StringLength(200)]
        public string soyadi { get; set; }

        [StringLength(100)]
        public string cinsiyyeti { get; set; }

        [StringLength(100)]
        public string yasi { get; set; }

        [StringLength(100)]
        public string tehsili { get; set; }

        [StringLength(3000)]
        public string tehsilmelumati { get; set; }

        [StringLength(200)]
        public string istecrubesi { get; set; }

        [StringLength(3000)]
        public string istecrubesimelumati { get; set; }

        public int? kategoriyaid { get; set; }

        [StringLength(200)]
        public string seheri { get; set; }

        [StringLength(200)]
        public string vezifesi { get; set; }

        [StringLength(100)]
        public string emekhaqqi { get; set; }

        [StringLength(3000)]
        public string bacarigi { get; set; }

        [StringLength(3000)]
        public string elavemelumati { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [StringLength(100)]
        public string telefon { get; set; }

        public int? resmid { get; set; }

        [StringLength(100)]
        public string tarix { get; set; }

        [StringLength(50)]
        public string bitmetarixi { get; set; }

        public int? goruntulenme { get; set; }

        public virtual tbl_kategoriya tbl_kategoriya { get; set; }

        public virtual tbl_resm tbl_resm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_istifadeci> tbl_istifadeci { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_resm> tbl_resm1 { get; set; }
    }
}
