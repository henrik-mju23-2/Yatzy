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

        int Int2;
        bool isInt2Set = false;

        bool isOnesButtonAllowedToBeEnabled = true;

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

            OnesButton.IsEnabled = false;

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


            // Might be unnecessary
            if (DieThrow1 == 1)
            {
                Throw1 = 1;
                doesDieThrow1Equal1 = true;
            }
            else
            {
                Throw1 = 0;
                doesDieThrow1Equal1 = false;
            }

            if (DieThrow2 == 1)
            {
                Throw2 = 1;
                doesDieThrow2Equal1 = true;
            }
            else
            {
                Throw2 = 0;
                doesDieThrow2Equal1 = false;
            }

            if (DieThrow3 == 1)
            {
                Throw3 = 1;
                doesDieThrow3Equal1 = true;
            }
            else
            {
                Throw3 = 0;
                doesDieThrow3Equal1 = false;
            }

            if (DieThrow4 == 1)
            {
                Throw4 = 1;
                doesDieThrow4Equal1 = true;
            }
            else
            {
                Throw4 = 0;
                doesDieThrow4Equal1 = false;
            }

            if (DieThrow5 == 1)
            {
                Throw5 = 1;
                doesDieThrow5Equal1 = true;
            }
            else
            {
                Throw5 = 0;
                doesDieThrow5Equal1 = false;
            }

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

            if (isOnesButtonAllowedToBeEnabled == true && (DieThrow1 == 1 || DieThrow2 == 1 || DieThrow3 == 1 || DieThrow4 == 1 || DieThrow5 == 1))
            {
                OnesButton.Content = Throw1 + Throw2 + Throw3 + Throw4 + Throw5;
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

            Trace.WriteLine($"Int2 = {Int2}");

            Trace.WriteLine($"DieThrow1 = {DieThrow1}");
            Trace.WriteLine($"DieThrow2 = {DieThrow2}");

            Trace.WriteLine($"isOnesButtonAllowedToBeEnabled = {isOnesButtonAllowedToBeEnabled}");
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
            if (!isInt2Set && OnesButton.IsEnabled == true)
            {
                Int2 = Throw1 + Throw2 + Throw3 + Throw4 + Throw5;
                isInt2Set = true;
                isOnesButtonAllowedToBeEnabled = false;
                OnesButton.IsEnabled = false;
                OnesTextBlock.Text = $"{Int2}";
                OnesTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
