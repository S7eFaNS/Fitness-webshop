using Database.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class User : Entity
    {
        [ColumnName("first_name")]
        private string firstName { get; set; }

        [ColumnName("last_name")]
        private string lastName { get; set; }

        [ColumnName("email")]
        private string email { get; set; }

        [ColumnName("password")]
        private string password { get; set; }

        [ColumnName("user_type")]
        private UserType userType { get; set; }

        public User(int id, string firstName, string lastName, string email, string password, UserType userType)
        {
            this.SetId(id);
            GetFirstName = firstName;
            GetLastName = lastName;
            GetEmail = email;
            GetPassword = password;
            GetUserType = userType;
        }
        public User() { }

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
        public string GetEmail
        {
            get { return email; }
            set { email = value; }
        }
        public string GetPassword
        {
            get { return password; }
            set { password = value; }
        }
        public UserType GetUserType
        {
            get { return userType; }
            set { userType = value; }
        }
    }
}
