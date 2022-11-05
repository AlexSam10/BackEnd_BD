using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace BackEnd_BD.Models
{
    public class AlumnoDbContext:DbContext
    {
        private const string ConnectionString = "DefaultConnection";
        public  AlumnoDbContext(): base(ConnectionString) { }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Maestros> Maestros { get; set; }
    }
}