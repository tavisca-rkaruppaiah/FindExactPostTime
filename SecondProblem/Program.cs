﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProblem
{
    public static class ForumPostEasy
    {
       
        static int[] sumTime;
        static int index = 0;


        public static string GetCurrentTime(string[] exactPostTime, string[] showPostTime)
        {

            if(exactPostTime.Length > 1)
            {
                for (int i = 0; i < exactPostTime.Length-1; i++)
                {
                    if (exactPostTime[i].Equals(exactPostTime[i+1]))
                    {
                        if (!showPostTime[i].Equals(showPostTime[i+1]))
                        {
                            return "impossible";
                        }
                    }
                }
            }

            string[] results = new string[exactPostTime.Length];
            sumTime = new int[exactPostTime.Length];
            int minValueIndex = 0;
            for(int i =0; i< exactPostTime.Length; i++)
            {
                int showTime;

                int hour = int.Parse(exactPostTime[i].Split(':')[0]);
                int minutes = int.Parse(exactPostTime[i].Split(':')[1]);
                int seconds = int.Parse(exactPostTime[i].Split(':')[2]);


                if(showPostTime[i].Contains("seconds"))
                {
                    showTime = 59;
                    results[i] = AddTime("seconds", hour, minutes, seconds, showTime);
                }
                else if(showPostTime[i].Contains("minutes"))
                {
                    int.TryParse(showPostTime[i].Split(' ')[0], out showTime);

                    results[i] = AddTime("minutes", hour, minutes, seconds, showTime);


                }
                else if(showPostTime[i].Contains("hours"))
                {
                    int.TryParse(showPostTime[i].Split(' ')[0], out showTime);

                    results[i] = AddTime("hours", hour, minutes, seconds, showTime);
                }          

            }          
          
            for(int i=0; i<sumTime.Length; i++)
            {
                int minValueIndexValue = sumTime[0];

                if(minValueIndexValue>sumTime[i])
                {
                    minValueIndexValue = sumTime[i];
                    minValueIndex = i;
                }
            }




            return results[minValueIndex];
        }

        public static string AddTime(string timeVariable, int hour, int minutes, int seconds, int showTime)
        {
            
            if(timeVariable.Equals("seconds"))
            {
                seconds= seconds + showTime;
            }
            else if(timeVariable.Equals("minutes"))
            {
                minutes = minutes + showTime;
            }
            else if(timeVariable.Equals("hours"))
            {
                hour = hour + showTime;
            }

            

            if (seconds > 60)
            {
                minutes = minutes + 1;
                seconds = seconds % 60;
            }
            if (minutes > 60)
            {
                hour = hour + 1;
                minutes = minutes % 60;
            }

            if (hour > 23)
            {
                hour = hour % 24;

            }

            
            sumTime[index++] = hour + minutes + seconds;


            return hour + ":" + minutes + ":" + seconds;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Array Limits");
            string arraySize = Console.ReadLine();
            int length = int.Parse(arraySize);
            string[] exactPostTime = new string[length];
            string[] showPostTime = new string[length];

            Console.WriteLine("Enter the exact post time");

            for(int i=0; i<length; i++)
            {
                exactPostTime[i] = Console.ReadLine();
                
            }

            Console.WriteLine("Enter the Show time");

            for(int i=0; i<length; i++)
            {
                showPostTime[i] = Console.ReadLine();
            }

            
            Console.WriteLine(ForumPostEasy.GetCurrentTime(exactPostTime, showPostTime));


        }
    }
}
