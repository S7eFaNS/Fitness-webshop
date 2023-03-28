using ClassLibrary;

namespace GymAppWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void add_UControls(UserControl userControl)
        {
            userControl.Dock= DockStyle.Fill;
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            foreach (var pnl in tableLayoutPanel1.Controls.OfType<Panel>())
                pnl.BackColor = Color.Silver;

            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn_home":
                    add_UControls(new UC_Home());
                    pnl_home.BackColor = Color.MediumSeaGreen;
                    break;
                case "btn_products":
                    add_UControls(new UC_Products());
                    pnl_products.BackColor = Color.MediumSeaGreen;
                    break;
                case "btn_users":
                    add_UControls(new UC_Users());
                    pnl_users.BackColor = Color.MediumSeaGreen;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}