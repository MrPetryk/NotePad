using System;
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
        string str;
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               textBox1.Text=File.ReadAllText(ofd.FileName);
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            str = textBox1.SelectedText.ToString();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s;
            s = str.ToString();
            textBox1.Paste(s.ToString());
        }
    }
}
