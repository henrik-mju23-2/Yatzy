﻿using System;
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
using Yatzy.YatzyGame;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Yatzy
{
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

        int OnePairInt;
        bool isOnePairIntSet = false;
        int TwoPairsInt;
        bool isTwoPairsIntSet = false;
        int ThreePairsInt;
        bool isThreePairsIntSet = false;
        int FourPairsInt;
        bool isFourPairsIntSet = false;

        int FullHouseInt;
        bool isFullHouseIntSet;

        bool isOnesButtonAllowedToBeEnabled = true;
        bool isTwosButtonAllowedToBeEnabled = true;
        bool isThreesButtonAllowedToBeEnabled = true;
        bool isFoursButtonAllowedToBeEnabled = true;
        bool isFivesButtonAllowedToBeEnabled = true;
        bool isSixesButtonAllowedToBeEnabled = true;

        bool isOnePairButtonAllowedToBeEnabled = true;
        bool isTwoPairsButtonAllowedToBeEnabled = true;
        bool isThreePairsButtonAllowedToBeEnabled = true;
        bool isFourPairsButtonAllowedToBeEnabled = true;

        bool isFullHouseButtonAllowedToBeEnabled = true;

        bool isSmallStraightButtonAllowedToBeEnabled = true;
        bool isLargeStraightButtonAllowedToBeEnabled = true;

        bool isChanceButtonAllowedToBeEnabled = true;

        bool isYatzyButtonAllowedToBeEnabled = true;

        //public int Throw1;
        //public int Throw2;
        //public int Throw3;
        //public int Throw4; 
        //public int Throw5;

        // Count pairs
        public int count1;
        public int count2;
        public int count3;
        public int count4;
        public int count5;
        public int count6;

        // Sum of pairs, full house and Yatzy
        public int sumOfPair;
        public int sumOfTwoPairs;
        public int sumOfThree;
        public int sumOfFour;
        public int fullHouseScore;
        public int yatzyScore;

        // Small and large ltraights
        bool smallStraight;
        int smallStraightScoreInt = 15;
        bool largeStraight;
        int largeStraightScoreInt = 20;

        int smallStraightInt;
        bool isSmallStraightIntSet;
        int largeStraightInt;
        bool isLargeStraightIntSet;

        // Chance
        int Chance;
        int chanceInt;
        bool isChanceIntSet;

        // Yatzy
        int yatzyInt;
        bool isYatzyIntSet;

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

            TwoPairsTextBlock.Visibility = Visibility.Collapsed;

            ThreePairsTextBlock.Visibility = Visibility.Collapsed;

            FourPairsTextBlock.Visibility = Visibility.Collapsed;

            FullHouseTextBlock.Visibility = Visibility.Collapsed;

            SmallStraightTextBlock.Visibility = Visibility.Collapsed;

            LargeStraightTextBlock.Visibility= Visibility.Collapsed;

            ChanceTextBlock.Visibility = Visibility.Collapsed;

            YatzyTextBlock.Visibility = Visibility.Collapsed;

            OnesButton.IsEnabled = false;

            TwosButton.IsEnabled = false;

            ThreesButton.IsEnabled = false;

            FoursButton.IsEnabled = false;

            FivesButton.IsEnabled = false;

            SixesButton.IsEnabled = false;

            OnePairButton.IsEnabled = false;

            TwoPairsButton.IsEnabled = false;

            ThreePairsButton.IsEnabled = false;

            FourPairsButton.IsEnabled = false;

            FullHouseButton.IsEnabled = false;

            SmallLadderButton.IsEnabled = false;

            LargeLadderButton.IsEnabled = false;

            ChanceButton.IsEnabled = false;

            YatzyButton.IsEnabled = false;

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void DieButton_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate Tarning
            Tarning tarning = new Tarning();

            // Rolls the dice and updates their background images
            DieThrow1 = tarning.Roll();
            Die1.Background = Empty;

            DieThrow2 = tarning.Roll();
            Die2.Background = Empty;

            DieThrow3 = tarning.Roll();
            Die3.Background = Empty;

            DieThrow4 = tarning.Roll();
            Die4.Background = Empty;

            DieThrow5 = tarning.Roll();
            Die5.Background = Empty;

            //Throw1 = DieThrow1;
            //Throw2 = DieThrow2;
            //Throw3 = DieThrow3;
            //Throw4 = DieThrow4;
            //Throw5 = DieThrow5;

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

            // Reset pair counter values
            count1 = 0;
            count2 = 0;
            count3 = 0;
            count4 = 0;
            count5 = 0;
            count6 = 0;

            // Reset sum of pairs, full house, yatzy and chance values
            sumOfPair = 0;
            sumOfTwoPairs = 0;
            sumOfThree = 0;
            sumOfFour = 0;
            fullHouseScore = 0;
            yatzyScore = 0;
            Chance = 0;

            // Reset value of yatzy
            bool yatzy = false;

            // Reset value of fullHouse
            bool fullHouse = false;

            // Instantiate Regler using the die throws
            Regler regler = new Regler(
                DieThrow1,
                DieThrow2,
                DieThrow3,
                DieThrow4,
                DieThrow5
            );

            // Add values to integers count1-6
            count1 = regler.Ones;
            count2 = regler.Twos;
            count3 = regler.Threes;
            count4 = regler.Fours;
            count5 = regler.Fives;
            count6 = regler.Sixes;

            // Add values to pairs, small straights, large straights, full house, yatzy and chance
            sumOfPair = regler.SumOfPair;
            sumOfTwoPairs = regler.SumOfTwoPairs;      
            sumOfThree = regler.SumOfThree;
            sumOfFour = regler.SumOfFour;

            smallStraight = regler.IsSmallStraight;
            largeStraight = regler.IsLargeStraight;

            fullHouse = regler.IsFullHouse;
            
            yatzy = regler.IsYatzy;

            Chance = regler.ChanceScore;

            // Check full house value
            if(regler.IsFullHouse == true)
            {
                fullHouseScore = regler.FullHouseScore;
            }

            // Check small and large straight values
            if(regler.IsSmallStraight == true)
            {
                smallStraight = true;
            }

            if (regler.IsLargeStraight == true)
            {
                largeStraight = true;
            }

            // Check yatzy value
            if(regler.IsYatzy == true)
            {
                yatzyScore = regler.YatzyScore;
            }

            // Check chance value
            Chance = regler.ChanceScore;
           
            // Ones
            if (isOnesButtonAllowedToBeEnabled == true && (DieThrow1 == 1 || DieThrow2 == 1 || DieThrow3 == 1 || DieThrow4 == 1 || DieThrow5 == 1))
            {
                OnesButton.Content = count1;
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
                TwosButton.Content = count2;
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
                ThreesButton.Content = count3;
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
                FoursButton.Content = count4;
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
                FivesButton.Content = count5;
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
                SixesButton.Content = count6;
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
            if (isOnePairButtonAllowedToBeEnabled == true && sumOfPair > 0)
            {
                OnePairButton.Content = sumOfPair;
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

            // Two Pairs
            if (isTwoPairsButtonAllowedToBeEnabled == true && sumOfTwoPairs > 0)
            {
                TwoPairsButton.Content = sumOfTwoPairs;
                TwoPairsButton.IsEnabled = true;
            }
            else if (isTwoPairsButtonAllowedToBeEnabled == false)
            {
                TwoPairsButton.IsEnabled = false;
            }
            else
            {
                TwoPairsButton.IsEnabled = false;
            }

            // Three pairs
            if (isThreePairsButtonAllowedToBeEnabled == true && sumOfThree > 0)
            {
                ThreePairsButton.Content = sumOfThree;
                ThreePairsButton.IsEnabled = true;
            }
            else if (isThreePairsButtonAllowedToBeEnabled == false)
            {
                ThreePairsButton.IsEnabled = false;
            }
            else
            {
                ThreePairsButton.IsEnabled = false;
            }

            // Four pairs
            if (isFourPairsButtonAllowedToBeEnabled == true && sumOfFour > 0)
            {
                FourPairsButton.Content = sumOfFour;
                FourPairsButton.IsEnabled = true;
            }
            else if (isFourPairsButtonAllowedToBeEnabled == false)
            {
                FourPairsButton.IsEnabled = false;
            }
            else
            {
                FourPairsButton.IsEnabled = false;
            }

            // Full House
            if (isFullHouseButtonAllowedToBeEnabled == true && fullHouseScore > 0)
            {
                FullHouseButton.Content = fullHouseScore;
                FullHouseButton.IsEnabled = true;
            }
            else if (isFullHouseButtonAllowedToBeEnabled == false)
            {
                FullHouseButton.IsEnabled = false;
            }
            else
            {
                FullHouseButton.IsEnabled = false;
            }

            // Small straight
            if (isSmallStraightButtonAllowedToBeEnabled == true && smallStraight == true)
            {
                SmallLadderButton.Content = smallStraightScoreInt;
                SmallLadderButton.IsEnabled = true;
            }
            else if (isSmallStraightButtonAllowedToBeEnabled == false)
            {
                SmallLadderButton.IsEnabled = false;
            }
            else
            {
                SmallLadderButton.IsEnabled = false;
            }

            // Large straight
            if (isLargeStraightButtonAllowedToBeEnabled == true && largeStraight == true)
            {
                LargeLadderButton.Content = largeStraightScoreInt;
                LargeLadderButton.IsEnabled = true;
            }
            else if (isLargeStraightButtonAllowedToBeEnabled == false)
            {
                LargeLadderButton.IsEnabled = false;
            }
            else
            {
                LargeLadderButton.IsEnabled = false;
            }

            // Chance
            if (isChanceButtonAllowedToBeEnabled == true && Chance > 0)
            {
                ChanceButton.Content = Chance;
                ChanceButton.IsEnabled = true;
            }
            else if (isChanceButtonAllowedToBeEnabled == false)
            {
                ChanceButton.IsEnabled = false;
            }
            else
            {
                ChanceButton.IsEnabled = false;
            }

            // Yatzy
            if (isYatzyButtonAllowedToBeEnabled == true && yatzyScore == 50)
            {
                YatzyButton.Content = yatzyScore;
                YatzyButton.IsEnabled = true;
            }
            else if (isYatzyButtonAllowedToBeEnabled == false)
            {
                YatzyButton.IsEnabled = false;
            }
            else
            {
                YatzyButton.IsEnabled = false;
            }

        }

        // Info button

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

        // Die and die-slot buttons

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

        // Scoreboard buttons

        private void OnesButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnesIntSet && OnesButton.IsEnabled == true)
            {
                OnesInt = count1;
                isOnesIntSet = true;
                isOnesButtonAllowedToBeEnabled = false;
                OnesButton.IsEnabled = false;
                OnesTextBlock.Text = $"{OnesInt}";
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
                TwosTextBlock.Text = $"{TwosInt}";
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
                ThreesTextBlock.Text = $"{ThreesInt}";
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
                FoursTextBlock.Text = $"{FoursInt}";
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
                FivesTextBlock.Text = $"{FivesInt}";
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
                SixesTextBlock.Text = $"{SixesInt}";
                SixesTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void OnePairButton_Click(object sender, RoutedEventArgs e)
        {
            if(!isOnePairIntSet && OnePairButton.IsEnabled == true)
            {
                OnePairInt = sumOfPair;
                isOnePairIntSet = true;
                isOnePairButtonAllowedToBeEnabled = false;
                OnePairButton.IsEnabled = false;
                OnePairTextBlock.Text = $"{OnePairInt}";
                OnePairTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void TwoPairsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTwoPairsIntSet && TwoPairsButton.IsEnabled == true)
            {
                TwoPairsInt = sumOfTwoPairs;
                isTwoPairsIntSet = true;
                isTwoPairsButtonAllowedToBeEnabled = false;
                TwoPairsButton.IsEnabled = false;
                TwoPairsTextBlock.Text = $"{TwoPairsInt}";
                TwoPairsTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void ThreePairsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isThreePairsIntSet && ThreePairsButton.IsEnabled == true)
            {
                ThreePairsInt = sumOfThree;
                isThreePairsIntSet = true;
                isThreePairsButtonAllowedToBeEnabled = false;
                ThreePairsButton.IsEnabled = false;
                ThreePairsTextBlock.Text = $"{ThreePairsInt}";
                ThreePairsTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void FourPairsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isFourPairsIntSet && FourPairsButton.IsEnabled == true)
            {
                FourPairsInt = sumOfFour;
                isFourPairsIntSet = true;
                isFourPairsButtonAllowedToBeEnabled = false;
                FourPairsButton.IsEnabled = false;
                FourPairsTextBlock.Text = $"{FourPairsInt}";
                FourPairsTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void FullHouseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isFullHouseIntSet && FullHouseButton.IsEnabled == true)
            {
                FullHouseInt = fullHouseScore;
                isFullHouseIntSet = true;
                isFullHouseButtonAllowedToBeEnabled = false;
                FullHouseButton.IsEnabled = false;
                FullHouseTextBlock.Text = $"{FullHouseInt}";
                FullHouseTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void SmallLadderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isSmallStraightIntSet && SmallLadderButton.IsEnabled == true)
            {
                smallStraightInt = smallStraightScoreInt;
                isSmallStraightIntSet = true;
                isSmallStraightButtonAllowedToBeEnabled = false;
                SmallLadderButton.IsEnabled = false;
                SmallStraightTextBlock.Text = $"{smallStraightInt}";
                SmallStraightTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void LargeLadderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isLargeStraightIntSet && LargeLadderButton.IsEnabled == true)
            {
                largeStraightInt = largeStraightScoreInt;
                isLargeStraightIntSet = true;
                isLargeStraightButtonAllowedToBeEnabled = false;
                LargeLadderButton.IsEnabled = false;
                LargeStraightTextBlock.Text = $"{largeStraightInt}";
                LargeStraightTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void YatzyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isYatzyIntSet && YatzyButton.IsEnabled == true)
            {
                yatzyInt = yatzyScore;
                isYatzyIntSet = true;
                isYatzyButtonAllowedToBeEnabled = false;
                YatzyButton.IsEnabled = false;
                YatzyTextBlock.Text = $"{yatzyInt}";
                YatzyTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void ChanceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isChanceIntSet && ChanceButton.IsEnabled == true)
            {
                chanceInt = Chance;
                isChanceIntSet = true;
                isChanceButtonAllowedToBeEnabled = false;
                ChanceButton.IsEnabled = false;
                ChanceTextBlock.Text = $"{chanceInt}";
                ChanceTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
