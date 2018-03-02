using System;

namespace lab2
{
    
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(new APS("Наша станция", 12345, "ул. Рождественского, 51", 1100, 35.50, "Стандартный", 900));
            textBoxCount.Text = APS.count.ToString();
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Форма для ввода имени
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();    // Строка, введенная пользователем
            if (s != null)
            {
                listBox1.Items.Add(new APS(s));
            }
            textBoxCount.Text = APS.count.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            APS selectObject = (APS)listBox1.Items[listBox1.SelectedIndex];
            textBox1.Text = selectObject.name;
            textBox2.Text = selectObject.number.ToString();
            textBox3.Text = selectObject.addres;
            textBox4.Text = selectObject.countUsers.ToString();
            textBox5.Text = selectObject.usersPay.ToString();
            textBox6.Text = selectObject.tarif;
            textBox7.Text = selectObject.freeLines.ToString();

            labelWarning.Text = "";
            textBox1.BackColor = System.Drawing.Color.White;
            textBox2.BackColor = System.Drawing.Color.White;
            textBox3.BackColor = System.Drawing.Color.White;
            textBox4.BackColor = System.Drawing.Color.White;
            textBox5.BackColor = System.Drawing.Color.White;
            textBox6.BackColor = System.Drawing.Color.White;
            textBox7.BackColor = System.Drawing.Color.White;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int selIndex = listBox1.SelectedIndex;
            APS selectObject = (APS)listBox1.Items[selIndex];
            bool isErrors = false;
            int m1, m2, m4;
            int.TryParse(textBox2.Text, out m1);
            if (int.TryParse(textBox2.Text, out m1) && (m1 >= 0))
            {
                textBox2.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox2.Focus();
                textBox2.BackColor = System.Drawing.Color.Red;
            }
            if (int.TryParse(textBox4.Text, out m2) && (m2 >= 0))
            {
                textBox4.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox4.Focus();
                textBox4.BackColor = System.Drawing.Color.Red;
            }
            double m3;
            if (double.TryParse(textBox5.Text, out m3) && (m3 >= 0))
            {
                textBox5.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox5.Focus();
                textBox5.BackColor = System.Drawing.Color.Red;
            }
            if (int.TryParse(textBox7.Text, out m4) && (m4 >= 0))
            {
                textBox7.BackColor = System.Drawing.Color.White;
            }
            else
            {
                isErrors = true;
                textBox7.Focus();
                textBox7.BackColor = System.Drawing.Color.Red;
            }
            if (isErrors)
            {
                labelWarning.Text = "Численные параметры заданы некорректно";
            }
            else
            {
                selectObject.name = textBox1.Text;
                selectObject.number = m1;
                selectObject.addres = textBox3.Text;
                selectObject.countUsers = m2;
                selectObject.usersPay = m3;
                selectObject.tarif = textBox6.Text;
                selectObject.freeLines = m4;
                labelWarning.Text = "";
                // Необходимо для обновления названия в listbox
                // name присваивается в качестве произвольного!!! значения
                listBox1.DisplayMember = selectObject.name;
                listBox1.SelectedIndex = selIndex;
            }

        }

        
    }
}
