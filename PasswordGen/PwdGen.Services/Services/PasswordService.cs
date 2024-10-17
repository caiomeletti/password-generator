using PwdGen.Services.DTO;
using PwdGen.Services.Interfaces;
using PwdGen.Services.Utilities;
using System.Text;

namespace PwdGen.Services.Services
{
    public class PasswordService : IPasswordService
    {
        public PasswordDTO Generate(PasswordDTO passwordDTO)
        {
            if (passwordDTO.Length <= 0)
                return passwordDTO;

            StringBuilder sb = new();
            Random rnd = new();
            string validChars = "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ0123456789'!@#$%&*()_=/-+.,;:?[]{}´`~^<>";
            do
            {
                sb.Clear();
                for (int i = 1; i <= passwordDTO.Length; i++)
                {
                    sb.Append(validChars[rnd.Next(validChars.Length)]);
                }
                passwordDTO.PasswordContent = sb.ToString();

            } while (!IncreaseSecurityIsValid(passwordDTO));

            return passwordDTO;
        }

        private static bool IncreaseSecurityIsValid(PasswordDTO passwordDTO)
        {
            var includeLowercaseLetters = !passwordDTO.IncludeLowercaseLetters;
            var includeUppercaseLetters = !passwordDTO.IncludeUppercaseLetters;
            var includeNumbers = !passwordDTO.IncludeNumbers;
            var includeSymbols = !passwordDTO.IncludeSymbols;

            bool result;
            if (!passwordDTO.IncludeLowercaseLetters
                && !passwordDTO.IncludeUppercaseLetters
                && !passwordDTO.IncludeNumbers
                && !passwordDTO.IncludeSymbols)
            {
                result = true;
            }
            else
            {
                if (passwordDTO.IncludeLowercaseLetters && ServiceUtil.ContainsAnyLowercaseLetters(passwordDTO.PasswordContent))
                {
                    includeLowercaseLetters = true;
                }
                if (passwordDTO.IncludeUppercaseLetters && ServiceUtil.ContainsAnyUppercaseLetter(passwordDTO.PasswordContent))
                {
                    includeUppercaseLetters = true;
                }
                if (passwordDTO.IncludeNumbers && ServiceUtil.ContainsAnyNumbers(passwordDTO.PasswordContent))
                {
                    includeNumbers = true;
                }
                if (passwordDTO.IncludeSymbols && ServiceUtil.ContainsAnySymbols(passwordDTO.PasswordContent))
                {
                    includeSymbols = true;
                }

                result = includeLowercaseLetters && includeUppercaseLetters && includeNumbers && includeSymbols;
            }

            return result;
        }
    }
}
