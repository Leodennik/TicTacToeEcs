using Leopotam.Ecs;

namespace TicTacToe
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsFilter<Winner, Taken> _filter;
        private SceneData _sceneData;
        
        public void Run()
        {
            if (!_sceneData.UI.winScreen.gameObject.activeInHierarchy)
            {
                foreach (int index in _filter)
                {
                    ref var winnerType = ref _filter.Get2(index);
                    _sceneData.UI.winScreen.Show(true);
                    _sceneData.UI.winScreen.SetWinner(winnerType.value);
                
                    _filter.GetEntity(index).Del<Winner>();
                }
            }
        }
    }
}