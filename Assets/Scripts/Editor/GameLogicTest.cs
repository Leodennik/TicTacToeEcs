using System.Collections.Generic;
using Leopotam.Ecs;
using NUnit.Framework;
using UnityEngine;

namespace TicTacToe
{
    [TestFixture]
    public class GameLogicTest
    {
        [Test]
        public void CheckHorizontalChainThreeCross()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = BuildCells(world);
            
            cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0));
            Assert.AreEqual(3, chainLength);
            world.Destroy();
        }

        
        [Test]
        public void CheckHorizontalChainZero()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = BuildCells(world);
            
            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0));
            Assert.AreEqual(0, chainLength);
            world.Destroy();
        }
        
        [Test]
        public void CheckHorizontalChainOne()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = BuildCells(world);
            
            cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0));
            Assert.AreEqual(1, chainLength);
            world.Destroy();
        }
        

        [Test]
        public void CheckHorizontalChainCrossCircleCross()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = BuildCells(world);
            
            cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().value = SignType.Circle;
            cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(1, 0));
            Assert.AreEqual(1, chainLength);
            world.Destroy();
        }

        
        [Test]
        public void CheckDiagonalChain()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = BuildCells(world);
            
            cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 1)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(2, 2)].Get<Taken>().value = SignType.Cross;
            
            cells[new Vector2Int(0, 1)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 2)].Get<Taken>().value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(1, 1));
            Assert.AreEqual(3, chainLength);
            world.Destroy();
        }

        [Test]
        public void CheckInverseDiagonalChain()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = BuildCells(world);
            
            cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 1)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 2)].Get<Taken>().value = SignType.Cross;
            
            cells[new Vector2Int(0, 1)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 2)].Get<Taken>().value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(1, 1));
            Assert.AreEqual(3, chainLength);
            world.Destroy();
        }

        private static Dictionary<Vector2Int, EcsEntity> BuildCells(EcsWorld world)
        {
            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };

            return cells;
        }
        
        private static EcsEntity CreateCell(EcsWorld world, Vector2Int position)
        {
            EcsEntity entity = world.NewEntity();
            entity.Get<Position>().value = position;
            entity.Get<Cell>();

            return entity;
        }
    }
}
