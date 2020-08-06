using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace otoparkotomasyon
{
    static class Program
    {
        public static string sqlConnection = @"Data Source=DESKTOP-6RMTPS6;Initial Catalog=otopark;Integrated Security=True;Connect Timeout=15;";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
