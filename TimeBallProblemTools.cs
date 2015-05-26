/*
TimeBallProblemTools.cs
Solve time ball problem Program.

Revision History
Junning Zeng,Marius Tocitu, Pranay Sheth, Dewang Patel, 2015.04.14: Created

Copyright Junning Zeng,Marius Tocitu, Pranay Sheth, Dewang Patel. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace AssignmentFinal
{
    class TimeBallProblemTools
    {

        static public string TimeBall(int totalBalls)// function for calculate result for time ball problems
        {
           double halfDays=0;//caculate for every 12 hours
           bool isover = true;
           List<BALL> copyQueue = new List<BALL>();//copy of the queue
           List<BALL> queue=new List<BALL>();//the queue for all the balls
           List<BALL> templateList = new List<BALL>();// the template order for a 24hours circle
           List<BALL> hours = new List<BALL>();
           List<BALL> fivemin = new List<BALL>();
           List<BALL> min = new List<BALL>();    
         
            for(int i=0;i<totalBalls;i++)//initialize the queues
            {
                addList(ref queue, i);
                addList(ref templateList, i);
                addList(ref copyQueue, i);
            }

           while (true)//simulate every min changes to find the order after 24 hourse
           {
               addList(ref min, templateList[0].ballNumber);
               deleteList(ref templateList, 0);
                  if (min.Count == 5)//If 5 balls in the min track,
                    {
                        addList(ref fivemin, min[4].ballNumber);//move the last ball onto the 5min track
                        deleteList(ref min, 4);

                        for (int i = 3; i >= 0; i--)  // requeue the othermin balls
                        {
                            addList(ref templateList, min[i].ballNumber);
                            deleteList(ref min, i);//empty the min track
                        }
                    }

                    if (fivemin.Count == 12)//If 12 balls in the 5-min track,
                    {
                        addList(ref hours, fivemin[11].ballNumber);//move the last ball onto the hour track
                        deleteList(ref fivemin, 11);

                        for (int i = 10; i >= 0; i--)  // requeue the other  5-min balls
                        {
                            addList(ref templateList, fivemin[i].ballNumber);
                            deleteList(ref fivemin, i);//empty the 5-min track
                        }
                     }


                    if (hours.Count == 12)// If 12 moveable balls in the hour track,
                    {
                        for (int i = 10; i >= 0; i--)// requeue 11 hour balls
                        {
                            addList(ref templateList, hours[i].ballNumber);
                            deleteList(ref hours, i);//empty the hours track
                        }

                        addList(ref templateList, hours[0].ballNumber);// requeue the last hour balls
                        deleteList(ref hours, 0);
                       halfDays++;
                      if (halfDays == 2) //if it reaches 24 hours, break the loop
                        {
                         if (templateList.Count == totalBalls)
                          {
                             for (int i = 0; i < totalBalls; i++)//check
                              {
                                    if (templateList[i].ballNumber != i)
                                      { isover = false; }
                              }
                             if (isover == true) { return Convert.ToString(halfDays / 2); }
                             else { isover = true; }
                           }
                          break;
                         }
                     }            
            }
           halfDays = 0;// initialize the count

           while (true)//loop for every 24 hours to find the days all the ball back to its orignal position
           {
               for (int i = 0; i < totalBalls; i++)//one day loop
               {
                   copyQueue[i] = queue[templateList[i].ballNumber];   
               }
               for (int i = 0; i < totalBalls; i++)//copy the result to queue
               {
                   queue[i] = copyQueue[i];
               }

               halfDays=halfDays+2;
               for (int i = 0; i < totalBalls; i++)//check if all the ball backs to its orignal position
               {
                   if (queue[i].ballNumber != i)
                   { isover = false; }
               }
               if (isover == true) { break; }
               else { isover = true; }
           }
            return Convert.ToString(halfDays/2);
        }

        private static void deleteList(ref List<BALL> temp, int position)//used for delete element in certain list<t>
        {
            int k = temp[temp.Count - 1].ballNumber;
            for (int i = position; i < temp.Count - 1; i++)
            {
                temp[i].ballNumber = temp[i + 1].ballNumber;
            }
            temp.Remove(temp[temp.Count - 1]);
        }

        private static void addList(ref List<BALL> temp,  int ballNumber)//used for delete element in certain list<t>
        {
            BALL tempball = new BALL();
            tempball.ballNumber = ballNumber;
            temp.Add(tempball);
        }

    }
}
