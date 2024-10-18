using System.ComponentModel.DataAnnotations; //Required for the [Key] data annotation attribute.

namespace Domain.Models
{
    /// <summary>
    /// The Group model class represents a table to contain information related to different class groups.
    /// In this case, it will hold properties such as the class group code (for example, IT-SWD-6.2A) and the programme (for example: Level 6 - BSc Software Development).
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Represents a class group code such as IT-SWD-6.2A
        /// </summary>
        [Key] //The property Code has been marked as a primary key attribute.
        public string Code { get; set; }

        /// <summary>
        /// Represents the name of the course and the MQF Level under which said course classifies (for instance, Level 4 - Advanced Diploma in IT Software Development).
        /// </summary>
        public string Programme { get; set; }
    }
}