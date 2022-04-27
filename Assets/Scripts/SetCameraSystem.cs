using Leopotam.Ecs;
using UnityEngine;

namespace TicTacToe
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> _filter;
        private SceneData _sceneData;
        private Configuration _configuration;
        
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                int width = _configuration.levelWidth;
                int height = _configuration.levelHeight;
                Camera camera = _sceneData.camera;
                camera.orthographic = true;
                camera.orthographicSize = height / 2.0f + (height-1) * _configuration.offset.y / 2.0f;
                
                _sceneData.camera.transform.position = new Vector2(
                    width / 2.0f + (width-1) * _configuration.offset.x / 2.0f, 
                    height / 2.0f + (height-1) * _configuration.offset.y / 2.0f);
            }
        }
    }

    public struct UpdateCameraEvent
    {
        
    }
}