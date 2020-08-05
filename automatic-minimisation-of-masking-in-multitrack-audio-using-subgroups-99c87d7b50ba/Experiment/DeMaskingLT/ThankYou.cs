using System;
using System.Windows.Forms;

namespace DeMaskingLT
{
    public partial class ThankYou : Form
    {
        public ThankYou()
        {
            InitializeComponent();
        }

        public ThankYou(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
