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
using System.Diagnostics;


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

        public const string UriPlayer1Blue = "/Image/Players/Players/Player1-Blue-Small.png";
        public const string UriPlayer2Green = "/Image/Players/Players/Player2-Green-Small.png";
        public string[] UriPlayer1RPSColors = { UriRockBlue, UriPaperBlue, UriScissorsBlue };
        public string[] UriPlayer2RPSColors = { UriRockGreen, UriPaperGreen, UriScissorsGreen };

        public string pOneChoice = "";
        public string pTwoChoice = "";
        Uri Rps1Glow = null;
        Uri Rps2Glow = null;
        DropShadowEffect newDropShadowEffect = new DropShadowEffect();
        Winner winner = new Winner();

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

        //To begin game, press 'Start'. Starts Timer
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timesUp = false;
            lblWinner.Content = "";
            currentSecondsCount = 0;
            ResetImages();
            timer.Start();
            

        }

        //Timer running, display Rock/Paper/Scissors at each second, determine winner
        void timer_Tick(object sender, EventArgs e)
        {
            //Display 'Rock' on the screen
            if (currentSecondsCount == 0)
            {
                Uri imgRock = new Uri("/Image/Words/RPS-Words-Rock.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgRock);
                imgRPSCounter.Visibility = Visibility.Visible;
                currentSecondsCount++;
            }
            //Display 'Paper' on the screen
            else if (currentSecondsCount == 1)
            {
                Uri imgPaper = new Uri("/Image/Words/RPS-Words-Paper.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgPaper);
                currentSecondsCount++;
            }
            //Display 'Scissors' on the screen
            else if (currentSecondsCount == 2)
            {
                Uri imgScissors = new Uri("/Image/Words/RPS-Words-Scissors.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgScissors);
                currentSecondsCount++;
            }
            //Display 'SHOOT!' on the screen. Determine Winner
            else if (currentSecondsCount == 3)
            {
                
                Uri imgShoot = new Uri("/Image/Words/RPS-Words-Shoot.png", UriKind.Relative);
                imgRPSCounter.Source = new BitmapImage(imgShoot);
                timesUp = true;
                currentSecondsCount++;
                winner.DetermineWinner(this, pOneChoice, pTwoChoice);
                timer.Stop();
            }
        }

        //Monitor for Keydown input
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            //Checks if game is started and if Keydown event is a repeat
            if (!timesUp && !e.IsRepeat)
            {
                switch (e.Key)
                {
                    case Key.A:
                        Player1KeysPressed[e.Key.ToString()] = true;
                        pOneChoice = rock;
                        Debug.WriteLine("A keydown: " + pOneChoice);
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(1, e.Key.ToString());
                        break;
                    case Key.S:
                        Player1KeysPressed[e.Key.ToString()] = true;
                        pOneChoice = paper;
                        Debug.WriteLine("S keydown: " + pOneChoice);
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(1, e.Key.ToString());
                        break;
                    case Key.D:
                        Player1KeysPressed[e.Key.ToString()] = true;
                        pOneChoice = scissors;
                        Debug.WriteLine("D keydown: " + pOneChoice);
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(1, e.Key.ToString());
                        break;
                    case Key.J:
                        Player2KeysPressed[e.Key.ToString()] = true;
                        pTwoChoice = rock;
                        Debug.WriteLine("J keydown: " + pTwoChoice);
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(2, e.Key.ToString());
                        break;
                    case Key.K:
                        Player2KeysPressed[e.Key.ToString()] = true;
                        pTwoChoice = paper;
                        Debug.WriteLine("K keydown: " + pTwoChoice);
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(2, e.Key.ToString());
                        break;
                    case Key.L:
                        Player2KeysPressed[e.Key.ToString()] = true;
                        pTwoChoice = scissors;
                        Debug.WriteLine("L keydown: " + pTwoChoice);
                        EnablePlayerGlow(e.Key.ToString());
                        CheckIfImageIsSetForPlayer(2, e.Key.ToString());
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
        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (timesUp != true)
            {
                //If KeyUp=CurrentChoice, set CurrentChoice to null
                //If no others have this choice, reset image to default
                //If others have this choice, change the image back to their color
                switch (e.Key)
                {
                    case Key.A:
                        if (pOneChoice == rock)
                        {
                            pOneChoice = null;
                        }

                        if (OtherPlayersSameOptionPressed(1, "A"))
                        {
                            if (pTwoChoice == rock)
                            {
                                EnablePlayerGlow("J");
                            }
                        }
                        else
                        {
                            DisablePlayerGlow(Key.A.ToString());
                        }

                        Player1KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.S:
                        if (pOneChoice == paper)
                        {
                            pOneChoice = null;
                        }

                        if (OtherPlayersSameOptionPressed(1, "S"))
                        {
                            if (pTwoChoice == paper)
                            {
                                EnablePlayerGlow("K");
                            }
                        }
                        else
                        {
                            DisablePlayerGlow(Key.S.ToString());
                        }
                        Player1KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.D:
                        if (pOneChoice == scissors)
                        {
                            pOneChoice = null;
                        }

                        if (OtherPlayersSameOptionPressed(1, "D"))
                        {
                            if (pTwoChoice == scissors)
                            {
                                EnablePlayerGlow("L");
                            }
                        }
                        else
                        {
                            DisablePlayerGlow(Key.D.ToString());
                        }
                        Player1KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.J:
                        if (pTwoChoice == rock)
                        {
                            pTwoChoice = null;
                        }

                        if (OtherPlayersSameOptionPressed(2, "J"))
                        {
                            if (pOneChoice == rock)
                            {
                                EnablePlayerGlow("A");
                            }
                        }
                        else
                        {
                            DisablePlayerGlow(Key.J.ToString());
                        }
                        Player2KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.K:
                        if (pTwoChoice == paper)
                        {
                            pTwoChoice = null;
                        }

                        if (OtherPlayersSameOptionPressed(2, "K"))
                        {
                            if (pOneChoice == paper)
                            {
                                EnablePlayerGlow("S");
                            }
                        }
                        else
                        {
                            DisablePlayerGlow(Key.K.ToString());
                        }
                        Player2KeysPressed[e.Key.ToString()] = false;
                        break;
                    case Key.L:
                        if (pTwoChoice == scissors)
                        {
                            pTwoChoice = null;
                        }

                        if (OtherPlayersSameOptionPressed(2, "L"))
                        {
                            if (pOneChoice == scissors)
                            {
                                EnablePlayerGlow("D");
                            }
                        }
                        else
                        {
                            DisablePlayerGlow(Key.L.ToString());
                        }
                        Player2KeysPressed[e.Key.ToString()] = false;
                        break;
                }
            }
        }
        private void CheckIfImageIsSetForPlayer(int player, string keyPressed)
        {
            if (player == 1)
            {
                foreach (KeyValuePair<string, bool> playerKeyPressed in Player1KeysPressed)
                {
                    //Reset all but currently pressed button
                    if (playerKeyPressed.Value == true && playerKeyPressed.Key != keyPressed)
                    {
                        //If player holds down multiple buttons, checks if other players have
                        //player's previous (key pressed and held before current one) and sets the glow
                        //back to the other player, as opposed to reseting image to default.
                        Uri imageToReset = null;
                        if (playerKeyPressed.Key == "A")
                        {
                            
                            if (OtherPlayersSameOptionPressed(player, keyPressed) && pTwoChoice == rock)
                            {
                                imageToReset = new Uri(UriRockGreen, UriKind.Relative);
                                imgRock.Source = new BitmapImage(imageToReset);
                            }
                            else
                            {
                                imageToReset = new Uri(UriRock, UriKind.Relative);
                                imgRock.Source = new BitmapImage(imageToReset);
                                
                            }
                            
                        }
                        else if (playerKeyPressed.Key == "S")
                        {
                            if (OtherPlayersSameOptionPressed(player, keyPressed) && pTwoChoice == paper)
                            {
                                imageToReset = new Uri(UriPaperGreen, UriKind.Relative);
                                imgPaper.Source = new BitmapImage(imageToReset);
                            }
                            else
                            {
                                imageToReset = new Uri(UriPaper, UriKind.Relative);
                                imgPaper.Source = new BitmapImage(imageToReset);
                                
                            }
                        }
                        else if (playerKeyPressed.Key == "D")
                        {
                            if (OtherPlayersSameOptionPressed(player, keyPressed) && pTwoChoice == scissors)
                            {
                                imageToReset = new Uri(UriScissorsGreen, UriKind.Relative);
                                imgScissors.Source = new BitmapImage(imageToReset);
                            }
                            else
                            {
                                imageToReset = new Uri(UriScissors, UriKind.Relative);
                                imgScissors.Source = new BitmapImage(imageToReset);
                            }
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
                        //If player holds down multiple buttons, checks if other players have
                        //player's previous (key pressed and held before current one) and sets the glow
                        //back to the other player, as opposed to reseting image to default.
                        Uri imageToReset = null;
                        if (playerKeyPressed.Key == "J")
                        {
                            if (OtherPlayersSameOptionPressed(player, keyPressed) && pOneChoice == rock)
                            {
                                imageToReset = new Uri(UriRockBlue, UriKind.Relative);
                                imgRock.Source = new BitmapImage(imageToReset);
                            }
                            else
                            {
                                imageToReset = new Uri(UriRock, UriKind.Relative);
                                imgRock.Source = new BitmapImage(imageToReset);

                            }
                        }
                        else if (playerKeyPressed.Key == "K")
                        {
                            if (OtherPlayersSameOptionPressed(player, keyPressed) && pOneChoice == paper)
                            {
                                imageToReset = new Uri(UriPaperBlue, UriKind.Relative);
                                imgPaper.Source = new BitmapImage(imageToReset);
                            }
                            else
                            {
                                imageToReset = new Uri(UriPaper, UriKind.Relative);
                                imgPaper.Source = new BitmapImage(imageToReset);

                            }
                        }
                        else if (playerKeyPressed.Key == "L")
                        {
                            if (OtherPlayersSameOptionPressed(player, keyPressed) && pOneChoice == scissors)
                            {
                                imageToReset = new Uri(UriScissorsBlue, UriKind.Relative);
                                imgScissors.Source = new BitmapImage(imageToReset);
                            }
                            else
                            {
                                imageToReset = new Uri(UriScissors, UriKind.Relative);
                                imgScissors.Source = new BitmapImage(imageToReset);

                            }
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
            image = new Uri(UriPlayer1Blue, UriKind.Relative);
            imgPlayer1.Source = new BitmapImage(image);
            image = new Uri(UriPlayer2Green, UriKind.Relative);
            imgPlayer2.Source = new BitmapImage(image);
            //Reset Player Choices
            pOneChoice = null;
            pTwoChoice = null;

            if (Winner.gameOver == true)
            {
                player1Progress.Value = 0;
                player2Progress.Value = 0;
                Winner.gameOver = false;
            }
        }


        private void EnablePlayerGlow(string keyPressed)
        {
            //If Player presses a key, glow their symbol
            //Glow player color on whichever respective RPS item they pressed
            if (keyPressed == "A" || keyPressed == "S" || keyPressed == "D")
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
            //Disables glow of Player# symbol at bottom of window
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

        private bool OtherPlayersSameOptionPressed(int activePlayer, string activeLetter)
        {
            //Checks if opposing players have they same Key and primary choice selected also
            if (activePlayer == 1)
            {
                if (activeLetter == "A")
                {
                    if (Player2KeysPressed["J"] == true)
                    {
                        //Checks if player2 has J pressed down currently AND has J/Rock selected as choice
                        if (pTwoChoice == rock)
                        {
                            return true;
                        }
                        
                    }
                }
                else if (activeLetter == "S")
                {
                    if (Player2KeysPressed["K"] == true)
                    {
                        if (pTwoChoice == paper)
                        {
                            return true;
                        }
                    }
                }
                else if (activeLetter == "D")
                {
                    if (Player2KeysPressed["L"] == true)
                    {
                        if (pTwoChoice == scissors)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (activePlayer == 2)
            {
                if (activeLetter == "J")
                {
                    if (Player1KeysPressed["A"] == true)
                    {
                        if (pOneChoice == rock)
                        {
                            return true;
                        }
                    }
                }
                else if (activeLetter == "K")
                {
                    if (Player1KeysPressed["S"] == true)
                    {
                        if (pOneChoice == paper)
                        {
                            return true;
                        }
                    }
                }
                else if (activeLetter == "L")
                {
                    if (Player1KeysPressed["D"] == true)
                    {
                        if (pOneChoice == scissors)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
    }
}
