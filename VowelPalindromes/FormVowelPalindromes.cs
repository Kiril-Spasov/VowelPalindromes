using System;
using System.IO;
using System.Windows.Forms;

namespace VowelPalindromes
{
    public partial class FormVowelPalindromes : Form
    {
        public FormVowelPalindromes()
        {
            InitializeComponent();
        }


        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string line = "";
            string letter;

            string path = Application.StartupPath + @"\vowels.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    string vowels = "";

                    for (int i = 0; i < line.Length; i++)
                    {
                        letter = line.Substring(i, 1);

                        if (letter == "A" || letter == "E" || letter == "I" || letter == "O" || letter == "U" || letter == "Y")
                        {
                            vowels += letter;
                        }
                    }
                    TxtResult.Text += vowels + " ";
                    TxtResult.Text += CheckForVowelPalindromes(vowels) ? " IS PALINDROME" : " IS NOT A PALINDROME";
                    TxtResult.Text += Environment.NewLine;
                }
            }
        }

        private bool CheckForVowelPalindromes(string word)
        {
            //We compare the first letter with the last and we do the same for all the rest letters of the word.
            for (int i = 0; i < word.Length; i++)
            {
                if (word.Substring(i, 1) != word.Substring(word.Length - (i + 1), 1))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
