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

            text.crypt(Int32.Parse(textBox_a.Text), Int32.Parse(textBox_b.Text), text.txt, comboBox1.SelectedItem.ToString());

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


        class language
        {
            public string txt;
            public void crypt(int a, int b, string str, string lang)
            {

                List<char> charlist = new List<char>();
                Queue<char> text = new Queue<char>();
                
                for (int i = 0; i < str.Length; ++i)
                    text.Enqueue(str[i]);

                coded_alphabet(a, b, lang);

                if (lang == "English")
                {

                }
                else if (lang == "Русский")
                {

                }
                else
                {

                }
            }

            private char[] coded_alphabet(int a, int b, string lang)
            {
                if (lang == "English")
                {
                    char[] code = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

                    return code;
                }
                else if (lang == "Русский")
                {
                    char[] code = {'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я'};

                    return code;
                }
                else
                {
                    char[] code = new char[lang.Length];

                    for (int i = 0; i < lang.Length; ++i)
                    {
                        code[i] = lang[i];
                    }


                    return code;
                }
            }//coded_alphabet

        }

    }
}
