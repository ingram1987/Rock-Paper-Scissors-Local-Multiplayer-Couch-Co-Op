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
using System.Windows.Threading;
using System.Media;
using System.Windows.Media.Effects;


namespace RPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        private int currentSecondsCount = 0;
        private bool timesUp = true;
        public IDictionary<string, bool> Player1KeysPressed = new Dictionary<string, bool>(){
            {"A", false},
            {"S", false},
            {"D", false}
        };
        public IDictionary<string, bool> Player2KeysPressed = new Dictionary<string, bool>(){
            {"J", false },
            {"K", false },
            {"L", false }
        };
        public const string rock = "Rock";
        public const string paper = "Paper";
        public const string scissors = "Scissors";
        public const string UriRock = "/Image/RPS/Rock.png";
        public const string UriPaper = "/Image/RPS/Paper.png";
        public const string UriScissors = "/Image/RPS/Scissors.png";
        public const string UriRockBlue = "/Image/RPS/Rock-Blue.png";
        public const string UriRockGreen = "/Image/RPS/Rock-Green.png";
        public const string UriPaperBlue = "/Image/RPS/Paper-Blue.png";
        public const string UriPaperGreen = "/Image/RPS/Paper-Green.png";
        public const string UriScissorsBlue = "/Image/RPS/Scissors-Blue.png";
        public const string UriScissorsGreen = "/Image/RPS/Scissors-Green.png";
        public const string UriRockMixedBG = "/Image/RPS/Mixed/Rock-Mixed-BG.png";
        public const string UriPaperMixedBG = "/Image/RPS/Mixed/Paper-Mixed-BG.png";
        public const string UriScissorsMixedBG = "/Image/RPS/Mixed/Scissors-Mixed-BG.png";

        public string[] UriPlayer1RPSColors = { UriRockBlue, UriPaperBlue, UriScissorsBlue };
        public string[] UriPlayer2RPSColors = { UriRockGreen, UriPaperGreen, UriScissorsGreen };

        public string pOneChoice = "";
        public string pTwoChoice = "";
        Uri Rps1Glow = null;
        Uri Rps2Glow = null;
        DropShadowEffect newDropShadowEffect = new DropShadowEffect();
        


        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            newDropShadowEffect.BlurRadius = 7;
            newDropShadowEffect.Direction = 180;
            newDropShadowEffect.Opacity = 95;
            newDropShadowEffect.ShadowDepth = 8;
        }

        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (timesUp != true)
            {
                switch (e.Key)
                {
                    case Key.A:
                        Player1KeysPressed[e.Key.ToString()] = true;
                        pOneChoice = rock;
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(1, e.Key.ToString());
                        SystemSounds.Asterisk.Play();
                        break;
                    case Key.S:
                        Player1KeysPressed[e.Key.ToString()] = true;
                        pOneChoice = paper;
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(1, e.Key.ToString());
                        SystemSounds.Asterisk.Play();
                        break;
                    case Key.D:
                        Player1KeysPressed[e.Key.ToString()] = true;
                        pOneChoice = scissors;
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(1, e.Key.ToString());
                        SystemSounds.Asterisk.Play();
                        break;
                    case Key.J:
                        Player2KeysPressed[e.Key.ToString()] = true;
                        pTwoChoice = rock;
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(2, e.Key.ToString());
                        SystemSounds.Hand.Play();
                        break;
                    case Key.K:
                        Player2KeysPressed[e.Key.ToString()] = true;
                        pTwoChoice = paper;
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(2, e.Key.ToString());
                        SystemSounds.Hand.Play();
                        break;
                    case Key.L:
                        Player2KeysPressed[e.Key.ToString()] = true;
                        pTwoChoice = scissors;
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(2, e.Key.ToString());
                        SystemSounds.Hand.Play();
                        break;
                }
            }
            else
            {
                if (e.Key.ToString() == "Space")
                {
                    Button_Click(sender, e);
                }
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timesUp = false;
            lblWinner.Content = "";
            currentSecondsCount = 0;
            ResetImages();
            timer.Start();

        }

        private void CheckIfImageIsSetForPlayer(int player, string keyPressed)
        {
            if (player == 1)
            {
                //RockImageUri = ((BitmapImage)imgRock.Source).UriSource.ToString();
                //PaperImageUri = ((BitmapImage)imgPaper.Source).UriSource.ToString();
                //ScissorsImageUri = ((BitmapImage)imgScissors.Source).UriSource.ToString();

                //Iterate through currently pressed buttons by Player 1
                foreach (KeyValuePair<string, bool> playerKeyPressed in Player1KeysPressed)
                {
                    //Reset all but currently pressed button
                    if (playerKeyPressed.Value == true && playerKeyPressed.Key != keyPressed)
                    {
                        Uri imageToReset = null;
                        if (playerKeyPressed.Key == "A")
                        {
                            imageToReset = new Uri(UriRock, UriKind.Relative);
                            imgRock.Source = new BitmapImage(imageToReset);
                        }
                        else if (playerKeyPressed.Key == "S")
                        {
                            imageToReset = new Uri(UriPaper, UriKind.Relative);
                            imgPaper.Source = new BitmapImage(imageToReset);
                        }
                        else if (playerKeyPressed.Key == "D")
                        {
                            imageToReset = new Uri(UriScissors, UriKind.Relative);
                            imgScissors.Source = new BitmapImage(imageToReset);
                        }
                    }
                }
            }
            else if (player == 2)
            {
                //Iterate through currently pressed buttons by Player 2
                foreach (KeyValuePair<string, bool> playerKeyPressed in Player2KeysPressed)
                {
                    //Reset all but currently pressed button
                    if (playerKeyPressed.Value == true && playerKeyPressed.Key != keyPressed)
                    {
                        Uri imageToReset = null;
                        if (playerKeyPressed.Key == "J")
                        {
                            imageToReset = new Uri(UriRock, UriKind.Relative);
                            imgRock.Source = new BitmapImage(imageToReset);
                        }
                        else if (playerKeyPressed.Key == "K")
                        {
                            imageToReset = new Uri(UriPaper, UriKind.Relative);
                            imgPaper.Source = new BitmapImage(imageToReset);
                        }
                        else if (playerKeyPressed.Key == "L")
                        {
                            imageToReset = new Uri(UriScissors, UriKind.Relative);
                            imgScissors.Source = new BitmapImage(imageToReset);
                        }
                    }
                }
            }
        }
        private void ResetImages()
        {
            //Reset all images to default
            imgRPSCounter.Visibility = Visibility.Hidden;
            Uri image = null;
            image = new Uri(UriRock, UriKind.Relative);
            imgRock.Source = new BitmapImage(image);
            image = new Uri(UriPaper, UriKind.Relative);
            imgPaper.Source = new BitmapImage(image);
            image = new Uri(UriScissors, UriKind.Relative);
            imgScissors.Source = new BitmapImage(image);
            

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (currentSecondsCount == 0)
            {
                Uri imgRock = new Uri("/Image/Words/RPS-Words-Rock.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgRock);
                imgRPSCounter.Visibility = Visibility.Visible;
                currentSecondsCount++;
            }
            else if(currentSecondsCount == 1)
            {
                Uri imgPaper = new Uri("/Image/Words/RPS-Words-Paper.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgPaper);
                currentSecondsCount++;
            }
            else if(currentSecondsCount == 2)
            {
                Uri imgScissors = new Uri("/Image/Words/RPS-Words-Scissors.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgScissors);
                currentSecondsCount++;
            }
            else if(currentSecondsCount == 3)
            {
                Uri imgShoot = new Uri("/Image/Words/RPS-Words-Shoot.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgShoot);
                timesUp = true;
                currentSecondsCount++;
                Winner winner = new Winner();
                winner.DetermineWinner(this, pOneChoice, pTwoChoice);
                timer.Stop();
            }
        }

        private void EnablePlayerGlow(string keyPressed)
        {

            if(keyPressed == "A" || keyPressed == "S" || keyPressed == "D")
            {
                Uri player1Glow = new Uri("/Image/Players/Players-Glow/Player1-Blue-Small-Glow.png", UriKind.Relative);
                imgPlayer1.Source = new BitmapImage(player1Glow);
                if (keyPressed == "A")
                {
                    Rps1Glow = new Uri("/Image/RPS/Rock-Blue.png", UriKind.Relative);
                    imgRock.Source = new BitmapImage(Rps1Glow);
                    
                }
                else if (keyPressed == "S")
                {
                    Rps1Glow = new Uri("/Image/RPS/Paper-Blue.png", UriKind.Relative);
                    imgPaper.Source = new BitmapImage(Rps1Glow);
                }
                else if (keyPressed == "D")
                {
                    Rps1Glow = new Uri("/Image/RPS/Scissors-Blue.png", UriKind.Relative);
                    imgScissors.Source = new BitmapImage(Rps1Glow);
                }
            }
            else if (keyPressed == "J" || keyPressed == "K" || keyPressed == "L")
            {
                Uri player2Glow = new Uri("/Image/Players/Players-Glow/Player2-Green-Small-Glow.png", UriKind.Relative);
                imgPlayer2.Source = new BitmapImage(player2Glow);
                if (keyPressed == "J")
                {
                    Rps2Glow = new Uri("/Image/RPS/Rock-Green.png", UriKind.Relative);
                    imgRock.Source = new BitmapImage(Rps2Glow);
                }
                else if (keyPressed == "K")
                {
                    Rps2Glow = new Uri("/Image/RPS/Paper-Green.png", UriKind.Relative);
                    imgPaper.Source = new BitmapImage(Rps2Glow);
                }
                else if (keyPressed == "L")
                {
                    Rps2Glow = new Uri("/Image/RPS/Scissors-Green.png", UriKind.Relative);
                    imgScissors.Source = new BitmapImage(Rps2Glow);
                }

            }
        }
        private void DisablePlayerGlow(string keyPressed)
        {
            if (keyPressed == "A" || keyPressed == "S" || keyPressed == "D")
            {
                Uri player1NoGlow = new Uri("/Image/Players/Players/Player1-Blue-Small.png", UriKind.Relative);
                imgPlayer1.Source = new BitmapImage(player1NoGlow);
                if (keyPressed == "A")
                {
                    Rps1Glow = new Uri("/Image/RPS/Rock.png", UriKind.Relative);
                    imgRock.Source = new BitmapImage(Rps1Glow);
                }
                else if (keyPressed == "S")
                {
                    Rps1Glow = new Uri("/Image/RPS/Paper.png", UriKind.Relative);
                    imgPaper.Source = new BitmapImage(Rps1Glow);
                }
                else if (keyPressed == "D")
                {
                    Rps1Glow = new Uri("/Image/RPS/Scissors.png", UriKind.Relative);
                    imgScissors.Source = new BitmapImage(Rps1Glow);
                }
            }
            else if (keyPressed == "J" || keyPressed == "K" || keyPressed == "L")
            {
                Uri player2NoGlow = new Uri("/Image/Players/Players/Player1-Green-Small.png", UriKind.Relative);
                imgPlayer2.Source = new BitmapImage(player2NoGlow);
                if (keyPressed == "J")
                {
                    Rps2Glow = new Uri("/Image/RPS/Rock.png", UriKind.Relative);
                    imgRock.Source = new BitmapImage(Rps2Glow);
                }
                else if (keyPressed == "K")
                {
                    Rps2Glow = new Uri("/Image/RPS/Paper.png", UriKind.Relative);
                    imgPaper.Source = new BitmapImage(Rps2Glow);
                }
                else if (keyPressed == "L")
                {
                    Rps2Glow = new Uri("/Image/RPS/Scissors.png", UriKind.Relative);
                    imgScissors.Source = new BitmapImage(Rps2Glow);
                }
            }
        }

        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (timesUp != true)
            {
                switch (e.Key)
                {
                    case Key.A:
                        DisablePlayerGlow(Key.A.ToString());
                        Player1KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.S:
                        DisablePlayerGlow(Key.S.ToString());
                        Player1KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.D:
                        DisablePlayerGlow(Key.D.ToString());
                        Player1KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.J:
                        DisablePlayerGlow(Key.J.ToString());
                        Player2KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.K:
                        DisablePlayerGlow(Key.K.ToString());
                        Player2KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.L:
                        DisablePlayerGlow(Key.L.ToString());
                        Player2KeysPressed[e.Key.ToString()] = false;
                        break;
                }
            }
        }
    }
}
