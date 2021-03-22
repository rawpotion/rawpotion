using System.Text.RegularExpressions;
using FluentValidation;
using Rawpotion.Api.Models;

namespace Rawpotion.Api.Features.Users
{
    public class UserAddValidator : AbstractValidator<UserAdd>
    {
        public UserAddValidator()
        {
            RuleFor(u => u.Name).Matches("[a-zA-Z ]").NotEmpty();
            RuleFor(u => u.UserName).Matches("[a-zA-Z]").NotEmpty();
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).Length(5,30).Must(Password).WithMessage("Password did not fit the requirements");
        }

        public static bool Password(string pw)
        {
            if (string.IsNullOrEmpty(pw))
                return false;
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return lowercase.IsMatch(pw) &&
                   uppercase.IsMatch(pw) &&
                   digit.IsMatch(pw) &&
                   symbol.IsMatch(pw);
        }
    }
}