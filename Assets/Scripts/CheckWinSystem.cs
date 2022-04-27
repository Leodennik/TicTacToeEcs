using Leopotam.Ecs;

namespace TicTacToe
{
    public class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> _filter;
        private GameState _gameState;
        private Configuration _configuration;
        
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                foreach (int index in _filter)
                {
                    ref var position   = ref _filter.Get1(index);

                    int chainLength = _gameState.cells.GetLongestChain(position.value);
                    if (chainLength >= _configuration.chainLength)
                    {
                        _filter.GetEntity(index).Get<Winner>();
                    }
                }
            }
        }
    }
}