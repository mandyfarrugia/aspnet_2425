using System.ComponentModel.DataAnnotations; //Required for the [Key] data annotation attribute.

namespace Domain.Models
{
    /// <summary>
    /// The Subject model class represents a table to contain information about units.
    /// In this case, it will hold properties such as the subject code (for example, ITSFT-506-2011) and the unit title (for example, Enterprise Programming).
    /// </summary>
    public class Subject
    {
        [Key] //The property Code has been marked as a primary key attribute.
        public string Code { get; set; }
        public string Name { get; set; }
    }
}