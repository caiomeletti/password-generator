using PwdGen.Core.Enums;

namespace PwdGen.Services.Utilities
{
    public static class ServiceUtil
    {
        public static bool ContainsAnyUppercaseLetter(string passwordContent)
        {
            return ContainsAny(IncreaseSecurity.IncludeUppercaseLetters, passwordContent);
        }
        public static bool ContainsAnyLowercaseLetters(string passwordContent)
        {
            return ContainsAny(IncreaseSecurity.IncludeLowercaseLetters, passwordContent);
        }
        public static bool ContainsAnyNumbers(string passwordContent)
        {
            return ContainsAny(IncreaseSecurity.IncludeNumbers, passwordContent);
        }
        public static bool ContainsAnySymbols(string passwordContent)
        {
            return ContainsAny(IncreaseSecurity.IncludeSymbols, passwordContent);
        }

        public static bool ContainsAny(IncreaseSecurity increaseSecurityKey, string passwordContent)
        {
            var result = false;
            foreach (var charPwd in passwordContent.ToCharArray())
            {
                if (increaseSecurityKey == IncreaseSecurity.IncludeUppercaseLetters && char.IsUpper(charPwd))
                {
                    result = true;
                    break;
                }

                if (increaseSecurityKey == IncreaseSecurity.IncludeLowercaseLetters && char.IsLower(charPwd))
                {
                    result = true;
                    break;
                }

                if (increaseSecurityKey == IncreaseSecurity.IncludeNumbers && char.IsNumber(charPwd))
                {
                    result = true;
                    break;
                }

                if (increaseSecurityKey == IncreaseSecurity.IncludeSymbols && char.IsSymbol(charPwd))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
