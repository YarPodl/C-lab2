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
            //APSs.Add(new APS("Наша станция", 12345, "ул. Рождественского, 51", 1100, 35.50, "Стандартный", 900));
            listBox1.Items.Add(new APS("Наша станция", 12345, "ул. Рождественского, 51", 1100, 35.50, "Стандартный", 900));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();
            if (s != null)
            {
                listBox1.Items.Add(new APS(s));
            }
        }
    }
}
