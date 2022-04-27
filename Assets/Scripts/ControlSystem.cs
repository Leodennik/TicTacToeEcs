using Leopotam.Ecs;
using UnityEngine;

namespace TicTacToe
{
    class ControlSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        
        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Camera camera = _sceneData.camera;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    var cellView = hitInfo.collider.GetComponent<CellView>();
                    if (cellView != null)
                    {
                        cellView.Entity.Get<Clicked>(); // Устанавливаем компонент Clicked 
                    }
                }
            }
        }
    }
}