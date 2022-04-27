using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace TicTacToe
{
    public class GameState
    {
        public SignType currentSign = SignType.Cross;
        public readonly Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>();
        public void ChangeCurrentSign()
        {
            currentSign = (currentSign == SignType.Cross) ? SignType.Circle : SignType.Cross;
        }
    }
}