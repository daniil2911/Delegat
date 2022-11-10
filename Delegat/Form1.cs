using AccountClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountClass.Class1;

namespace Delegat
{
    public partial class Form1 : Form
    {
        string message;
        void PrintSimpleMessag(string message) => listBox1.Items.Add(message);
        public Form1()
        {
            InitializeComponent();
        }
        void DisplayMessage(Account sender, AccountEventArgs e)
        {
            Console.WriteLine($"Сумма транзакции: {e.Sum}");
            Console.WriteLine(e.Message);
            Console.WriteLine($"Текущая сумма на счете: {sender.Sum}"); ;
        }
        Account ac;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ac = new Account(Convert.ToInt32(textBox2.Text), textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец счёта: {ac.Fio}, состояние счета: {ac.Sum}");
            MessageBox.Show($"Владелец счёта: {ac.Fio}, состояние счета: {ac.Sum}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ac.Notify += DisplayMessage;
            int x = Convert.ToInt32(textBox2.Text);
            ac.Add(Convert.ToInt32(textBox3.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец счёта: {ac.Fio}, состояние счета: {ac.Sum}");
            ac.Notify -= DisplayMessage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            if (ac.Sum < x)
            {
                ac.Notify += DisplayMessage;
                listBox1.Items.Clear();
                listBox1.Items.Add("На счету недостаточно средств");
                MessageBox.Show("На счету недостаточно средств");
                ac.Notify -= DisplayMessage;

            }
            else
            {
                ac.Notify += DisplayMessage;
                ac.Take(Convert.ToInt32(textBox3.Text));
                listBox1.Items.Clear();
                listBox1.Items.Add($"Владелец счёта: {ac.Fio}, состояние счета: {ac.Sum}");
                ac.Notify -= DisplayMessage;
            }
        }
    }
}
             
    

