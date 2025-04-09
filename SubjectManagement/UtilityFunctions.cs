using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SubjectManagement
{
    public static class UtilityFunctions
    {
        public static void ShowException(Exception ex, string sqlCommand = "")
        {
            string error = $"Exception on command: {sqlCommand}\n\n " +
                        $"Error: {ex.Message}\n\n" +
                        $"Exception Type: {ex.GetType()}\n\n" +
                        $"Stack Trace: {ex.StackTrace}";
                         ;
            MessageBox.Show(
                error, "Error");
            StreamWriter writer = new StreamWriter("error.txt");
            writer.WriteLine(error);
            writer.Close();
            
        }

        public static string IR(string name)
        {
            // use the idea of IR: an representation that database / object can agree on
            return name.Replace("_", "").ToUpper();
        }
    }
}


