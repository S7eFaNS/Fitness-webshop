namespace GymProject.Classes
{
    public class Customer
    {
        private string name;
        private string password;

        public Customer(string name, string password) 
        {
            GetName = name;
            GetPassword = password;
        }

        public string GetName
        {
            get { return name; }
            set { name = value; }
        }

        public string GetPassword
        {
            get { return password; }
            set { password = value; }
        }

        public override string ToString()
        {
            return name + " " + password;
        }

    }
}
