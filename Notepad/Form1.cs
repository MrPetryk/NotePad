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
      

        public Form1()
        {
            InitializeComponent();
          //  tsize = (int)textBox1.Font.Size;
        }

        string str;
       

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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (str != null)
            {
                pasteToolStripMenuItem.Enabled= true;
            }
            else { pasteToolStripMenuItem.Enabled = false; }

            if (textBox1.CanUndo == false){
                undoToolStripMenuItem.Enabled = false;
            }else { undoToolStripMenuItem.Enabled = true; }

        
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            textBox1.Undo();
        }

        float currentSize;

        private void textSizeUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSize = textBox1.Font.Size;
            currentSize += 2.0F;
            textBox1.Font = new Font(textBox1.Font.Name, currentSize,
                textBox1.Font.Style, textBox1.Font.Unit);
        }

        private void textSizeDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSize = textBox1.Font.SizeInPoints;
            currentSize -= 1;
            textBox1.Font = new Font(textBox1.Font.Name, currentSize,
                textBox1.Font.Style);
        }
    }
}
