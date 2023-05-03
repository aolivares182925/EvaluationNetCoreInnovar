using System.ComponentModel.DataAnnotations;

namespace NetCoreTestInnovar.Models;
public class Student
{
    [Key]
    public long Id {get;set;}
    public string Name {get;set;} = string.Empty;
    public string LastName {get;set;} = string.Empty;
    public string StudentCode {get;set;} = string.Empty;
    public DateTime BirthDate {get;set;}
    public ICollection<Score>? Scores {get;set;}
}
