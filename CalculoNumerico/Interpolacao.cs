﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoNumerico
{
    public partial class Interpolacao : Form
    {
        public Interpolacao()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] xd = (double[])Array.ConvertAll(arrayX.Lines[0].Split(' '), new Converter<string, double>(Double.Parse));

            double[] yd = (double[])Array.ConvertAll(arrayY.Lines[0].Split(' '), new Converter<string, double>(Double.Parse));

            double x = double.Parse(valorX.Text);

            resposta.Text = Convert.ToString(Lagrange(x, xd, yd));
        }

        static public double Lagrange(double x, double[] xd, double[] yd)
        {
            if (xd.Length != yd.Length)
            {
                throw new ArgumentException("Arrays must be of equal length."); //$NON-NLS-1$
            }
            double sum = 0;
            for (int i = 0, n = xd.Length; i < n; i++)
            {
                if (x - xd[i] == 0)
                {
                    return yd[i];
                }
                double product = yd[i];
                for (int j = 0; j < n; j++)
                {
                    if ((i == j) || (xd[i] - xd[j] == 0))
                    {
                        continue;
                    }
                    product *= (x - xd[j]) / (xd[i] - xd[j]);
                }
                sum += product;
            }
            return sum;
        }

        private void btnSistemas_Click(object sender, EventArgs e)
        {
            Form1 sistemas = new Form1();
            this.Hide();
            sistemas.Show();
        }
    }
}