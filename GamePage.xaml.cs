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
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri($@"ms-appx:///Assets/Die{DieThrow1}.png"));
            Die1.Background = img;

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
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InformationPage));
        }
    }
}
