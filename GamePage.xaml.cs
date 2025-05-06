using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        public GamePage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void DieButton_Click(object sender, RoutedEventArgs e)
        {
            // Rolls the dice and updates their background images
            DieThrow1 = rnd.Next(1, 7);
            ImageBrush img1 = new ImageBrush();
            img1.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow1}.png"));
            Die1.Background = img1;

            DieThrow2 = rnd.Next(1, 7);
            ImageBrush img2 = new ImageBrush();
            img2.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow2}.png"));
            Die2.Background = img2;

            DieThrow3 = rnd.Next(1, 7);
            ImageBrush img3 = new ImageBrush();
            img3.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow3}.png"));
            Die3.Background = img3;


            DieThrow4 = rnd.Next(1, 7);
            ImageBrush img4 = new ImageBrush();
            img4.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow4}.png"));
            Die4.Background = img4;


            DieThrow5 = rnd.Next(1, 7);
            ImageBrush img5 = new ImageBrush();
            img5.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow5}.png"));
            Die5.Background = img5;

            // TODO: Rewrite this code to use fewer lines

            // Reset DieSlot images each dice roll
            ImageBrush DieSlotImage = new ImageBrush();
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));
            DieSlot1.Background = DieSlotImage;
            DieSlot2.Background = DieSlotImage;
            DieSlot3.Background = DieSlotImage;
            DieSlot4.Background = DieSlotImage;
            DieSlot5.Background = DieSlotImage;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InformationPage));
        }

        private void DieSlot1_Click(object sender, RoutedEventArgs e)
        {
            // Empties the DieSlot
            ImageBrush DieSlotImage = new ImageBrush();
            DieSlotImage.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/DieSlot.png"));
            DieSlot1.Background = DieSlotImage;

            // Returns the Die
            ImageBrush img1 = new ImageBrush();
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
            DieSlot1.Background = Die1.Background;

            // Removes the Dies image
            ImageBrush Empty = new ImageBrush();
            Die1.Background = Empty;
        }

        private void Die2_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot2.Background = Die2.Background;

            // Removes the Dies image
            ImageBrush Empty = new ImageBrush();
            Die2.Background = Empty;
        }

        private void Die3_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot3.Background = Die3.Background;

            // Removes the Dies image
            ImageBrush Empty = new ImageBrush();
            Die3.Background = Empty;
        }

        private void Die4_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot4.Background = Die4.Background;

            // Removes the Dies image
            ImageBrush Empty = new ImageBrush();
            Die4.Background = Empty;
        }

        private void Die5_Click(object sender, RoutedEventArgs e)
        {
            // Adds the Die to the DieSlot
            DieSlot5.Background = Die5.Background;

            // Removes the Dies image
            ImageBrush Empty = new ImageBrush();
            Die5.Background = Empty;
        }
    }
}
