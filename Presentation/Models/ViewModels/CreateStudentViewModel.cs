using DataAccess.Repositories;
using Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        private GroupsRepository GroupsRepository { get; }

        public CreateStudentViewModel(GroupsRepository _groupsRepository)
        {
            this.Groups = _groupsRepository.GetGroups();
        }

        [Key]
        [DisplayName("Identification Number")]
        public string IdNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
        public string Surname { get; set; }

        [DisplayName("Birthdate")]
        public DateOnly? DateOfBirth { get; set; }

        [DisplayName("Group")]
        public string GroupFK { get; set; }

        public IQueryable<Group> Groups { get; set; }
    }
}
