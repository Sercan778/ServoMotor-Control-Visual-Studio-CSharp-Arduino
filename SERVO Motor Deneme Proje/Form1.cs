using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SERVO_Motor_Deneme_Proje
{
    public partial class Form1 : Form
    {
        SerialPort port;
        public Form1()
        {
            InitializeComponent();
            init();
            groupBox2.Visible = false; 
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }
        private void init()
        {
            port = new SerialPort();
            port.PortName = "COM5";
            port.BaudRate = 9600;
            try
            {
                port.Open();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    pictureBox1.Visible = false; pictureBox2.Visible = true; pictureBox3.Visible = false; pictureBox4.Visible = true;
                    groupBox2.Visible = true; groupBox2.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Seri Port Seçiniz");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            timer1.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = false; pictureBox3.Visible = true; pictureBox4.Visible = false;
            groupBox2.Visible = false;
            port.Close();
            serialPort1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = comboBox1.SelectedItem.ToString();
            serialPort1.PortName = x;
            serialPort1.BaudRate = 9600;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port.IsOpen == true)
            {
                serialPort1.Close();
                port.Close();
            }
        }

        private void Val_trackBar_Scroll(object sender, EventArgs e)
        {
            if (port.IsOpen == true)
            {
                port.WriteLine(Val_trackBar.Value.ToString());
                Değer_label.Text = "Derece";
                textBox1.Text = Val_trackBar.Value.ToString();

            }
        }
    }
}
