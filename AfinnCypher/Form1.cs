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
            List<char> charlist = new List<char>();
            List<int> cryptlist = new List<int>();

            out_richTextBox.Clear();

            int j = 0;
            for (char i = 'A'; i <= 'Z'; ++i)
            {
                charlist.Add(i);
           //     out_richTextBox.AppendText(charlist[j].ToString());
           //     ++j;
            }

            for (int i = 0; i <= 25; ++i)
            {
                cryptlist.Add((Int32.Parse(textBox_a.Text) * i + Int32.Parse(textBox_b.Text)) % 26);
               // out_richTextBox.AppendText(cryptlist[j].ToString() + ' ');
               // ++j; 65-90
            }

            Queue<char> text = new Queue<char>();

            for(int i = 0; i < in_richTextBox.TextLength; ++i)
                text.Enqueue(in_richTextBox.Text[i]);

            char symbol;
            while(text.Count != 0)
            {
                //out_richTextBox.AppendText(text.Dequeue().ToString());
                symbol = text.Dequeue();
                
            }

        }
    }
}
