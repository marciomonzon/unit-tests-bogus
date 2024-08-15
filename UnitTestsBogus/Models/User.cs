using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UnitTestsBogus.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            try
            {
                return Regex.IsMatch(Email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsValidPassword()
        {
            if (string.IsNullOrWhiteSpace(Password))
                return false;

            var minimumCharacters = (Password.Length < 8);
            if (minimumCharacters)
                return false;

            var atLeastOneUpperCase = (!Regex.IsMatch(Password, @"[A-Z]"));
            if (atLeastOneUpperCase)
                return false;

            var atLeastOneLowerCaseLetter = (!Regex.IsMatch(Password, @"[a-z]"));
            if (atLeastOneLowerCaseLetter)
                return false;

            var atLeastOneDigit = (!Regex.IsMatch(Password, @"[0-9]"));
            if (atLeastOneDigit)
                return false;

            var atLeatOneSpecialCharacter = !Regex.IsMatch(Password, @"[\W_]");
            if (atLeatOneSpecialCharacter)
                return false;

            return true;
        }

        public bool IsValidDateOfBirth()
        {
            int oneHundredYearsAgo = -100;

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly hundredYearsAgo = today.AddYears(oneHundredYearsAgo);

            return DateOfBirth <= today && DateOfBirth >= hundredYearsAgo;
        }
    }
}
