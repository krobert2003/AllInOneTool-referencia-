using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllInOneTool_referencia_
{
    static class Program
    {
        static public ToDoList ToDoList = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AllInOneTool());
            ToDoList = new ToDoList();
        }
    }
}
