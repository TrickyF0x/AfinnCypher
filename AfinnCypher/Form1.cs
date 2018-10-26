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
                textBox_a.Text = "1";
            }
        }

        private void textBox_b_TextChanged(object sender, EventArgs e)
        {
            int value;

            if ((!int.TryParse(textBox_b.Text, out value)) && (textBox_b.Text != ""))
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_b.Text = "0";
            }
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {
            out_richTextBox.Clear();

            language text = new language();

            text.txt = in_richTextBox.Text;

            out_richTextBox.Clear();

            text.crypt(comboBox1.SelectedItem.ToString());

            /* if (comboBox1.SelectedItem.ToString() == "English")
             {
                 text.english();
             }
             else if (comboBox1.SelectedItem.ToString() == "Русский")
             {
                 text.russian();
             }
             else
             {
                 text.own();
             }*/
        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Свой")
                textBox1.Enabled = true;
            else
            {
                textBox1.Enabled = false;
                textBox1.Clear();
            }
        }
    }

    class language
    {
        public string txt;
        public void crypt(string type)
        {
            
            List<char> charlist = new List<char>();
            Queue<char> text = new Queue<char>();

            for (int i = 0; i < MainForm.in_richTextBox.TextLength; ++i)
                text.Enqueue(MainForm.in_richTextBox.Text[i]);



            string value;
            if (type == "English")
            {

            }
            else if (type == "Русский")
            {

            }
            else
            {

            }
        }
    }

}
