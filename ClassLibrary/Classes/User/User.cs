using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes.User
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }

        public User(int id, string firstName, string lastName, string email, string password, UserType userType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserType = userType;
        }
        public User() { }

        //public int Id 
        //{
        //    get { return id; }
        //    private set { id = value; }
        //}
        //public string FirstName
        //{
        //    get { return firstName; }
        //    private set { firstName = value; }
        //}
        //public string LastName
        //{
        //    get { return lastName; }
        //    private set { lastName = value; }
        //}
        //public string Email
        //{
        //    get { return email; }
        //    private set { email = value; }
        //}
        //public string Password
        //{
        //    get { return password; }
        //    private set { password = value; }
        //}


        //zaobikalqm encapsulation i setvam password kum private set passworda.
        //Po toq nachin moga da setna password.
        //public void SetPassword(string password)
        //{
        //    Password = password;
        //}

        //public UserType UserType
        //{
        //    get { return userType; }
        //    protected set { userType = value; }
        //}

    }
}
