using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Specialized;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Sides;
using TheFlyingSaucer.Data.Drink;
using mainWindow.EntreeCustomize;
using mainWindow.SideCustomize;
using mainWindow.DrinkCustomize;
using System.IO;

namespace mainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Order Order;
        private List<IOrderItem> itemList;
        private int nextOrderNumber = 1;
        public RoundRegister.ReciptPrinter printer;
        CashDrawerInter cashDrawer = new CashDrawerInter();
        //public StreamWriter outputFile;
        public MainWindow()
        {
            //outputFile = new StreamWriter("receipts.txt");
            printer = new RoundRegister.ReciptPrinter();
            Order = new Order(nextOrderNumber);
            InitializeComponent();
        }

        /// <summary>
        /// Handler for event of Crashed Saucer Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CrashedSaucer_Click(object sender, EventArgs e)
        {
            
            CrashedSaucerCustom cscWindow = new CrashedSaucerCustom();
            CrashedSaucer cs = new CrashedSaucer();
            cscWindow.ShowDialog();
            cs = cscWindow.cs;
            Order.AddItem(cs);
            orderList();
        }
        /// <summary>
        /// Handler for event of Flying Saucer Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FlyingSaucer_Click(object sender, EventArgs e)
        {
            FlyingSaucerCustom fscWindow = new FlyingSaucerCustom();
            FlyingSaucer fs = new FlyingSaucer();
            fscWindow.ShowDialog();
            fs = fscWindow.fs;
            Order.AddItem(fs);
            orderList();
        }
        /// <summary>
        /// Handler for event of Livestock Mutilation Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LivestockMutilation_Click(object sender, EventArgs e)
        {
            LiveStockMutilationCustom lscWindow = new LiveStockMutilationCustom();
            LivestockMutilation ls = new LivestockMutilation();
            lscWindow.ShowDialog();
            ls = lscWindow.ls;
            Order.AddItem(ls);
            orderList();
        }
        /// <summary>
        /// Handler for event of Nothing To See Here Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NothingToSeeHere_Click(object sender, EventArgs e)
        {
            NothingToSeeHereCustom ntshcWindow = new NothingToSeeHereCustom();
            NothingToSeeHere ntsh = new NothingToSeeHere();
            ntshcWindow.ShowDialog();
            ntsh = ntshcWindow.ntsh;
            Order.AddItem(ntsh);
            orderList();
        }
        /// <summary>
        /// Handler for event of Outer Omlette Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OuterOmlette_Click(object sender, EventArgs e)
        {
            OuterOmletteCustom oocWindow = new OuterOmletteCustom();
            OuterOmelette oo = new OuterOmelette();
            oocWindow.ShowDialog();
            oo = oocWindow.oo;
            Order.AddItem(oo);
            orderList();
        }
        /// <summary>
        /// Handler for event of Space Scramble Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpaceScramble_Click(object sender, EventArgs e)
        {
            SpaceScrambleCustom sscWindow = new SpaceScrambleCustom();
            SpaceScramble ss = new SpaceScramble();
            sscWindow.ShowDialog();
            ss = sscWindow.ss;
            Order.AddItem(ss);
            orderList();
        }
        /// <summary>
        /// Handler for event of Crop Circle Oats Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CropCircleOats_Click(object sender, EventArgs e)
        {
            CropCircleOatsCustom ccocWindow = new CropCircleOatsCustom();
            CropCircleOats cco = new CropCircleOats();
            ccocWindow.ShowDialog();
            cco = ccocWindow.cco;
            Order.AddItem(cco);
            orderList();
        }
        /// <summary>
        /// Handler for event of Evicerated Eggs Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EvisceratedEggs_Click(object sender, EventArgs e)
        {
            EviceratedEggsCustom eecWindow = new EviceratedEggsCustom();
            EvisceratedEggs ee = new EvisceratedEggs();
            eecWindow.ShowDialog();
            ee = eecWindow.ee;
            Order.AddItem(ee);
            orderList();
        }
        /// <summary>
        /// Handler for event of Glowing Haystack Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GlowingHaystack_Click(object sender, EventArgs e)
        {
            GlowingHaystackCustom ghcWindow = new GlowingHaystackCustom();
            GlowingHaystack gh = new GlowingHaystack();
            ghcWindow.ShowDialog();
            gh = ghcWindow.gh;
            Order.AddItem(gh);
            orderList();
        }
        /// <summary>
        /// Handler for event of Missing Links Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MissingLinks_Click(object sender, EventArgs e)
        {
            MissingLinksCustom mlcWindow = new MissingLinksCustom();
            MissingLinks ml = new MissingLinks();
            mlcWindow.ShowDialog();
            ml = mlcWindow.ml;
            Order.AddItem(ml);
            orderList();
        }
        /// <summary>
        /// Handler for event of Taken Bacon Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TakenBacon_Click(object sender, EventArgs e)
        {
            TakenBaconCustom tbcWindow = new TakenBaconCustom();
            TakenBacon tb = new TakenBacon();
            tbcWindow.ShowDialog();
            tb = tbcWindow.tb;
            Order.AddItem(tb);
            orderList();
        }
        /// <summary>
        /// Handler for event of You're Toast Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void YoureToast_Click(object sender, EventArgs e)
        {
            YoureToastCustom ytcWindow = new YoureToastCustom();
            YoureToast yt = new YoureToast();
            ytcWindow.ShowDialog();
            yt = ytcWindow.yt;
            Order.AddItem(yt);
            orderList();
        }

        /// <summary>
        /// Handler for event of Liquified Vegitation Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LiquifiedVegetation_Click(object sender, EventArgs e)
        {
            LiquifiedVegitationCustom lvcWindow = new LiquifiedVegitationCustom();
            LiquifiedVegetation lv = new LiquifiedVegetation();
            lvcWindow.ShowDialog();
            lv = lvcWindow.lv;
            Order.AddItem(lv);
            orderList();
        }
        /// <summary>
        /// Handler for event of Saucer Fuel Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SaucerFuel_Click(object sender, EventArgs e)
        {
            SaucerFuelCustom sfcWindow = new SaucerFuelCustom();
            SaucerFuel sf = new SaucerFuel();
            sfcWindow.ShowDialog();
            sf = sfcWindow.sf;
            Order.AddItem(sf);
            orderList();
        }
        /// <summary>
        /// Handler for event of Water Button
        /// Creates new instance of customization window
        /// Passes updated item object back on window close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Water_Click(object sender, EventArgs e)
        {
            WaterCustom wcWindow = new WaterCustom();
            Water w = new Water();
            wcWindow.ShowDialog();
            w = wcWindow.w;
            Order.AddItem(w);
            orderList();
        }


        private void orderList_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            orderList();
        }

        /// <summary>
        /// Tabulates and formats how the output order box is shown
        /// </summary>
        private void orderList()
        {
            orderListBox.Items.Clear();
            orderListBox.Items.Add("Current Order " + Order.Number);
            orderListBox.Items.Add(Order.DateTime);
            for(int i = 0; i < Order.OrderList.Count; i++)
            {
                orderListBox.Items.Add(Order.OrderList[i].Name);
                for(int j = 0; j < Order.OrderList[i].SpecialInstructions.Count; j++)
                {
                    orderListBox.Items.Add("    + " + Order.OrderList[i].SpecialInstructions[j].ToString());
                }
            }
            orderListBox.Items.Add("Subtotal = " + Order.SubTotal);
            orderListBox.Items.Add("Tax = " + Order.Tax);
            orderListBox.Items.Add("Total = " + Order.Total);
            orderListBox.Items.Add("Calories = " + Order.Calories);
        }

        private void orderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Handler for both cash and card payments
        /// Card goes through always, but the enum within the RoundRegister namespace can handle all necessary options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < orderListBox.Items.Count; i++)
            {
                printer.PrintLine(orderListBox.Items[i].ToString());
            }
            if((bool)CardPayment.IsChecked)
            {
                printer.PrintLine("Order Paid by Debit/Credit Card");
            }
            else
            {
                ///
                /// Cash handling section, more messy than it should be, but provides necessary information to the cash transaction menu
                ///
                printer.PrintLine("Order Paid by Cash");
                CashMenu cMenu = new CashMenu(cashDrawer, Order.Total);
                cMenu.QuarterCount.Content = cashDrawer.Quarters;
                cMenu.DimesCount.Content = cashDrawer.Dimes;
                cMenu.NicklesCount.Content = cashDrawer.Nickles;
                cMenu.PennyCount.Content = cashDrawer.Pennies;
                cMenu.OnesCount.Content = cashDrawer.Ones;
                cMenu.FivesCount.Content = cashDrawer.Fives;
                cMenu.TensCount.Content = cashDrawer.Tens;
                cMenu.TwentiesCount.Content = cashDrawer.Twenties;

                cMenu.cQuartersCount.Text = cashDrawer.cQuarters.ToString();
                cMenu.cDimesCount.Text = cashDrawer.cDimes.ToString();
                cMenu.cNicklesCount.Text = cashDrawer.cNickles.ToString();
                cMenu.cPenniesCount.Text = cashDrawer.cPennies.ToString();
                cMenu.cOnesCount.Text = cashDrawer.cOnes.ToString();
                cMenu.cFivesCount.Text = cashDrawer.cFives.ToString();
                cMenu.cTensCount.Text = cashDrawer.cTens.ToString();
                cMenu.cTwentiesCount.Text = cashDrawer.cTwenties.ToString();
                cMenu.ShowDialog();
                printer.PrintLine("Amount Paid: " + cMenu.cTotal);
                printer.PrintLine("Change Given: " + cMenu.ChangeTotal);
            }
            //outputFile.WriteLine(printer.CutTape());
            printer.CutTape();
            orderListBox.Items.Clear();

            nextOrderNumber++;
            Order = new Order(nextOrderNumber);
            
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            orderList();
        }
    }
}
