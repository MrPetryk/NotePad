﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
               DialogResult res= MessageBox.Show("Notepad has some symbols. Save it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = "NoName";
                    sfd.Filter = "Text Files | *.txt";
                    sfd.DefaultExt = "txt";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {                 
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                    }
                }
                
                    textBox1.Clear();
                
            }
        }
    }
}
