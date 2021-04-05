/*
 * Author: Gregory Waters
 * File name: CashMenu.xaml.cs
 * Purpose: Handles the logic of the cash menu
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mainWindow
{
    /// <summary>
    /// Interaction logic for CashMenu.xaml
    /// </summary>
    public partial class CashMenu : Window
    {
        /// <summary>
        /// public variables that are sent to the window
        /// </summary>
        public CashDrawerInter Drawer;
        public int cQuarters;
        public int cDimes;
        public int cNickles;
        public int cPennies;

        public int cOnes;
        public int cFives;
        public int cTens;
        public int cTwenties;
        public decimal Total = (decimal)0.0;
        public decimal cTotal = (decimal)0.0;
        public decimal ChangeTotal = 0m;

        /// <summary>
        /// Constructor that pulls in necessary information
        /// </summary>
        /// <param name="cdi"></param>
        /// <param name="_total"></param>
        public CashMenu(CashDrawerInter cdi, decimal _total)
        {
            Drawer = cdi;
            Total = _total;
            InitializeComponent();
            this.DataContext = Drawer;
            this.TotalCheck.Content = Total.ToString();
        }

        /// <summary>
        /// Button handler for GetChange
        /// Handles most of the logic and formatting from the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Get_Change_Click(object sender, RoutedEventArgs e)
        {
            cQuarters = Int32.Parse(cQuartersCount.Text);
             cDimes = Int32.Parse(cDimesCount.Text);
            cNickles = Int32.Parse(cNicklesCount.Text);
            cPennies = Int32.Parse(cPenniesCount.Text);

            cOnes = Int32.Parse(cOnesCount.Text);
            cFives = Int32.Parse(cFivesCount.Text);
            cTens = Int32.Parse(cTensCount.Text);
            cTwenties = Int32.Parse(cTwentiesCount.Text);
            //TotalCheck.Content = Total.ToString();
            //cTotalCheck.Content = cTotal.ToString();
            TotalUp();
            //TotalCheck.Content = Total.ToString();
            cTotalCheck.Content = cTotal.ToString();
            DifferenceCheck.Content = (Total - cTotal).ToString();
            GetChange();
        }

        /// <summary>
        /// Method to Total the amount the customer has given
        /// returns void, but updates class members
        /// </summary>
        private void TotalUp()
        {
            cTotal += decimal.Multiply(cQuarters, .25m);
            cTotal += decimal.Multiply(cDimes, .1m);
            cTotal += decimal.Multiply(cNickles, .05m);
            cTotal += decimal.Multiply(cPennies, .01m);

            cTotal += decimal.Multiply(cOnes, 1m);
            cTotal += decimal.Multiply(cFives, 5m);
            cTotal += decimal.Multiply(cTens, 10m);
            cTotal += decimal.Multiply(cTwenties, 20m);

            Drawer.Quarters += cQuarters;
            Drawer.Dimes += cDimes;
            Drawer.Nickles += cNickles;
            Drawer.Pennies += cPennies;

            Drawer.Ones += cOnes;
            Drawer.Fives += cFives;
            Drawer.Tens += cTens;
            Drawer.Twenties += cTwenties;

        }

        /// <summary>
        /// Parses out how much of each currency to hand out
        /// Uses the opposite logic of a modulous opperation
        /// </summary>
        private void GetChange()
        {

            cQuarters = 0;
            cDimes = 0;
            cNickles = 0;
            cPennies = 0;

            cOnes = 0;
            cFives = 0;
            cTens = 0;
            cTwenties = 0; 
            ChangeTotal = decimal.Multiply((Total - cTotal), -1m);
            decimal temp = ChangeTotal;
            while(temp >= 20)
            {
                temp -= 20;
                cTwenties++;
            }
            while (temp >= 10)
            {
                temp -= 10;
                cTens++;
            }
            while (temp >= 5)
            {
                temp -= 5;
                cFives++;
            }
            while (temp >= 1)
            {
                temp -= 1;
                cOnes++;
            }

            while (temp >= .25m)
            {
                temp -= .25m;
                cQuarters++;
            }
            while (temp >= .1m)
            {
                temp -= .1m;
                cDimes++;
            }
            while (temp >= .05m)
            {
                temp -= .05m;
                cNickles++;
            }
            while (temp >= .01m)
            {
                temp -= .01m;
                cPennies++;
            }


            this.cQuartersCounts.Content = cQuarters.ToString();
            this.cDimesCounts.Content = cDimes.ToString();
            this.cNicklesCounts.Content = cNickles.ToString();
            this.cPenniesCounts.Content = cPennies.ToString();
            this.cOnesCounts.Content = cOnes.ToString();
            this.cFivesCounts.Content = cFives.ToString();
            this.cTensCounts.Content = cTens.ToString();
            this.cTwentiesCounts.Content = cTwenties.ToString();

            this.QuarterCount.Content = Drawer.Quarters - cQuarters;
            this.DimesCount.Content = Drawer.Dimes - cDimes;
            this.NicklesCount.Content = Drawer.Nickles - cNickles;
            this.PennyCount.Content = Drawer.Pennies - cPennies;
            this.OnesCount.Content = Drawer.Ones - cOnes;
            this.FivesCount.Content = Drawer.Fives - cFives;
            this.TensCount.Content = Drawer.Tens - cTens;
            this.TwentiesCount.Content = Drawer.Twenties - cTwenties;

        }

        /// <summary>
        /// Closes the window at any time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
