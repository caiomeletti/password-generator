using PwdGen.Services.DTO;
using PwdGen.Services.Services;
using PwdGen.Services.Utilities;

namespace PwdGen.UnitTest.Services
{
    public class PasswordUnitTest
    {
        readonly PasswordService _passwordService;

        public PasswordUnitTest()
        {
            _passwordService = new PasswordService();
        }

        [Fact(DisplayName = "O comprimento da senha gerada deve ser maior que 1")]
        public void LengthOfTheGeneratedPasswordMustBeGreatherThanOne()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 1,
                IncludeUppercaseLetters = false,
                IncludeLowercaseLetters = false,
                IncludeNumbers = false,
                IncludeSymbols = false,
            };
            var result = _passwordService.Generate(passwordDTO);

            Assert.True(result.PasswordContent.Length >= 1);
        }

        [Fact(DisplayName = "O comprimento da senha deve acompanhar a quantidade de incrementos de segurança")]
        public void LengthOfTheGeneratedPasswordShouldAccompanyTheNumberofSecurityIncreases()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 3,
                IncludeUppercaseLetters = true,
                IncludeLowercaseLetters = false,
                IncludeNumbers = true,
                IncludeSymbols = false,
            };
            var result = _passwordService.Generate(passwordDTO);
            bool isUpper = ServiceUtil.ContainsAnyUppercaseLetter(result.PasswordContent);
            bool isNumber = ServiceUtil.ContainsAnyNumbers(result.PasswordContent);

            Assert.True(result.PasswordContent.Length == passwordDTO.Length && isUpper && isNumber);

            passwordDTO = new()
            {
                Length = 2,
                IncludeUppercaseLetters = true,
                IncludeLowercaseLetters = true,
                IncludeNumbers = true,
                IncludeSymbols = false,
            };
            result = _passwordService.Generate(passwordDTO);

            Assert.True(string.IsNullOrEmpty(result.PasswordContent));
        }

        [Fact(DisplayName = "O usuário pode selecionar o comprimento da senha gerada")]
        public void UserCanSelectLengthOfTheGeneratedPassword()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 10,
                IncludeUppercaseLetters = false,
                IncludeLowercaseLetters = false,
                IncludeNumbers = false,
                IncludeSymbols = false,
            };
            var result = _passwordService.Generate(passwordDTO);

            Assert.Equal(passwordDTO.Length, result.PasswordContent.Length);
        }

        [Fact(DisplayName = "O usuário pode selecionar 'Include uppercase letters'")]
        public void UserCanSelectIncludeUppercaseLetters()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 10,
                IncludeUppercaseLetters = true,
                IncludeLowercaseLetters = false,
                IncludeNumbers = false,
                IncludeSymbols = false,
            };
            var result = _passwordService.Generate(passwordDTO);
            bool isUpper = ServiceUtil.ContainsAnyUppercaseLetter(result.PasswordContent);

            Assert.True(isUpper);
        }

        [Fact(DisplayName = "O usuário pode selecionar 'Include lowercase letters'")]
        public void UserCanSelectIncludeLowercaseLetters()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 10,
                IncludeUppercaseLetters = false,
                IncludeLowercaseLetters = true,
                IncludeNumbers = false,
                IncludeSymbols = false,
            };
            var result = _passwordService.Generate(passwordDTO);
            bool isLower = ServiceUtil.ContainsAnyLowercaseLetters(result.PasswordContent);

            Assert.True(isLower);
        }

        [Fact(DisplayName = "O usuário pode selecionar 'Include numbers'")]
        public void UserCanSelectIncludeNumbers()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 10,
                IncludeUppercaseLetters = false,
                IncludeLowercaseLetters = false,
                IncludeNumbers = true,
                IncludeSymbols = false,
            };
            var result = _passwordService.Generate(passwordDTO);
            bool isNumber = ServiceUtil.ContainsAnyNumbers(result.PasswordContent);

            Assert.True(isNumber);
        }

        [Fact(DisplayName = "O usuário pode selecionar 'Include Symbols'")]
        public void UserCanSelectIncludeSymbols()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 10,
                IncludeUppercaseLetters = false,
                IncludeLowercaseLetters = false,
                IncludeNumbers = false,
                IncludeSymbols = true,
            };
            var result = _passwordService.Generate(passwordDTO);
            bool isSymbol = ServiceUtil.ContainsAnySymbols(result.PasswordContent);

            Assert.True(isSymbol);
        }

        [Fact(DisplayName = "O usuário pode selecionar todos os incrementos de segurança")]
        public void UserCanSelectAllIncreaseSecurity()
        {
            PasswordDTO passwordDTO = new()
            {
                Length = 6,
                IncludeUppercaseLetters = true,
                IncludeLowercaseLetters = true,
                IncludeNumbers = true,
                IncludeSymbols = true,
            };
            var result = _passwordService.Generate(passwordDTO);
            bool isUpper = ServiceUtil.ContainsAnyUppercaseLetter(result.PasswordContent);
            bool isLower = ServiceUtil.ContainsAnyLowercaseLetters(result.PasswordContent);
            bool isNumber = ServiceUtil.ContainsAnyNumbers(result.PasswordContent);
            bool isSymbol = ServiceUtil.ContainsAnySymbols(result.PasswordContent);

            Assert.True(isUpper && isLower && isNumber && isSymbol);
        }
    }
}
