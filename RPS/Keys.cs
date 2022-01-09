using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    class Keys
    {
        private bool MultipleKeysPressed(MainWindow mainWind, int player)
        {
            if (player == 1)
            {
                int count = 0;
                foreach (KeyValuePair<string, bool> letterPressed in mainWind.Player1KeysPressed)
                {
                    if (letterPressed.Value == true)
                    {
                        count++;
                        if (count >= 2)
                        {
                            return true;
                        }
                    }
                }
                if (count <= 1)
                {
                    return false;
                }
            }
            else if (player == 2)
            {
                int count = 0;
                foreach (KeyValuePair<string, bool> letterPressed in mainWind.Player2KeysPressed)
                {
                    if (letterPressed.Value == true)
                    {
                        count++;
                        if (count >= 2)
                        {
                            return true;
                        }
                    }
                }
                if (count <= 1)
                {
                    return false;
                }
            }
            return false;

        }
    }
}
