﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StageBeheerder.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StageBeheerderEntities : DbContext
    {
        public StageBeheerderEntities()
            : base("name=StageBeheerderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<academics> academics { get; set; }
        public DbSet<administrators> administrators { get; set; }
        public DbSet<adresses> adresses { get; set; }
        public DbSet<companies> companies { get; set; }
        public DbSet<education> education { get; set; }
        public DbSet<internships> internships { get; set; }
        public DbSet<knowledge> knowledge { get; set; }
        public DbSet<students> students { get; set; }
        public DbSet<students_internships> students_internships { get; set; }
        public DbSet<supervisor> supervisor { get; set; }
        public DbSet<teachers> teachers { get; set; }
        public DbSet<transport> transport { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<volumehours> volumehours { get; set; }
        public DbSet<webkeys> webkeys { get; set; }
        public DbSet<studentadress> studentadress { get; set; }
    }
}
