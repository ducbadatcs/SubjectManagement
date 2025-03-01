using System;
using System.IO;
using System.Windows.Forms;

namespace SubjectManagement
{
    public static class UtilityFunctions
    {
        public static void ShowException(Exception ex, string sqlCommand = "")
        {
            string error = "";

            if (sqlCommand.Length > 0)
            {
                error += "Error while trying to execute SQL Command: " + sqlCommand + "\n\n";
            }
            // this is 1000000 times better than pasting this exact same code everywhere
            error += @"Message:" + ex.Message + "\n\nStack Trace:" + ex.StackTrace;
            MessageBox.Show(
                error, "Error");
            StreamWriter writer = new StreamWriter("error.txt");
            writer.WriteLine(error);
            writer.Close();
            Application.Exit();
        }

        /// <summary>
        /// convert a name in snake_case to PascalCase
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ConvertSnakeCaseToPascalCase(string name)
        {
            var spc = name.Split('_');
            string result = "";
            for (int i = 0; i < spc.Length; i++)
            {
                spc[i] = spc[i].Trim().ToLower();
                // we don't have a method to ToUpper a char, fuck you
                string v = spc[i][0].ToString().ToUpper() + spc[i].Substring(1);
                result += v;
            }
            return result;
        }
    }

}
