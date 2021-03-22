using System.ComponentModel.DataAnnotations;

namespace Rawpotion.Api.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public string PasswordHash { get; set; }
    }
}