using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class GameHud : MonoBehaviour
    {
        public Text text;
        public void SetTurn(SignType currentSign)
        {
            switch (currentSign)
            {
                case SignType.Cross: text.text = "Ходит КРЕСТИК"; break;
                case SignType.Circle: text.text = "Ходит НОЛИК";  break;
                default: throw new ArgumentOutOfRangeException(nameof(currentSign), currentSign, null);
            }
        }
    }
}