using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfinnCypher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            in_richTextBox.Clear();
            out_richTextBox.Clear();
        }

        private void textBox_a_TextChanged(object sender, EventArgs e)
        {
            int value;

            if ((!int.TryParse(textBox_a.Text, out value)) && (textBox_a.Text != ""))
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_a.Clear();
            }
        }

        private void textBox_b_TextChanged(object sender, EventArgs e)
        {
            int value;

            if ((!int.TryParse(textBox_b.Text, out value)) && (textBox_b.Text != ""))
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_b.Clear();
            }
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {

        }
    }
}
