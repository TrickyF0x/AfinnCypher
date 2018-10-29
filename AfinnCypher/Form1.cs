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

            string variant = comboBox1.Text;
            if (comboBox1.Text == "Свой")
                variant = textBox1.Text;
            else if (comboBox1.Text != "English" || comboBox1.Text != "Русский")
            {
                variant = "English";
                comboBox1.Text = "English";
            }

            out_richTextBox.Text = text.crypt(Int32.Parse(textBox_a.Text), Int32.Parse(textBox_b.Text), text.txt, variant);

        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Свой")
                textBox1.Enabled = true;
            else
            {
                label_helper.Text = "Можно взять за 'a': ";
                for (int j = 1; j <= 20; ++j)
                    if (gcd(j, comboBox1.Text) == 1)
                        label_helper.Text += j.ToString() + "; ";
                textBox1.Enabled = false;
                textBox1.Clear();
            }


        }


        class language
        {
            public string txt;
            public string crypt(int a, int b, string txt, string lang)
            {
                string coded_string = "", lowertxt;
                char[] code = new char[lang.Length];

                if (gcd(a, lang) == 1)//получаем кодированый алфавит
                {
                    code = coded_alphabet(a, b, lang);
                    switch (lang)
                    {
                        case "English":
                            {
                                lowertxt = txt.ToLower();
                                for (int i = 0; i < lowertxt.Length; ++i)
                                {
                                    if (!coding('a', 'z', txt[i]))
                                    {
                                        coded_string += lowertxt[i];
                                        continue;
                                    }
                                    else
                                        coded_string += code[index_finder(lowertxt[i], lang)].ToString();
                                }
                                return coded_string;
                            }
                        case "Русский":
                            {
                                lowertxt = txt.ToLower();
                                for (int i = 0; i < lowertxt.Length; ++i)
                                {
                                    if (!coding('а', 'я', txt[i]))
                                    {
                                        coded_string += lowertxt[i];
                                        continue;
                                    }
                                    else
                                        coded_string += code[index_finder(lowertxt[i], lang)].ToString();
                                }
                                return coded_string;
                            }
                        default:
                            {
                                for (int i = 0; i < txt.Length; ++i)
                                {
                                    if (lang.LastIndexOf(txt[i]) == -1)
                                    {
                                        coded_string += txt[i];
                                        continue;
                                    }
                                    else
                                        coded_string += code[index_finder(txt[i], lang)].ToString();
                                }
                                return coded_string;
                            }
                    }
                }
                else
                    MessageBox.Show("Значение а и длина алфавита не являются взаимопростыми числами!",
                        "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }//crypt

            public string decrypt(int a, int b, string txt, string lang)
            {
                string decoded_string = "";
                char[] code = new char[lang.Length];
                int index = 0, j, eucl;

                if (gcd(a, lang) == 1)
                {
                    code = coded_alphabet(a, b, lang);
                    switch (lang)
                    {
                        case "English":
                            {
                               
                                eucl = evklid(a, 26, lang);
                                for (int i = 0; i < txt.Length; ++i)
                                {
                                    if (!coding('a', 'z', txt[i]))
                                    {
                                        decoded_string += txt[i];
                                        continue;
                                    }
                                    else
                                    {
                                         for (j = 0; j < code.Length; ++j)
                                             if (code[j] == txt[i])
                                                 break;
                                        index = (eucl * (j - b)) % 26;
                                        if (index < 0)
                                            index += 26;
                                        decoded_string += code[index];
                                    }
                                }
                                return decoded_string;
                            }
                        case "Русский":
                            {
                                eucl = evklid(a, 33, lang);
                                for (int i = 0; i < txt.Length; ++i)
                                {
                                    if (!coding('а', 'я', txt[i]))
                                    {
                                        decoded_string += txt[i];
                                        continue;
                                    }
                                    else
                                    {
                                        for (j = 0; j < code.Length; ++j)
                                            if (code[j] == txt[i])
                                                break;
                                        index = (eucl * (j - b)) % 33;
                                        if (index < 0)
                                            index += 33;
                                        decoded_string += code[index];
                                    }
                                }
                                return decoded_string;
                            }
                        default:
                            {
                                eucl = evklid(a, lang.Length, lang);
                                for (int i = 0; i < txt.Length; ++i)
                                {
                                    if (lang.LastIndexOf(txt[i]) == -1)
                                    {
                                        decoded_string += txt[i];
                                        continue;
                                    }
                                    else
                                    {
                                        for (j = 0; j < code.Length; ++j)
                                            if (code[j] == txt[i])
                                                break;
                                        index = (eucl * (j - b)) % lang.Length;
                                        if (index < 0)
                                            index += lang.Length;
                                        decoded_string += code[index];
                                    }
                                }
                                return decoded_string;
                            }
                    }
                }
                else
                    MessageBox.Show("Значение 'a' и длина алфавита не являются взаимопростыми числами!",
                        "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                return "";
            }//decrypt

            private bool coding(char first, char last, char leter)//vhodit li symbol v alfavit
            {
                if (leter < first || leter > last)
                    return false;
                else
                    return true;
            }//coding

            private char[] coded_alphabet(int a, int b, string lang)
            {
                switch (lang)
                {
                    case "English":
                        {
                          char[] code = new char[26];
                          char[] alh = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
                              'o','p','q','r','s','t','u','v','w','x','y','z'};
                          for (int i = 0; i < 26; ++i)
                              code[i] = alh[(a * i + b) % 26];
                          return code;               
                        }
                    case "Русский":
                    {
                        char[] code = new char[33];
                        char[] alh = {'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н',
                            'о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я'};
                        for (int i = 0; i < 33; ++i)
                            code[i] = alh[(a * i + b) % 33];
                        return code;
                    }
                    default:
                    {
                        char[] code = new char[lang.Length];
                    
                        for (int i = 0; i < lang.Length; ++i)
                            code[i] = lang[(a * i + b) % lang.Length];
                        return code;
                    }
                }
            }//coded_alphabet

            private int index_finder(char leter, string lang)
            {
                int index = 0;
                switch(lang)
                {
                    case "English":
                        {
                            char[] alh = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
                              'o','p','q','r','s','t','u','v','w','x','y','z'};
                            for (int i = 0; i < 26; ++i)
                                if (alh[i] == leter)
                                {
                                    index = i;
                                    return i;
                                }
                            return leter;
                        }
                    case "Русский":
                        {
                            char[] alh = {'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н',
                            'о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я'};
                            for (int i = 0; i < 33; ++i)
                                if (alh[i] == leter)
                                {
                                    index = i;
                                    return i;
                                }
                            return leter;
                        }
                    default:
                        {
                            for (int i = 0; i < lang.Length; ++i)
                                if (lang[i] == leter)
                                {
                                    index = i;
                                    return i;
                                }
                            return leter;
                        }
                }
            }//index_finder

            private int index_finder(int index, string lang)
            {
                switch (lang)
                {
                    case "English":
                        {
                            char[] alh = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
                              'o','p','q','r','s','t','u','v','w','x','y','z'};
                            return alh[index];
                        }
                    case "Русский":
                        {
                            char[] alh = {'а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н',
                            'о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я'};
                            return alh[index];
                        }
                    default:
                        {
                            return lang[index];
                        }
                }
            }//index_finder

            private int gcd(int a, string lang)
            {
                int b;
                if (lang == "English")
                    b = 26;
                else if (lang == "Русский")
                    b = 33;
                else
                    b = lang.Length;

                while (b != 0)
                    b = a % (a = b);
                return a;
            }//gcd

            private int evklid(int a, int b, string lang)
            {
                int p = 1, q = 0, r = 0, s = 1, x, y;
                while (a != 0 && b != 0)
                {
                    if (a >= b)
                    {
                        a = a - b;
                        p = p - r;
                        q = q - s;
                    }
                    else
                    {
                        b = b - a;
                        r = r - p;
                        s = s - q;
                    }
                }
                if (a != 0)
                {
                    x = p;
                    y = q;
                }
                else
                {
                    x = r;
                    y = s;
                }
                switch (lang)
                {
                    case "English":
                        return x + 26;
                    case "Русский":
                        return x + 33;
                    default:
                        return x + lang.Length;
                }
                
            }//evklid

        }//class crypt

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < textBox1.Text.Length - 1; ++i)
            if(textBox1.Text[i] == textBox1.Text.Last())
            {
                    MessageBox.Show("Нельзя использовать одинаковые буквы в одном алфавите!", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length-1, 1);
            }

            label_helper.Text = "Можно взять за 'a': ";
            for(int j = 1; j <= 20; ++j)
                if(gcd(j, textBox1.Text) == 1)
                    label_helper.Text += j.ToString() + "; ";
        }

        int gcd(int a, string lang)
        {
            int b;
            if (lang == "English")
                b = 26;
            else if (lang == "Русский")
                b = 33;
            else
                b = lang.Length;

            while (b != 0)
                b = a % (a = b);
            return a;
        }//gcd

        private void decrypt_button_Click(object sender, EventArgs e)
        {
            out_richTextBox.Clear();

            language text = new language();

            text.txt = in_richTextBox.Text;

            out_richTextBox.Clear();

            string variant = comboBox1.SelectedItem.ToString();
            if (comboBox1.SelectedItem.ToString() == "Свой")
                variant = textBox1.Text;

            out_richTextBox.Text = text.decrypt(Int32.Parse(textBox_a.Text), Int32.Parse(textBox_b.Text), text.txt, variant);

        }
    }
}
