using Leopotam.Ecs;
using UnityEngine;

namespace TicTacToe
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> _filter;
        private Configuration _configuration;
        
        public void Run()
        {
            foreach (int index in _filter)
            {
                Vector3 position = _filter.Get2(index).value.transform.position;
                SignType takenType = _filter.Get1(index).value;

                SignView signView = null;
                switch (takenType)
                {
                    case SignType.Cross:  signView = _configuration.crossView;   break;
                    case SignType.Circle: signView = _configuration.circleView;  break;
                }

                SignView instance = Object.Instantiate(signView, position, Quaternion.identity);
                _filter.GetEntity(index).Get<TakenRef>().value = instance;
            }
        }
    }
}