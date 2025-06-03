using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Yatzy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        Random rnd = new Random();
        public int DieThrow1;
        public int DieThrow2;
        public int DieThrow3;
        public int DieThrow4;
        public int DieThrow5;


        int OnesInt;
        bool isOnesIntSet = false;
        int TwosInt;
        bool isTwosIntSet = false;
        int ThreesInt;
        bool isThreesIntSet = false;
        int FoursInt;
        bool isFoursIntSet = false;
        int FivesInt;
        bool isFivesIntSet = false;
        int SixesInt;
        bool isSixesIntSet = false;

        int Int3;
        bool isInt3Set = false;

        bool isOnesButtonAllowedToBeEnabled = true;
        bool isTwosButtonAllowedToBeEnabled = true;
        bool isThreesButtonAllowedToBeEnabled = true;
        bool isFoursButtonAllowedToBeEnabled = true;
        bool isFivesButtonAllowedToBeEnabled = true;
        bool isSixesButtonAllowedToBeEnabled = true;

        bool isOnePairButtonAllowedToBeEnabled = true;

        bool doesDieThrow1Equal1 = false;
        bool doesDieThrow2Equal1 = false;
        bool doesDieThrow3Equal1 = false;
        bool doesDieThrow4Equal1 = false;
        bool doesDieThrow5Equal1 = false;

        public int Throw1;
        public int Throw2;
        public int Throw3;
        public int Throw4; 
        public int Throw5;

        // Count pairs
        public int count1;
        public int count2;
        public int count3;
        public int count4;
        public int count5;
        public int count6;

        // Background for empty Die
        ImageBrush Empty = new ImageBrush();

        ImageBrush img1 = new ImageBrush();
        ImageBrush img2 = new ImageBrush();
        ImageBrush img3 = new ImageBrush();
        ImageBrush img4 = new ImageBrush();
        ImageBrush img5 = new ImageBrush();

        ImageBrush DieSlotImage = new ImageBrush();

        

        public GamePage()
        {
            this.InitializeComponent();
            BlurRectangle.Visibility = Visibility.Collapsed;

            OnesTextBlock.Visibility = Visibility.Collapsed;

            TwosTextBlock.Visibility = Visibility.Collapsed;

            ThreesTextBlock.Visibility = Visibility.Collapsed;

            FoursTextBlock.Visibility = Visibility.Collapsed;

            FivesTextBlock.Visibility = Visibility.Collapsed;

            SixesTextBlock.Visibility = Visibility.Collapsed;

            OnePairTextBlock.Visibility = Visibility.Collapsed;

            OnesButton.IsEnabled = false;

            TwosButton.IsEnabled = false;

            ThreesButton.IsEnabled = false;

            FoursButton.IsEnabled = false;

            FivesButton.IsEnabled = false;

            SixesButton.IsEnabled = false;

            OnePairButton.IsEnabled = false;



        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void DieButton_Click(object sender, RoutedEventArgs e)
        {

            // Rolls the dice and updates their background images
            DieThrow1 = rnd.Next(1, 7);
            Die1.Background = Empty;

            DieThrow2 = rnd.Next(1, 7);
            Die2.Background = Empty;

            DieThrow3 = rnd.Next(1, 7);
            Die3.Background = Empty;


            DieThrow4 = rnd.Next(1, 7);
            Die4.Background = Empty;


            DieThrow5 = rnd.Next(1, 7);
            Die5.Background = Empty;

            Throw1 = DieThrow1;
            Throw2 = DieThrow2;
            Throw3 = DieThrow3;
            Throw4 = DieThrow4;
            Throw5 = DieThrow5;


            // Might be unnecessary
            //if (DieThrow1 == 1)
            //{
            //    Throw1 = 1;
            //    doesDieThrow1Equal1 = true;
            //}
            //else
            //{
            //    Throw1 = 0;
            //    doesDieThrow1Equal1 = false;
            //}

            //if (DieThrow2 == 1)
            //{
            //    Throw2 = 1;
            //    doesDieThrow2Equal1 = true;
            //}
            //else
            //{
            //    Throw2 = 0;
            //    doesDieThrow2Equal1 = false;
            //}

            //if (DieThrow3 == 1)
            //{
            //    Throw3 = 1;
            //    doesDieThrow3Equal1 = true;
            //}
            //else
            //{
            //    Throw3 = 0;
            //    doesDieThrow3Equal1 = false;
            //}

            //if (DieThrow4 == 1)
            //{
            //    Throw4 = 1;
            //    doesDieThrow4Equal1 = true;
            //}
            //else
            //{
            //    Throw4 = 0;
            //    doesDieThrow4Equal1 = false;
            //}

            //if (DieThrow5 == 1)
            //{
            //    Throw5 = 1;
            //    doesDieThrow5Equal1 = true;
            //}
            //else
            //{
            //    Throw5 = 0;
            //    doesDieThrow5Equal1 = false;
            //}

            // TODO: Rewrite this code to use fewer lines

            // Reset DieSlot images each dice roll
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));

            if (DieSlot1.Background == img1)
            {
                img1 = img1;
                Die1.Background = Empty;
            }
            else
            {
                img1.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow1}.png"));
                DieSlot1.Background = DieSlotImage;
                Die1.Background = img1;
            }

            if (DieSlot2.Background == img2)
            {
                img2 = img2;
                Die2.Background = Empty;
            }
            else
            {
                img2.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow2}.png"));
                DieSlot2.Background = DieSlotImage;
                Die2.Background = img2;
            }

            if (DieSlot3.Background == img3)
            {
                img3 = img3;
                Die3.Background = Empty;
            }
            else
            {
                img3.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow3}.png"));
                DieSlot3.Background = DieSlotImage;
                Die3.Background = img3;
            }

            if (DieSlot4.Background == img4)
            {
                img4 = img4;
                Die4.Background = Empty;
            }
            else
            {
                img4.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow4}.png"));
                DieSlot4.Background = DieSlotImage;
                Die4.Background = img4;
            }

            if (DieSlot5.Background == img5)
            {
                img5 = img5;
                Die5.Background = Empty;
            }
            else
            {
                img5.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow5}.png"));
                DieSlot5.Background = DieSlotImage;
                Die5.Background = img5;
            }

            // Count pairs
            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;
            count6 = 0;

            // Show rolls
            Trace.WriteLine($"Throws: {Throw1}, {Throw2}, {Throw3}, {Throw4}, {Throw5}");

            // Count occurrences
            int[] throws = { Throw1, Throw2, Throw3, Throw4, Throw5 };
            foreach (int value in throws)
            {
                switch (value)
                {
                    case 1: count1++; break;
                    case 2: count2++; break;
                    case 3: count3++; break;
                    case 4: count4++; break;
                    case 5: count5++; break;
                    case 6: count6++; break;
                }
            }

            int[] counts = { count1, count2, count3, count4, count5, count6 };

            // Match analysis
            int pairCount = 0;
            int threeOfKindCount = 0;
            int fourOfKindCount = 0;
            bool yahtzee = false;
            bool fullHouse = false;

            foreach (int count in counts)
            {
                if (count == 2) pairCount++;
                if (count == 3) threeOfKindCount++;
                if (count == 4) fourOfKindCount++;
                if (count == 5) yahtzee = true;
            }

            fullHouse = (pairCount == 1 && threeOfKindCount == 1);
            bool twoPair = (pairCount >= 2);

            // Detect small and large straights
            bool[] valuesPresent = new bool[7]; // index 0 unused
            foreach (int value in throws)
            {
                valuesPresent[value] = true;
            }

            bool smallStraight =
                (valuesPresent[1] && valuesPresent[2] && valuesPresent[3] && valuesPresent[4]) ||
                (valuesPresent[2] && valuesPresent[3] && valuesPresent[4] && valuesPresent[5]) ||
                (valuesPresent[3] && valuesPresent[4] && valuesPresent[5] && valuesPresent[6]);

            bool largeStraight =
                (valuesPresent[1] && valuesPresent[2] && valuesPresent[3] && valuesPresent[4] && valuesPresent[5]) ||
                (valuesPresent[2] && valuesPresent[3] && valuesPresent[4] && valuesPresent[5] && valuesPresent[6]);

            // Output grouped results
            Trace.WriteLine("\nGrouped Matches:");
            if (count1 > 1) Trace.WriteLine($"{count1} of value 1");
            if (count2 > 1) Trace.WriteLine($"{count2} of value 2");
            if (count3 > 1) Trace.WriteLine($"{count3} of value 3");
            if (count4 > 1) Trace.WriteLine($"{count4} of value 4");
            if (count5 > 1) Trace.WriteLine($"{count5} of value 5");
            if (count6 > 1) Trace.WriteLine($"{count6} of value 6");

            // Output patterns
            Trace.WriteLine("\nPattern Summary:");
            Trace.WriteLine($"Single Pairs: {pairCount}");
            Trace.WriteLine($"Two Pairs Present: {(twoPair ? "Yes" : "No")}");
            Trace.WriteLine($"Three of a Kind: {threeOfKindCount}");
            Trace.WriteLine($"Four of a Kind: {fourOfKindCount}");
            Trace.WriteLine($"Full House: {(fullHouse ? "Yes" : "No")}");
            Trace.WriteLine($"Yahtzee: {(yahtzee ? "Yes" : "No")}");
            Trace.WriteLine($"Small Straight: {(smallStraight ? "Yes" : "No")}");
            Trace.WriteLine($"Large Straight: {(largeStraight ? "Yes" : "No")}");


            // Optionally handle no matches
            //if (count1 <= 1 && count2 <= 1 && count3 <= 1 &&
            //    count4 <= 1 && count5 <= 1 && count6 <= 1)
            //{
            //    Trace.WriteLine("No matching values.");
            //}


            // Ones
            if (isOnesButtonAllowedToBeEnabled == true && (DieThrow1 == 1 || DieThrow2 == 1 || DieThrow3 == 1 || DieThrow4 == 1 || DieThrow5 == 1))
            {
                OnesButton.Content = count1 * 1;
                OnesButton.IsEnabled = true;
            }
            else if (isOnesButtonAllowedToBeEnabled == false)
            {
                OnesButton.IsEnabled = false;
            }
            else
            {
                OnesButton.IsEnabled = false;
            }

            // Twos
            if (isTwosButtonAllowedToBeEnabled == true && (DieThrow1 == 2 || DieThrow2 == 2 || DieThrow3 == 2 || DieThrow4 == 2 || DieThrow5 == 2))
            {
                TwosButton.Content = count2 * 2;
                TwosButton.IsEnabled = true;
            }
            else if (isTwosButtonAllowedToBeEnabled == false)
            {
                TwosButton.IsEnabled = false;
            }
            else
            {
                TwosButton.IsEnabled = false;
            }

            // Threes
            if (isThreesButtonAllowedToBeEnabled == true && (DieThrow1 == 3 || DieThrow2 == 3 || DieThrow3 == 3 || DieThrow4 == 3 || DieThrow5 == 3))
            {
                ThreesButton.Content = count3 * 3;
                ThreesButton.IsEnabled = true;
            }
            else if (isThreesButtonAllowedToBeEnabled == false)
            {
                ThreesButton.IsEnabled = false;
            }
            else
            {
                ThreesButton.IsEnabled = false;
            }

            // Fours
            if (isFoursButtonAllowedToBeEnabled == true && (DieThrow1 == 4 || DieThrow2 == 4 || DieThrow3 == 4 || DieThrow4 == 4 || DieThrow5 == 4))
            {
                FoursButton.Content = count4 * 4;
                FoursButton.IsEnabled = true;
            }
            else if (isFoursButtonAllowedToBeEnabled == false)
            {
                FoursButton.IsEnabled = false;
            }
            else
            {
                FoursButton.IsEnabled = false;
            }

            // Fives
            if (isFivesButtonAllowedToBeEnabled == true && (DieThrow1 == 5 || DieThrow2 == 5 || DieThrow3 == 5 || DieThrow4 == 5 || DieThrow5 == 5))
            {
                FivesButton.Content = count5 * 5;
                FivesButton.IsEnabled = true;
            }
            else if (isFivesButtonAllowedToBeEnabled == false)
            {
                FivesButton.IsEnabled = false;
            }
            else
            {
                FivesButton.IsEnabled = false;
            }

            // Sixes
            if (isSixesButtonAllowedToBeEnabled == true && (DieThrow1 == 6 || DieThrow2 == 6 || DieThrow3 == 6 || DieThrow4 == 6 || DieThrow5 == 6))
            {
                SixesButton.Content = count6 * 6;
                SixesButton.IsEnabled = true;
            }
            else if (isSixesButtonAllowedToBeEnabled == false)
            {
                SixesButton.IsEnabled = false;
            }
            else
            {
                SixesButton.IsEnabled = false;
            }

            // One Pair
            if (isOnePairButtonAllowedToBeEnabled == true && DieThrow1 == 1 && DieThrow2 == 1)
            {
                OnePairButton.Content = Throw1 + Throw2;
                OnePairButton.IsEnabled = true;
            }
            else if(isOnePairButtonAllowedToBeEnabled == false)
            {
                OnePairButton.IsEnabled = false;
            }
            else
            {
                OnePairButton.IsEnabled= false;
            }

            Trace.WriteLine($"count1 = {count1}");
            //Trace.WriteLine($"Int2 = {Int2}");

            //Trace.WriteLine($"DieThrow1 = {DieThrow1}");
            //Trace.WriteLine($"DieThrow2 = {DieThrow2}");

            //Trace.WriteLine($"isOnesButtonAllowedToBeEnabled = {isOnesButtonAllowedToBeEnabled}");
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InformationPopUp.IsOpen = true;
            BlurRectangle.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            InformationPopUp.IsOpen = false;
            BlurRectangle.Visibility = Visibility.Collapsed;
        }

        private void DieSlot1_Click(object sender, RoutedEventArgs e)
        {
            // Empties the DieSlot
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));
            DieSlot1.Background = DieSlotImage;

            // Returns the Die
            img1.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow1}.png"));
            Die1.Background = img1;
        }

        private void DieSlot2_Click(object sender, RoutedEventArgs e)
        {
            // Empties the DieSlot
            ImageBrush DieSlotImage = new ImageBrush();
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));
            DieSlot2.Background = DieSlotImage;

            // Returns the Die
            ImageBrush img1 = new ImageBrush();
            img1.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow2}.png"));
            Die2.Background = img1;
        }

        private void DieSlot3_Click(object sender, RoutedEventArgs e)
        {
            // Empties the DieSlot
            ImageBrush DieSlotImage = new ImageBrush();
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));
            DieSlot3.Background = DieSlotImage;

            // Returns the Die
            ImageBrush img1 = new ImageBrush();
            img1.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow3}.png"));
            Die3.Background = img1;
        }

        private void DieSlot4_Click(object sender, RoutedEventArgs e)
        {
            // Empties the DieSlot
            ImageBrush DieSlotImage = new ImageBrush();
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));
            DieSlot4.Background = DieSlotImage;

            // Returns the Die
            ImageBrush img1 = new ImageBrush();
            img1.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow4}.png"));
            Die4.Background = img1;
        }

        private void DieSlot5_Click(object sender, RoutedEventArgs e)
        {
            // Empties the DieSlot
            ImageBrush DieSlotImage = new ImageBrush();
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));
            DieSlot5.Background = DieSlotImage;

            // Returns the Die
            ImageBrush img1 = new ImageBrush();
            img1.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow5}.png"));
            Die5.Background = img1;
        }

        private void Die1_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot1.Background = img1;

            // Removes the Dies image
            Die1.Background = Empty;
        }

        private void Die2_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot2.Background = img2;

            // Removes the Dies image
            Die2.Background = Empty;
        }

        private void Die3_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot3.Background = img3;

            // Removes the Dies image
            Die3.Background = Empty;
        }

        private void Die4_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot4.Background = img4;

            // Removes the Dies image
            Die4.Background = Empty;
        }

        private void Die5_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot5.Background = img5;

            // Removes the Dies image
            Die5.Background = Empty;
        }

        private void OnesButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnesIntSet && OnesButton.IsEnabled == true)
            {
                OnesInt = count1;
                isOnesIntSet = true;
                isOnesButtonAllowedToBeEnabled = false;
                OnesButton.IsEnabled = false;
                OnesTextBlock.Text = $"{OnesInt * 1}";
                OnesTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void TwosButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isTwosIntSet && TwosButton.IsEnabled == true)
            {
                TwosInt = count2;
                isTwosIntSet = true;
                isTwosButtonAllowedToBeEnabled = false;
                TwosButton.IsEnabled = false;
                TwosTextBlock.Text = $"{TwosInt * 2}";
                TwosTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void ThreesButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isThreesIntSet && ThreesButton.IsEnabled == true)
            {
                ThreesInt = count3;
                isThreesIntSet = true;
                isThreesButtonAllowedToBeEnabled = false;
                ThreesButton.IsEnabled = false;
                ThreesTextBlock.Text = $"{ThreesInt * 3}";
                ThreesTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void FoursButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isFoursIntSet && FoursButton.IsEnabled == true)
            {
                FoursInt = count4;
                isFoursIntSet = true;
                isFoursButtonAllowedToBeEnabled = false;
                FoursButton.IsEnabled = false;
                FoursTextBlock.Text = $"{FoursInt * 4}";
                FoursTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void FivesButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isFivesIntSet && FivesButton.IsEnabled == true)
            {
                FivesInt = count5;
                isFivesIntSet = true;
                isFivesButtonAllowedToBeEnabled = false;
                FivesButton.IsEnabled = false;
                FivesTextBlock.Text = $"{FivesInt * 5}";
                FivesTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void SixesButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isSixesIntSet && SixesButton.IsEnabled == true)
            {
                SixesInt = count6;
                isSixesIntSet = true;
                isSixesButtonAllowedToBeEnabled = false;
                SixesButton.IsEnabled = false;
                SixesTextBlock.Text = $"{SixesInt * 6}";
                SixesTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void OnePairButton_Click(object sender, RoutedEventArgs e)
        {
            if(!isInt3Set && OnePairButton.IsEnabled == true)
            {
                Int3 = Throw1 + Throw2;
                isInt3Set = true;
                isOnePairButtonAllowedToBeEnabled = false;
                OnePairButton.IsEnabled = false;
                OnePairTextBlock.Text = $"{Int3}";
                OnePairTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
