/*
 * Author: Gregory Waters
 * File name: RoundRegister.cs
 * Purpose: Provides the RoundRegister.dll file that MainWindow uses to handle the cash drawer
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace RoundRegister
{
    public class RoundRegister
    {


    }
    /// <summary>
    /// Cash handling class
    /// </summary>
    public static class CashDrawer
    {
        public static int Quarters = 20;
        public static int Dimes = 20;
        public static int Nickles = 20;
        public static int Pennies = 20;
        public static int Singles = 20;
        public static int Fives = 20;
        public static int Tens = 20;
        public static int Twenties = 20;

        /// <summary>
        /// Provides a reset for the static class for testing purposes
        /// </summary>
        public static void Reset()
        {
            Quarters = 20;
            Dimes = 20;
            Nickles = 20;
            Pennies = 20;
            Singles = 20;
            Fives = 20;
            Tens = 20;
            Twenties = 20;
        }

    }

    public class CardReader
    {
        public CardReader()
        {

        }

        /// <summary>
        /// Returns enum result of card transaction
        /// though the design document did not state which one to send or how to handle each
        /// </summary>
        /// <returns></returns>
        public CardTransactionResult RunCard()
        {
            return CardTransactionResult.Approved;
        }
    }

    /// <summary>
    /// Enum class for card transactions
    /// </summary>
    public enum CardTransactionResult
    {
        Approved,
        Declined,
        ReadError,
        InsufficientFunds,
        IncorrectPin
    }

    /// <summary>
    /// Recipt printer class that outputs text file
    /// </summary>
    public class ReciptPrinter
    {
        private StreamWriter outputStream;
        private List<string> reciptList;
        private bool isNew = true;
        public ReciptPrinter()
        {
            reciptList = new List<string>();
        }

        /// <summary>
        /// Simple boolean to know when to create a new list as to not
        /// duplicate orders in the txt file
        /// </summary>
        /// <param name="text"></param>
        public void PrintLine(string text)
        {
            if (isNew)
            { 
                reciptList = new List<string>();
                isNew = false;
                reciptList.Add(text);
            }
            else
            {
                reciptList.Add(text);
            }
        }

        /// <summary>
        /// CutTape method, handles the streamwriter to append the master list
        /// </summary>
        /// <returns></returns>
        public List<string> CutTape()
        {
            outputStream = new StreamWriter("recipts.txt", true);
            isNew = true;
            foreach(string s in reciptList)
            {
                outputStream.WriteLine(s);
            }
            outputStream.WriteLine("");
            outputStream.Close();
            return reciptList;
        }
    }
}
