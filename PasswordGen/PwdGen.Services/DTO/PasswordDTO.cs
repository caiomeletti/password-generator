
namespace PwdGen.Services.DTO
{
    public class PasswordDTO
    {
        public string PasswordContent { get; set; }
        public int Length { get; set; }
        public bool IncludeUppercaseLetters { get; set; }
        public bool IncludeLowercaseLetters { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSymbols { get; set; }

        public PasswordDTO()
        {
            PasswordContent = string.Empty;
            Length = 0;
            IncludeUppercaseLetters = false;
            IncludeLowercaseLetters = false;
            IncludeNumbers = false;
            IncludeSymbols = false;
        }
    }
}
