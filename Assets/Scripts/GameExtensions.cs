using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace TicTacToe
{
    public static class GameExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            List<EcsEntity> horizontalCombo = new List<EcsEntity>();
            SearchCombo(cells, horizontalCombo, SignType.None, position, new Vector2Int(1, 0));
            
            List<EcsEntity> verticalCombo = new List<EcsEntity>();
            SearchCombo(cells, verticalCombo, SignType.None, position, new Vector2Int(0, 1));
            
            List<EcsEntity> diagonalCombo = new List<EcsEntity>();
            SearchCombo(cells, diagonalCombo, SignType.None, position, new Vector2Int(1, 1));
            
            List<EcsEntity> inverseDiagonalCombo = new List<EcsEntity>();
            SearchCombo(cells, inverseDiagonalCombo, SignType.None, position, new Vector2Int(-1, 1));
            
            return Math.Max(inverseDiagonalCombo.Count, Math.Max(diagonalCombo.Count, Math.Max(horizontalCombo.Count, verticalCombo.Count)));
        }
        
        private static void SearchCombo(Dictionary<Vector2Int, EcsEntity> cells, List<EcsEntity> combo,  SignType startType, Vector2Int position, Vector2Int directionVector)
        {
            if (!cells.TryGetValue(position, out var entity)) return;
            if (combo.Contains(entity) || entity.Has<Taken>() == false) return;
            
            SignType type = entity.Ref<Taken>().Unref().value;
            if (startType == SignType.None) startType = type;
            if (type != startType) return;
            
            combo.Add(entity);
            
            SearchCombo(cells, combo, startType, position - directionVector, directionVector);
            SearchCombo(cells, combo, startType, position + directionVector, directionVector);
        }
    }
}