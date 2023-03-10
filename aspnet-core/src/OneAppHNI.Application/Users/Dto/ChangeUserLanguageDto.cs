using System.ComponentModel.DataAnnotations;

namespace OneAppHNI.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}