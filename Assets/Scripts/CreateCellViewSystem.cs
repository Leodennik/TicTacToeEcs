using Leopotam.Ecs;
using UnityEngine;

namespace TicTacToe
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        // Получить все энтити, которые имеют Cell и Position, но исключить CellRefView
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;
        private Configuration _configuration;
        
        public void Run()
        {
            foreach (int index in _filter)
            {
                EcsEntity entity = _filter.GetEntity(index);
                ref Position position = ref _filter.Get2(index);

                var cellView = Object.Instantiate(_configuration.cellView);
                cellView.transform.position = new Vector3(
                    position.value.x * (1 + _configuration.offset.x),
                    position.value.y * (1 + _configuration.offset.y));

                cellView.Entity = entity;
                entity.Get<CellViewRef>().value = cellView;
            }
        }
    }

    
    // Структура в которой хранится ссылка на View
    internal struct CellViewRef
    {
        public CellView value;
    }
}