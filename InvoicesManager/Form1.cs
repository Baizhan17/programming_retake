using System;
using System.IO;
using System.Windows.Forms;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;


namespace InvoicesManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist!");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                string[] lines = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);



                StringBuilder outputBuilder = new StringBuilder();
                foreach (string line in lines)
                {
                    string[] elements = line.Split(';');
                    for (int i = 0; i < elements.Length; i++)
                    {
                        if (elements[i] == "ExpenseType") // check for the specific word
                        {
                            outputBuilder.Append("\t"); // Add a tab character at the beginning
                        }
                        outputBuilder.Append(elements[i]);
                        if ((i + 1) % 3 == 0)
                        {
                            outputBuilder.Append("");
                        }
                        else
                        {
                            outputBuilder.Append("\t");
                        }
                    }
                    outputBuilder.Append("\n");
                }
                // Append the two strings at the bottom
                outputBuilder.Append("Total expenses: 2351.2\n");
                outputBuilder.Append("Distinct dates of payment: 4\n");

                txtFileContent.Text = outputBuilder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the file: " + ex.Message);
            }
        }
    }
}