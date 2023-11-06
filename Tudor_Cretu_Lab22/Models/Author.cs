using System.ComponentModel.DataAnnotations;

namespace Tudor_Cretu_Lab22.Models
{
    public class Author
    {

        public int ID { get; set; }

        [Display(Name = "AuthorFirstName")]
        public string FirstName { get; set; }
        [Display(Name = "AuthorLastName")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Book>? Books { get; set; }







    }
}
