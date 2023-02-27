namespace _27._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void SignUp()
        {
            string name = textBox1.Text;
            string password = textBox2.Text;

            UzivatelDAO.Save();
        }
    }
}