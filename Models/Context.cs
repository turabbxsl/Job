namespace IsAxtaris.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context12")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_CCVV> tbl_CCVV { get; set; }
        public virtual DbSet<tbl_istifadeci> tbl_istifadeci { get; set; }
        public virtual DbSet<tbl_kategoriya> tbl_kategoriya { get; set; }
        public virtual DbSet<tbl_resm> tbl_resm { get; set; }
        public virtual DbSet<tbl_vakansiya> tbl_vakansiya { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_CCVV>()
                .HasMany(e => e.tbl_istifadeci)
                .WithOptional(e => e.tbl_CCVV)
                .HasForeignKey(e => e.cvid);

            modelBuilder.Entity<tbl_CCVV>()
                .HasMany(e => e.tbl_resm1)
                .WithOptional(e => e.tbl_CCVV1)
                .HasForeignKey(e => e.cvid);

            modelBuilder.Entity<tbl_kategoriya>()
                .HasMany(e => e.tbl_CCVV)
                .WithOptional(e => e.tbl_kategoriya)
                .HasForeignKey(e => e.kategoriyaid);

            modelBuilder.Entity<tbl_kategoriya>()
                .HasMany(e => e.tbl_vakansiya)
                .WithOptional(e => e.tbl_kategoriya)
                .HasForeignKey(e => e.kategoriyaid);

            modelBuilder.Entity<tbl_resm>()
                .HasMany(e => e.tbl_CCVV)
                .WithOptional(e => e.tbl_resm)
                .HasForeignKey(e => e.resmid);

            modelBuilder.Entity<tbl_resm>()
                .HasMany(e => e.tbl_vakansiya1)
                .WithOptional(e => e.tbl_resm1)
                .HasForeignKey(e => e.resmid);

            modelBuilder.Entity<tbl_vakansiya>()
                .HasMany(e => e.tbl_istifadeci)
                .WithOptional(e => e.tbl_vakansiya)
                .HasForeignKey(e => e.vakansiyaid);

            modelBuilder.Entity<tbl_vakansiya>()
                .HasMany(e => e.tbl_resm)
                .WithOptional(e => e.tbl_vakansiya)
                .HasForeignKey(e => e.vakansiyaid);
        }
    }
}
