/*
Program.cs
Solve time ball problem Program.

Revision History
Junning Zeng,Marius Tocitu, Pranay Sheth, Dewang Patel 2015.04.14: Created

Copyright Junning Zeng,Marius Tocitu, Pranay Sheth, Dewang Patel. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentFinal
{
    static class Program
    {
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
