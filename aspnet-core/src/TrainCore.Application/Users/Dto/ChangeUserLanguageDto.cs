using System.ComponentModel.DataAnnotations;

namespace TrainCore.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}