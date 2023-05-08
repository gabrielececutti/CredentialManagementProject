using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.PasswordValidator
{
    public static class SetUpPasswordChain
    {
        public static IPasswordValidator SetUpChain ()
        {
            var validatorLength = new LengthValidator();
            var validatorDigit = new DigitValidator();
            var upperValidator = new UpperCaseValidator();
            var specialValidator = new SpecialCharValidator();

            validatorLength.SetSuccessor(validatorDigit);
            validatorDigit.SetSuccessor(upperValidator);
            upperValidator.SetSuccessor(specialValidator);
            return validatorLength;
        }
    }
}
