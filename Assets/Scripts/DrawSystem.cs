using Leopotam.Ecs;

namespace TicTacToe
{
    public class DrawSystem : IEcsRunSystem
    {
        private EcsFilter<Cell>.Exclude<Taken> _freeCellsFilter;
        private EcsFilter<Winner> _winner;
        private SceneData _sceneData;
       
        public void Run()
        {
            if (_freeCellsFilter.IsEmpty() && _winner.IsEmpty())
            {
                _sceneData.UI.drawScreen.Show(true);
            }
        }
    }
}