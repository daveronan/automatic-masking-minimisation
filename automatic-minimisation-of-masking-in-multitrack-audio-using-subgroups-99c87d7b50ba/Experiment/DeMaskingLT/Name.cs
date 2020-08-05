using System;
using System.Text;
using System.Windows.Forms;

namespace DeMaskingLT
{
    public partial class Name : Form
    {
        private Boolean _getTestType = false;
        private Boolean _getTestName = false;

        public Name()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_getTestType)
            {
                radioButtonTestA.Visible = false;
                radioButtonTestB.Visible = false;
                labelTestType.Visible = false;
                tbName.Visible = true;
                labelName.Visible = true;

                button1.Enabled = false;

                _getTestType = false;
                
            }
            else if (_getTestName)
            {
                tbName.Visible = false;
                labelName.Visible = false;

                tbInstructions.Visible = true;

                button1.Enabled = true;
                
                _getTestName = false;
                
            }
            else if (!_getTestName && !_getTestType)
            {
                this.Close();
            }
            
        }

        private void Name_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.ControlBox = false;
        }

        private void radioButtonTestB_CheckedChanged(object sender, EventArgs e)
        {
            _getTestType = true;
            button1.Enabled = true;
        }

        private void radioButtonTestA_CheckedChanged(object sender, EventArgs e)
        {
            _getTestType = true;
            button1.Enabled = true;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            _getTestName = true;
            button1.Enabled = true;
        }
    }
}
