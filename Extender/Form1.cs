﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dg = new FolderBrowserDialog();
            dg.ShowNewFolderButton = false;
            dg.RootFolder = System.Environment.SpecialFolder.Desktop;
            if (dg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dg.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(textBox1.Text);
                System.IO.FileInfo[] files = directory.GetFiles();
                
                foreach (System.IO.FileInfo file in files) {
                    file.MoveTo(file.FullName.Replace(file.Extension, textBox2.Text));
                }

                MessageBox.Show("Replaced all extensions", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Select an extension", "Missing extension", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
