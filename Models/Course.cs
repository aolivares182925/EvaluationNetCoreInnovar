
using System.ComponentModel.DataAnnotations;

namespace NetCoreTestInnovar.Models;

public class Course
{
        [Key]
        public long Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string Code {get;set;} = string.Empty;
        public ICollection<Score>? Scores {get;set;}
}