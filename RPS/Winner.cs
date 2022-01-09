using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Windows.Media.Imaging;

namespace RPS
{
    class Winner
    {
        string imageSource = "";
        public void DetermineWinner(MainWindow mainWind, string p1, string p2)
        {
            if (p1 == MainWindow.rock)
            {
                switch (p2)
                {
                    case MainWindow.rock:
                        UpdateWinner(mainWind, 0, p1, p2);
                        break;
                    case MainWindow.paper:
                        UpdateWinner(mainWind, 2, p1, p2);
                        break;
                    case MainWindow.scissors:
                        UpdateWinner(mainWind, 1, p1, p2);
                        break;
                }
            }
            else if (p1 ==  MainWindow.paper)
            {
                switch (p2)
                {
                    case MainWindow.rock:
                        UpdateWinner(mainWind, 1, p1, p2);
                        break;
                    case MainWindow.paper:
                        UpdateWinner(mainWind, 0, p1, p2);
                        break;
                    case MainWindow.scissors:
                        UpdateWinner(mainWind, 2, p1, p2);
                        break;
                }
            }
            else if (p1 == MainWindow.scissors)
            {
                switch (p2)
                {
                    case MainWindow.rock:
                        UpdateWinner(mainWind, 2, p1, p2);
                        break;
                    case MainWindow.paper:
                        UpdateWinner(mainWind, 1, p1, p2);
                        break;
                    case MainWindow.scissors:
                        UpdateWinner(mainWind, 0, p1, p2);
                        break;
                }
            }
        }

        private void UpdateWinner(MainWindow mainWind, int winningPlayer, string p1, string p2)
        {
            Uri playerChoices = null;
            if (winningPlayer == 0)
            {
                mainWind.lblWinner.Content = "Tie!";
            }
            else if (winningPlayer == 1)
            {
                mainWind.lblWinner.Content = $"<--- Player {winningPlayer} wins!";
            }
            else if (winningPlayer == 2)
            {
                mainWind.lblWinner.Content = $"Player {winningPlayer} wins! --->";
            }

            //If tie
            if (p1 == p2)
            {
                imageSource = "/Image/RPS/Mixed/" + p1 + "-Mixed-BG.png";
                playerChoices = new Uri(imageSource, UriKind.Relative);
                if (p1 == MainWindow.rock)
                {
                    mainWind.imgRock.Source = new BitmapImage(playerChoices);
                }
                else if (p1 == MainWindow.paper)
                {
                    mainWind.imgPaper.Source = new BitmapImage(playerChoices);
                }
                else if (p1 == MainWindow.scissors)
                {
                    mainWind.imgScissors.Source = new BitmapImage(playerChoices);
                }
            }
            //If not tie
            else
            {
                switch (p1)
                {
                    case MainWindow.rock:
                        imageSource = "/Image/RPS/" + p1 + "-Blue.png";
                        playerChoices = new Uri(imageSource, UriKind.Relative);
                        mainWind.imgRock.Source = new BitmapImage(playerChoices);
                        break;
                    case MainWindow.paper:
                        imageSource = "/Image/RPS/" + p1 + "-Blue.png";
                        playerChoices = new Uri(imageSource, UriKind.Relative);
                        mainWind.imgPaper.Source = new BitmapImage(playerChoices);
                        break;
                    case MainWindow.scissors:
                        imageSource = "/Image/RPS/" + p1 + "-Blue.png";
                        playerChoices = new Uri(imageSource, UriKind.Relative);
                        mainWind.imgScissors.Source = new BitmapImage(playerChoices);
                        break;

                }
                switch (p2)
                {
                    case MainWindow.rock:
                        imageSource = "/Image/RPS/" + p2 + "-Green.png";
                        playerChoices = new Uri(imageSource, UriKind.Relative);
                        mainWind.imgRock.Source = new BitmapImage(playerChoices);
                        break;
                    case MainWindow.paper:
                        imageSource = "/Image/RPS/" + p2 + "-Green.png";
                        playerChoices = new Uri(imageSource, UriKind.Relative);
                        mainWind.imgPaper.Source = new BitmapImage(playerChoices);
                        break;
                    case MainWindow.scissors:
                        imageSource = "/Image/RPS/" + p2 + "-Green.png";
                        playerChoices = new Uri(imageSource, UriKind.Relative);
                        mainWind.imgScissors.Source = new BitmapImage(playerChoices);
                        break;
                }
            }
        }
    }
}
