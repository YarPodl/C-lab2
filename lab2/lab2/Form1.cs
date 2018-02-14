using System;
using System.Collections.Generic;

namespace lab2
{
    public partial class Form : System.Windows.Forms.Form
    {
        //List<APS> APSs = new List<APS>();
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
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();
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
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int selIndex = listBox1.SelectedIndex;
            APS selectObject = (APS)listBox1.Items[selIndex];
            try
            {
                selectObject.name = textBox1.Text;
                selectObject.number = int.Parse(textBox2.Text);
                selectObject.addres = textBox3.Text;
                selectObject.countUsers = int.Parse(textBox4.Text);
                selectObject.usersPay = double.Parse(textBox5.Text);
                selectObject.tarif = textBox6.Text;
                selectObject.freeLines = int.Parse(textBox7.Text);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Численные параметры заданы некорректно");
            }
            // Необходимо для обновления названия в listbox
            // name присваивается !!! в качестве произвольного значения
            listBox1.DisplayMember = selectObject.name; 
            listBox1.SelectedIndex = selIndex;

        }
    }
}
