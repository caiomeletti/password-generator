namespace PwdGen.API.ViewModels
{
    public class CreatePasswordViewModel
    {
        public int Length { get; set; }
        public bool IncludeUppercaseLetters { get; set; }
        public bool IncludeLowercaseLetters { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSymbols { get; set; }
    }
}
