/*
TimeBallProblems.cs
Solve time ball problem Program.

Revision History
Junning Zeng, 2015.04.14: Created

Copyright Junning Zeng, Marius Tocitu, Pranayr Sheth. All rights reserved.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AssignmentFinal//junning zeng
{
    public partial class Form1 : Form
    {
  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly= true;
            textBox2.ReadOnly = true;     
        }


        private void textBox1_TextChanged(object sender, EventArgs e)//when text changes, call functions to deal with user input data.
        {
                try
                { 
                    if ((Convert.ToInt64(textBox1.Text) >= 27) &&( Convert.ToInt64(textBox1.Text) <= 127))
                    {
                        textBox3.Text = (textBox1.Text+" balls cycle after " + TimeBallProblemTools.TimeBall(Convert.ToInt32(textBox1.Text)) + " days.");
                    }
                else { textBox3.Text = ("Valid numbers are in the range 27 to 127!"); }

                }
                catch { textBox3.Text = ("only numbers input allowed!"); }      
        }



      


        





    }

}
