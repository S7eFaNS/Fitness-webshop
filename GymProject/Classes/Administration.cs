namespace GymProject.Classes
{
    public class Administration
    {
        private List<Customer> customers;
        private List<Item> items;

        public Administration() 
        {

        }

        public List<Customer> TheCustomers { get { return customers; } }

        public List<Item> TheItems { get { return items; } }
    }
}
