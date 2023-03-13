namespace GymProject.Classes
{
    public class Item
    {
        private string itemName;
        private double itemPrice;

        public Item(string itemName, double itemPrice)
        {
            GetItemName = itemName;
        }

        public string GetItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public double ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }
    }
}
