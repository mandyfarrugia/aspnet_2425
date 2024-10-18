using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* Seeding is the process of populating your database with initial data, mainly for testing purposes.
             * Always start from the tables without any dependencies to avoid issues. 
             * Furthermore, avoid hardcoding values especially with regards to foreign key values, use subqueries where necessary. */
            migrationBuilder.Sql("INSERT INTO dbo.Subjects (Code, [Name]) VALUES ('ITSFT-506-2011', 'Enterprise Programming'), ('ITSFT-506-2006', 'Object Oriented Programming');");
            migrationBuilder.Sql("INSERT INTO dbo.Groups (Code, Programme) VALUES ('IT-SWD-6.2A', 'Level 6 - BSc Software Development'), ('IT-SWD-6.1A', 'Level 6 - BSc Software Development');");
            migrationBuilder.Sql("INSERT INTO dbo.Students (IdNumber, [Name], Surname, DateOfBirth, GroupFK) VALUES ('0473501L', 'Mandy', 'Farrugia', '2001-12-05', 'IT-SWD-6.2A'), ('0345802L', 'Joseph', 'Brincat', '2002-08-19', 'IT-SWD-6.1A')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
