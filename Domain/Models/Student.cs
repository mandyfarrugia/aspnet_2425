using System.ComponentModel.DataAnnotations; //Required for the [Key] data annotation attribute.
using System.ComponentModel.DataAnnotations.Schema; //Required for the [ForeignKey] data annotation attribute.

namespace Domain.Models
{
    /// <summary>
    /// The Student model class represents a table to contain records of students.
    /// Each property in C# represents a column/field/attribute in a table within a database.
    /// Gather any common attributes among different students such as name, surname, date of birth, means of identification, class group, etc.
    /// Always make sure that any user-defined classes are marked with the public access modifier as they will be accessed by other projects.
    /// </summary>
    public class Student
    {
        //A string data type can hold textual, numeric, and alphanumerical data (for example, symbols).
        [Key] //The property IdNumber has been marked as a primary key attribute.
        public string IdNumber { get; set; } //Make sure to never omit the getters and setters otherwise no data will be available.
        
        public string Name { get; set; }

        public string Surname { get; set; }

        /// <summary>
        /// Properties/attributes can be marked as nullable by means of appending a question mark to the data type.
        /// </summary>
        public DateOnly? DateOfBirth { get; set; }

        /// <summary>
        /// A relational database will be built when Entity Framework uses migrations to map the model classes to their respective table counterparts in SQL Server.
        /// Tables can be linked together by means of a primary key to foreign key relationship.
        /// Table relationships can be one-to-one, one-to-many, and many-to-many.
        /// It is vital that the data types of both the foreign and primary key counterparts match to avoid anomalies.
        /// </summary>
        public string GroupFK { get; set; }

        /// <summary>
        /// Navigational property based on the above property with the foreign key constraint.
        /// Navigational properties accessed through lazy loading must be marked as virtual.
        /// Lazy loading is the process of leaving reference to child tables in memory idle until they need to be used.
        /// This is a more memory efficient approach if a small number of instances will be used.
        /// To avoid NullReferenceException runtime errors, make sure to declare the navigational property as virtual.
        /// A second fix would be to use the Lazy Loading Proxy when overriding the OnConfiguring method in the database context class.
        /// </summary>
        [ForeignKey("GroupFK")]
        public virtual Group Group { get; set; }
    }
}