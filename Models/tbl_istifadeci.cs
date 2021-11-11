namespace IsAxtaris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_istifadeci
    {
        public int id { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        [StringLength(50)]
        public string istifadeciadi { get; set; }

        public int? cvid { get; set; }

        public int? vakansiyaid { get; set; }

        public bool? cvolar { get; set; }

        public bool? vakansiyaolar { get; set; }

        public virtual tbl_CCVV tbl_CCVV { get; set; }

        public virtual tbl_vakansiya tbl_vakansiya { get; set; }
    }
}
