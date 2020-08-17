using System.ComponentModel.DataAnnotations;

namespace Food.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}