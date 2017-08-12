﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Application Name: Drunk PC
/// Description: Application that generates erratic mouse and keyboard movements and input and generates system sounds and fake dialogs to confuse the user
/// Topics:
///     1) Threads
///     2) System.Windows.Forms namespace & assembly
///     3) Hidden application
/// </summary>

namespace DrunkPC
{
    class Program
    {
        // Set _random globally
        //      The _ is meant to indicate global
        public static Random _random = new Random();

        /// <summary>
        /// Entry point for prank application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("DrunkPC Prank Application by: BZ");

            // Create all threads that manipulate all of the inputs and outputs
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopupThread = new Thread(new ThreadStart(DrunkPopupThread));


            // Start all of the threads
            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopupThread.Start();

            // Wait for user input
            Console.Read();

            // Kill all threads and exit application
            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPopupThread.Abort();

        }  // closes main


        #region Thread Functions
        /// <summary>
        /// This thread will randomly affect the mouse movements to screw with the end user
        /// </summary>
        public static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            while(true)
            {
                Console.WriteLine(Cursor.Position.ToString());

                // Generate the random amount to move the cursor on X and Y
                moveX = _random.Next(50) - 25;
                moveY = _random.Next(50) - 25;

                // Change mouse cursor position to new random coordinates
                Cursor.Position = new System.Drawing.Point(
                    Cursor.Position.X + moveX, 
                    Cursor.Position.Y + moveY);

                
                Thread.Sleep(50);

            }  // closes while loop
        }  // closes DrunkMouseThread



        /// <summary>
        /// This will generatet random keyboard output to screw with the end user
        /// </summary>
        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");

            while (true)
            {

                Thread.Sleep(500);

            }  // closes while loop
        }  // closes DrunkKeyboardThread


        /// <summary>
        /// This will play system sounds at random to screw with the end user
        /// </summary>
        public static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");

            while (true)
            {
                Thread.Sleep(500);

            }  // closes while loop
        }  // closes DrunkSoundThread


        /// <summary>
        /// This thread will popup fake error notifications
        /// </summary>
        public static void DrunkPopupThread()
        {
            Console.WriteLine("DrunkPopupThread Started");

            while (true)
            {
                Thread.Sleep(500);

            }  // closes while loop
        }  // closes DrunkPopupThread
#endregion


    }  // closes program

}  // closes DrunkPC
