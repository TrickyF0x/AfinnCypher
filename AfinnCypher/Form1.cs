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

        class language
        {
            public string txt;
            public string crypt(int a, int b, int a2, int b2, string txt, string lang, bool recurr)
            {
                string coded_string = "", lowertxt;
                char[] code = new char[lang.Length];

                if (gcd(a, lang) == 1)//получаем кодированый алфавит
                {
                    switch (lang)
                    {
                        case "English":
                            { 
                                lowertxt = txt.ToLower();
                                if (recurr == false)
                                {
                                    code = coded_alphabet(a, b, lang);
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
                                else
                                {
                                    int ai, bi;
                                    for (int i = 0; i < lowertxt.Length; ++i)
                                    {
                                        if (i == 0)
                                            code = coded_alphabet(a, b, lang);
                                        else if (i == 1)
                                            code = coded_alphabet(a2, b2, lang);
                                        else
                                        {
                                            ai = (a2 * a) % 26;
                                            bi = (b2 + b) % 26;
                                            code = coded_alphabet(ai, bi, lang);
                                            a = a2;
                                            b = b2;
                                            a2 = ai;
                                            b2 = bi;
                                        }
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
                            }
                        case "Русский":
                            {
                                code = coded_alphabet(a, b, lang);
                                lowertxt = txt.ToLower();
                                if (recurr == true)
                                {
                                    int ai, bi;
                                    for (int i = 0; i < lowertxt.Length; ++i)
                                    {
                                        if (i == 0)
                                            code = coded_alphabet(a, b, lang);
                                        else if (i == 1)
                                            code = coded_alphabet(a2, b2, lang);
                                        else
                                        {
                                            ai = (a2 * a) % 33;
                                            bi = (b2 + b) % 33;
                                            code = coded_alphabet(ai, bi, lang);
                                            a = a2;
                                            b = b2;
                                            a2 = ai;
                                            b2 = bi;
                                        }
                                        if (!coding('а', 'я', txt[i]))
                                        {
                                            coded_string += lowertxt[i];
                                            continue;
                                        }
                                        else
                                            coded_string += code[index_finder(lowertxt[i], lang)].ToString();
                                    }
                                }
                                else
                                {
                                    code = coded_alphabet(a, b, lang);
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
                                return coded_string;
                            }
                        default:
                            {
                                code = coded_alphabet(a, b, lang);
                                if (recurr == false)
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
                                }
                                else
                                {
                                    int ai, bi;
                                    for (int i = 0; i < txt.Length; ++i)
                                    {
                                        if (i == 0)
                                            code = coded_alphabet(a, b, lang);
                                        else if (i == 1)
                                            code = coded_alphabet(a2, b2, lang);
                                        else
                                        {
                                            ai = (a2 * a) % lang.Length;
                                            bi = (b2 + b) % lang.Length;
                                            code = coded_alphabet(ai, bi, lang);
                                            a = a2;
                                            b = b2;
                                            a2 = ai;
                                            b2 = bi;
                                        }
                                        if (lang.LastIndexOf(txt[i]) == -1)
                                        {
                                            coded_string += txt[i];
                                            continue;
                                        }
                                        else
                                            coded_string += code[index_finder(txt[i], lang)].ToString();
                                    }
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

            public string decrypt(int a, int b, int a2, int b2, string txt, string lang, bool recur)
            {
                string decoded_string = "";
                int index = 0, j, eucl, bi;

                if (gcd(a, lang) == 1)
                {                    
                    switch (lang)
                    {
                        case "English":
                            {
                                char[] code = new char[26];
                                code = coded_alphabet(a, b, lang);
                                for (int i = 0; i < txt.Length; ++i)
                                {
                                    if (recur == true)
                                    {
                                        if (i == 0)
                                        {
                                            eucl = evklid(a, 26, lang);
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
                                        else if (i == 1)
                                        {
                                            code = coded_alphabet(a2, b2, lang);
                                            eucl = evklid(a2, 26, lang);
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
                                                index = (eucl * (j - b2)) % 26;
                                                if (index < 0)
                                                    index += 26;
                                                decoded_string += code[index];
                                            }
                                        }
                                        else
                                        {   if (i == 2)
                                            {
                                                a = evklid(a, 26, lang);//1 v -1
                                                a2 = evklid(a2, 26, lang);//2 v -1
                                                eucl = (a2 * a) % 26;//ai
                                            }
                                            else 
                                                eucl = (a2 * a) % 26;//ai  
                                            bi = (b2 + b) % 26;
                                            code = coded_alphabet(eucl, bi, lang);
                                            a = a2;
                                            a2 = eucl; 
                                            b = b2;
                                            b2 = bi;

                                            if (!coding('a', 'z', txt[i]))
                                            {
                                                decoded_string += txt[i];
                                                continue;
                                            }
                                            else
                                            {
                                                j = index_finder(txt[i], lang);

                                                int ne = j - bi;
                                                while (ne < 0)
                                                    ne += 26;

                                                index = (eucl * ne) % 26;//ai*(yi-bi)
                                                decoded_string += char_index_finder(index, lang);//code[index];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        eucl = evklid(a, 26, lang);
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
                                }
                                return decoded_string;
                            }
                        case "Русский":
                            {
                                char[] code = new char[33];
                                code = coded_alphabet(a, b, lang);
                                for (int i = 0; i < txt.Length; ++i)
                                {
                                    if (recur == true)
                                    {
                                        if (i == 0)
                                        {
                                            eucl = evklid(a, 33, lang);
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
                                        else if (i == 1)
                                        {
                                            code = coded_alphabet(a2, b2, lang);
                                            eucl = evklid(a2, 33, lang);
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
                                                index = (eucl * (j - b2)) % 33;
                                                if (index < 0)
                                                    index += 33;
                                                decoded_string += code[index];
                                            }
                                        }
                                        else
                                        {
                                            if (i == 2)
                                            {
                                                a = evklid(a, 33, lang);//1 v -1
                                                a2 = evklid(a2, 33, lang);//2 v -1
                                                eucl = (a2 * a) % 33;//ai
                                            }
                                            else
                                                eucl = (a2 * a) % 33;//ai  
                                            bi = (b2 + b) % 33;
                                            code = coded_alphabet(eucl, bi, lang);
                                            a = a2;
                                            a2 = eucl;
                                            b = b2;
                                            b2 = bi;

                                            if (!coding('а', 'я', txt[i]))
                                            {
                                                decoded_string += txt[i];
                                                continue;
                                            }
                                            else
                                            {
                                                j = index_finder(txt[i], lang);

                                                int ne = j - bi;
                                                while (ne < 0)
                                                    ne += 33;

                                                index = (eucl * ne) % 33;//ai*(yi-bi)
                                                decoded_string += char_index_finder(index, lang);//code[index];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        eucl = evklid(a, 33, lang);
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
                                }
                                return decoded_string;
                            }
                        default:
                            {
                                char[] code = new char[lang.Length];
                                code = coded_alphabet(a, b, lang);
                                for (int i = 0; i < txt.Length; ++i)
                                {
                                    if (recur == true)
                                    {
                                        if (i == 0)
                                        {
                                            eucl = evklid(a, lang.Length, lang);
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
                                        else if (i == 1)
                                        {
                                            code = coded_alphabet(a2, b2, lang);
                                            eucl = evklid(a2, lang.Length, lang);
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
                                                index = (eucl * (j - b2)) % lang.Length;
                                                if (index < 0)
                                                    index += lang.Length;
                                                decoded_string += code[index];
                                            }
                                        }
                                        else
                                        {
                                            if (i == 2)
                                            {
                                                a = evklid(a, lang.Length, lang);//1 v -1
                                                a2 = evklid(a2, lang.Length, lang);//2 v -1
                                                eucl = (a2 * a) % lang.Length;//ai
                                            }
                                            else
                                                eucl = (a2 * a) % lang.Length;//ai  
                                            bi = (b2 + b) % lang.Length;
                                            code = coded_alphabet(eucl, bi, lang);
                                            a = a2;
                                            a2 = eucl;
                                            b = b2;
                                            b2 = bi;

                                            if (lang.LastIndexOf(txt[i]) == -1)
                                            {
                                                decoded_string += txt[i];
                                                continue;
                                            }
                                            else
                                            {
                                                j = index_finder(txt[i], lang);

                                                int ne = j - bi;
                                                while (ne < 0)
                                                    ne += lang.Length;

                                                index = (eucl * ne) % lang.Length;//ai*(yi-bi)
                                                decoded_string += char_index_finder(index, lang);//code[index];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        eucl = evklid(a, lang.Length, lang);
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
                switch (lang)
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

            private char char_index_finder(int index, string lang)
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

        private void clear_button_Click(object sender, EventArgs e)
        {
            in_richTextBox.Clear();
            out_richTextBox.Clear();
        }

        private void textBox_a_TextChanged(object sender, EventArgs e)
        {
            int value;

            if ((!int.TryParse(textBox_a.Text, out value)) && (textBox_a.Text != "") && (textBox_a.Text != " "))
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_a.Text = "1";
            }
        }

        private void textBox_b_TextChanged(object sender, EventArgs e)
        {
            int value;

            if ((!int.TryParse(textBox_b.Text, out value)) && (textBox_b.Text != "") && (textBox_b.Text != " "))
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

            if(radioButton1.Checked == true)
                out_richTextBox.Text = text.crypt(Int32.Parse(textBox_a.Text), Int32.Parse(textBox_b.Text), 0, 0, text.txt, variant, false);
            else
                out_richTextBox.Text = text.crypt(Int32.Parse(textBox_a.Text), Int32.Parse(textBox_b.Text),
                    Int32.Parse(textBox_a2.Text), Int32.Parse(textBox_b2.Text), text.txt, variant, true);

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
            if (comboBox1.Text == "Свой")
                variant = textBox1.Text;

            if (radioButton1.Checked == true)
                out_richTextBox.Text = text.decrypt(Int32.Parse(textBox_a.Text), Int32.Parse(textBox_b.Text),
                    Int32.Parse(textBox_a2.Text), Int32.Parse(textBox_b2.Text), text.txt, variant, false);
            else
                out_richTextBox.Text = text.decrypt(Int32.Parse(textBox_a.Text), Int32.Parse(textBox_b.Text),
                    Int32.Parse(textBox_a2.Text), Int32.Parse(textBox_b2.Text), text.txt, variant, true);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox_a2.Visible = true;
                textBox_b2.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            else
            {
                textBox_a2.Visible = false;
                textBox_b2.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
            }
        }

        private void textBox_a2_TextChanged(object sender, EventArgs e)
        {
            int value;

            if ((!int.TryParse(textBox_a2.Text, out value)) && (textBox_a2.Text != "") && ((textBox_a2.Text != " ")))
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_a.Text = "1";
            }
        }

        private void textBox_b2_TextChanged(object sender, EventArgs e)
        {
            int value;

            if ((!int.TryParse(textBox_b2.Text, out value)) && (textBox_b2.Text != "") && ((textBox_b2.Text != " ")))
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_a.Text = "0";
            }
        }
    }
}
