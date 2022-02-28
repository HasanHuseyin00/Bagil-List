using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        int a = 0;
        int b = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            
            int sayi = 0;
            foreach(var item in textBox1.Text.Split(','))
            {
                sayi += 1;
            }
            int[] dizi = new int[sayi];
            foreach (var item in textBox1.Text.Split(','))
            {
                int alinan=Convert.ToInt32(item);
                dizi[i] = alinan;
                i += 1;
            }

            for (int j=0 ; j < dizi.Length; j++)
            {

            Button btn = new Button();
            btn.Name = "btn"+j.ToString();
            panel1.Controls.Add(btn);
            btn.Location = new Point(20 + a, 20+b);
            a = a + 135;
            if(a==540)
            {
                b = b + 35;
                a = 0;
            }
            btn.Click += Btn_Click;
            
            unsafe
            {
                    fixed (int* p = &dizi[j])
                    {
                        int* p2 = p;

                        btn.Size = new Size(120, 30);
                      
                        if (dizi[j]==dizi[dizi.Length-1])
                        {
                            uint adres = (uint)p2;
                            btn.Text = dizi[j] + "   |   " + adres.ToString() + "     <-";
                        }
                        else
                        {
                            uint adres = (uint)p2;
                            btn.Text = dizi[j] + "   |   " + adres.ToString()+"     <-";
                        }
                       
                    }
                }
           }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            panel1.Controls.Remove(btn);
            MessageBox.Show("Düğüm Silindi...");
        }
    }
}
