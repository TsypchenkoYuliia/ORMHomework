using Microsoft.EntityFrameworkCore;
using ORM.Homework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Homework.Context
{
    public class HomeworkAppContext : DbContext
    {
        public HomeworkAppContext()
        {
            Database.EnsureCreated();
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=OOrmHomeworkDb.db");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
    }
}
