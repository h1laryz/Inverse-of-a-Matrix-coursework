using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            sizebox.Items.Add("2x2");
            sizebox.Items.Add("3x3");
            sizebox.Items.Add("4x4");
            sizebox.Items.Add("5x5");
            if(sizebox.SelectedIndex != -1)
            {
                HideExtra();
            }
        }
        private void HideExtra()
        {
            if (sizebox.SelectedItem.ToString() == "2x2")
            {
                elem13.Hide();
                elem14.Hide();
                elem15.Hide();
                elem23.Hide();
                elem24.Hide();
                elem25.Hide();
                row3.Hide();
                row4.Hide();
                row5.Hide();
            }
            else if (sizebox.SelectedItem.ToString() == "3x3")
            {
                if (!elem13.Visible)
                {
                    elem13.Show();
                    elem23.Show();
                    row3.Show();
                }
                elem14.Hide();
                elem15.Hide();
                elem24.Hide();
                elem25.Hide();
                elem34.Hide();
                elem35.Hide();
                row4.Hide();
                row5.Hide();
            }
            else if (sizebox.SelectedItem.ToString() == "4x4")
            {
                if (!elem13.Visible)
                {
                    elem13.Show();
                    elem23.Show();
                    row3.Show();
                }
                if (!elem14.Visible)
                {
                    elem14.Show();
                    elem24.Show();
                    elem34.Show();
                    row4.Show();
                }
                elem15.Hide();
                elem25.Hide();
                elem35.Hide();
                elem45.Hide();
                row5.Hide();
            }
            else if (sizebox.SelectedItem.ToString() == "5x5")
            {
                if (!elem13.Visible)
                {
                    elem13.Show();
                    elem23.Show();
                    row3.Show();
                }
                if (!elem14.Visible)
                {
                    elem14.Show();
                    elem24.Show();
                    elem34.Show();
                    row4.Show();
                }
                if (!elem15.Visible)
                {
                    elem15.Show();
                    elem25.Show();
                    elem35.Show();
                    elem45.Show();
                    row5.Show();
                }
            }
            int size = Convert.ToInt32(sizebox.SelectedItem.ToString().Remove(1));
        }

        private void sizebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideExtra();
        }
    }
}
