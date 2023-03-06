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

namespace NotepadProject
{
    public partial class Form1 : Form
    {
        readonly string defaultfileName = "textFile.txt";
        readonly string defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        string fullpathAndName = String.Empty;
        OpenFileDialog dialog = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
            lightRB.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(fullpathAndName))
            {
                streamWriter.WriteLine(textBox1.Text);
            }
        }

        private void openBTN_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        public void SelectFile()
        {
            dialog.ShowDialog();

            if (dialog.FileName == String.Empty)
            {
                fullpathAndName = String.Concat(defaultFilePath, "\\", defaultfileName);
                MessageBox.Show($"The file will be stored at {fullpathAndName}", "Notepad Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fullpathAndName = dialog.FileName;
            }

            location.Text = fullpathAndName;

            try
            {
                string readFromFile = File.ReadAllText(fullpathAndName);
                textBox1.Text = readFromFile;
            }
            catch
            {

            }
        }


        private void darkRB_MouseDown(object sender, MouseEventArgs e)
        {
            tabPage2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E6E4E4");
            tabPage2.BackColor = System.Drawing.ColorTranslator.FromHtml("#343434");
            openBTN.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E6E4E4");
            openBTN.BackColor = System.Drawing.ColorTranslator.FromHtml("#3d3d3d");

            textBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E6E4E4");
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#343434");
        }

        private void lightRB_MouseDown(object sender, MouseEventArgs e)
        {
            tabPage2.ForeColor = SystemColors.WindowText;
            tabPage2.BackColor = SystemColors.Window;
            openBTN.ForeColor = SystemColors.WindowText;
            openBTN.BackColor = SystemColors.Window;

            textBox1.ForeColor = SystemColors.WindowText;
            textBox1.BackColor = SystemColors.Window;
        }
    }
}
