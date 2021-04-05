/*
 * Author: Gregory Waters
 * File name: CashDrawerIntercs
 * Purpose: Provides an intermediary between the static class CashDrawer and the MainWindow
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace mainWindow
{
    public class CashDrawerInter
    {
        public int Quarters;
        public int Dimes;
        public int Nickles;
        public int Pennies;
        public int Ones;
        public int Fives;
        public int Tens;
        public int Twenties;

        public int cQuarters = 0;
        public int cDimes = 0;
        public int cNickles = 0;
        public int cPennies = 0;
        public int cOnes = 0;
        public int cFives = 0;
        public int cTens = 0;
        public int cTwenties = 0;

        public CashDrawerInter()
        {
            RoundRegister.CashDrawer.Reset();
            Quarters = RoundRegister.CashDrawer.Quarters;
            Dimes = RoundRegister.CashDrawer.Dimes;
            Nickles = RoundRegister.CashDrawer.Nickles;
            Pennies = RoundRegister.CashDrawer.Pennies;

            Ones = RoundRegister.CashDrawer.Singles;
            Fives = RoundRegister.CashDrawer.Fives;
            Tens = RoundRegister.CashDrawer.Tens;
            Twenties = RoundRegister.CashDrawer.Twenties;
        }

        public void Open()
        {
            RoundRegister.CashDrawer.Quarters = Quarters;
            RoundRegister.CashDrawer.Dimes = Dimes;
            RoundRegister.CashDrawer.Nickles = Nickles;
            RoundRegister.CashDrawer.Pennies = Pennies;

            RoundRegister.CashDrawer.Singles = Ones; ;
            RoundRegister.CashDrawer.Fives = Fives;
            RoundRegister.CashDrawer.Tens = Tens;
            RoundRegister.CashDrawer.Twenties = Twenties;
        }

    }
}
