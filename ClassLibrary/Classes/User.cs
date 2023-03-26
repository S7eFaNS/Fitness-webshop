using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class User
    {
        private int personId;
        private string firstName;
        private string lastName;
        private string password;
        private string email;

        public User(int personId, string firstName, string lastName, string password, string email)
        {
            GetPersonId = personId;
            GetFirstName = firstName;
            GetLastName= lastName;
            GetPassword = password;
            GetEmail = email;
        }

        public int GetPersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        public string GetFirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string GetLastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string GetPassword
        {
            get { return password; }
            set { password = value; }
        }
        public string GetEmail
        {
            get { return email; }
            set { email = value; }
        }
    }
}
