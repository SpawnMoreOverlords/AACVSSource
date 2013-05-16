using System;
using System.Windows.Forms;

namespace FinalYearProject
{
    class OpenFile
    {

        public static String getFileName()
        {
            String fileName = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "MP3 Files (*.mp3)|*.mp3|WAV Files (*.wav)|*.wav|WMA Files (*.wma)|*.wma|Any file (*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //Store the file name in a global variable:
                return fileName = openFile.FileName;
            }
            return "Error";
        }
    }
}
