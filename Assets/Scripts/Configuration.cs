using UnityEngine;

namespace TicTacToe
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public int levelWidth = 3;
        public int levelHeight = 3;
        public int chainLength = 3;
       
        public Vector2 offset;

        public CellView cellView;
        public SignView crossView;
        public SignView circleView;
    }
}