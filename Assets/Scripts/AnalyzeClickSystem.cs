using System;
using Leopotam.Ecs;

namespace TicTacToe
{
    class AnalyzeClickSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter;
        private GameState _gameState;
        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (int index in _filter)
            {
                EcsEntity entity = _filter.GetEntity(index);

                entity.Get<Taken>().value = _gameState.currentSign;
                entity.Get<CheckWinEvent>();
                
                _gameState.ChangeCurrentSign();

                _sceneData.UI.gameHud.SetTurn(_gameState.currentSign);
            }
        }
    }
}