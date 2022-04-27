﻿using Leopotam.Ecs;
using UnityEngine;

namespace TicTacToe
{
    internal class InitializeFieldSystem : IEcsInitSystem
    {
        private Configuration _configuration;
        private EcsWorld _world;
        private GameState _gameState;
        
        public void Init()
        {
            for (int x = 0; x < _configuration.levelWidth; x++)
            {
                for (int y = 0; y < _configuration.levelHeight; y++)
                {
                    EcsEntity cellEntity = _world.NewEntity();
                    cellEntity.Get<Cell>();
                    
                    Vector2Int position = new Vector2Int(x, y);
                    cellEntity.Get<Position>().value = position;
                    
                    _gameState.cells[position] = cellEntity;
                }
            }

            _world.NewEntity().Get<UpdateCameraEvent>();
        }
    }
}