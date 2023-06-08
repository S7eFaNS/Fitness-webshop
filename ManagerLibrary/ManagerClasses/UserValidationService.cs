using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ManagerClasses
{
    public class UserValidationService
    {

        public UserValidationService() { }

        public bool IsFirstNameValid(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return false;
            }

            if (!char.IsUpper(firstName[0]))
            {
                return false;
            }

            for (int i = 1; i < firstName.Length; i++)
            {
                if (!char.IsLower(firstName[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsLastNameValid(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!char.IsUpper(lastName[0]))
            {
                return false;
            }

            for (int i = 1; i < lastName.Length; i++)
            {
                if (!char.IsLower(lastName[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsEmailValid(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }

        public bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                return false;
            }

            bool hasUppercase = false;
            bool hasNumber = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumber = true;
                }

                if (hasUppercase && hasNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
