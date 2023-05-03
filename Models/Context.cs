using Microsoft.EntityFrameworkCore;
using NetCoreTestInnovar.Models;

namespace BarApi.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options){

        }

        public DbSet<Student> Students {get;set;}
        public DbSet<Score> Scores {get;set;}
        public DbSet<Course> Course {get;set;}
    }
}