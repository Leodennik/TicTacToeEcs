using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe
{
    public class WinScreen : Screen
    {
        public Text text;
        public void SetWinner(SignType winnerType)
        {
            switch (winnerType)
            {
                case SignType.Cross:  text.text = "Крестик победил"; break;
                case SignType.Circle: text.text = "Нолик победил"; break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(winnerType), winnerType, null);
            }
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}