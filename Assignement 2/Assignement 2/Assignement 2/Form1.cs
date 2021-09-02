using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignement_2
{
    public partial class Form1 : Form
    {
        Login login;
        User loginUser;
        string fileContent = string.Empty;
        string filePath = string.Empty;

        public Form1(Login login, User loginUser)
        {
            this.login = login;
            this.loginUser = loginUser;
            InitializeComponent();
            setEditAllow();
            updateLoginUsername();
        }

        private void setEditAllow()
        {
            if(loginUser.getUserType() == "View")
            {
                richTextBox1.ReadOnly = true;
                richTextBox1.Enabled = false;
            }
        }

        private void updateLoginUsername()
        {
            toolStripLabel2.Text = this.loginUser.getUsername();
        }

        

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newFileButton();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFileButton();
        }

        private void newFileButton()
        {
            filePath = string.Empty;
            fileContent = string.Empty;
            richTextBox1.Rtf = fileContent;
        }

        private void openFileButton()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "\\RTFiles";
            openFileDialog1.Title = "Open a TextFile";
            openFileDialog1.Filter = "RTF files (*.rtf)|*.rtf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            richTextBox1.Rtf = fileContent;
        }

        private void saveFile()
        {
            if (filePath == string.Empty)
                saveAsFileButton();
            else
                richTextBox1.SaveFile(filePath);
            
        }

        private void saveAsFileButton()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.InitialDirectory = "\\RTFiles";
            saveFileDialog1.Title = "Save as RTF";
            saveFileDialog1.Filter = "RTF files (*.rtf)|*.rtf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
                richTextBox1.SaveFile(filePath);
            }
        }

        private void rtbLoadFile(string path)
        {
            richTextBox1.LoadFile(path);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFileButton();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileButton();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFileButton();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            saveAsFileButton();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toggleBold();
        }

        private void toggleBold()
        {
            Font currentFont = richTextBox1.SelectionFont;
            if (richTextBox1.SelectionFont.Bold == true)
            {
                richTextBox1.SelectionFont = new Font(
                currentFont.FontFamily,
                currentFont.Size,
                currentFont.Style ^ FontStyle.Bold
                );
            }
            else
            {
                richTextBox1.SelectionFont = new Font(
                currentFont.FontFamily,
                currentFont.Size,
                currentFont.Style | FontStyle.Bold
                );
            }
        }

        private void toggleUnderline()
        {
            Font currentFont = richTextBox1.SelectionFont;
            if (richTextBox1.SelectionFont.Underline == true)
            {
                richTextBox1.SelectionFont = new Font(
                currentFont.FontFamily,
                currentFont.Size,
                currentFont.Style ^ FontStyle.Underline
                );
            }
            else
            {
                richTextBox1.SelectionFont = new Font(
                currentFont.FontFamily,
                currentFont.Size,
                currentFont.Style | FontStyle.Underline
                );
            }
        }

        private void toggleItalic()
        {
            Font currentFont = richTextBox1.SelectionFont;
            if (richTextBox1.SelectionFont.Italic == true)
            {
                richTextBox1.SelectionFont = new Font(
                currentFont.FontFamily,
                currentFont.Size,
                currentFont.Style ^ FontStyle.Italic
                );
            }
            else
            {
                richTextBox1.SelectionFont = new Font(
                currentFont.FontFamily,
                currentFont.Size,
                currentFont.Style | FontStyle.Italic
                );
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            toggleItalic();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            toggleUnderline();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textSizeChange();
        }

        private void textSizeChange()
        {
            float size = Convert.ToInt32(toolStripComboBox1.Text);
            Font current = richTextBox1.SelectionFont;
            richTextBox1.SelectionFont = new Font(current.FontFamily, size, current.Style);
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutButton();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            aboutButton();
        }

        private void aboutButton()
        {
            About a1 = new About();
            a1.Show();
        }
    }

    public class Functions
    {
        public Functions()
        {
            
        }

        
    }
}
