using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeNavigate.Tests
{
    [TestClass]
    public class MazePathFinderUnitTests
    {
        private readonly MazePathFinder _pathFinder = new MazePathFinder();

        [TestMethod]
        public void FindPath_WhenTheMazeInputIsNull_ShouldReturnEmptyList()
        {
            var entrance = new Index(0, 0);
            var exit = new Index(10, 10);
            IList<Index> path = _pathFinder.FindPath(null, entrance, exit);

            Assert.IsNotNull(path);
            Assert.AreEqual(0, path.Count);
        }

        [TestMethod]
        public void FindPath_WhenTheMazeHasNoDimensions_ShouldReturnEmptyList()
        {
            var entrance = new Index(0, 0);
            var exit = new Index(10, 10);
            var maze = new uint[0, 0];
            IList<Index> path = _pathFinder.FindPath(maze, entrance, exit);

            Assert.IsNotNull(path);
            Assert.AreEqual(0, path.Count);
        }

        [TestMethod]
        public void FindPath_WhenTheEntranceIsNotOnPath_ShouldReturnEmptyList()
        {
            var entrance = new Index(0, 0);
            var exit = new Index(2, 2);
            var maze = new uint[,]
                       {
                           {1,0,0},
                           {1,0,1},
                           {1,0,0}
                       };
            IList<Index> path = _pathFinder.FindPath(maze, entrance, exit);

            Assert.IsNotNull(path);
            Assert.AreEqual(0, path.Count);
        }

        [TestMethod]
        public void FindPath_WhenTheExitIsNotOnPath_ShouldReturnEmptyList()
        {
            var entrance = new Index(0, 1);
            var exit = new Index(2, 0);
            var maze = new uint[,]
                       {
                           {1,0,0},
                           {1,0,1},
                           {1,0,0}
                       };
            IList<Index> path = _pathFinder.FindPath(maze, entrance, exit);

            Assert.IsNotNull(path);
            Assert.AreEqual(0, path.Count);
        }

        [TestMethod]
        public void FindPath_WhenMazeIsOneStraightHorizonLine_ShouldSucceed()
        {
            var entrance = new Index(0, 0);
            var exit = new Index(0, 4);
            var maze = new uint[,] { {0,0,0,0,0} };

            var expectedPath = new List<Index>()
                               {
                                   new Index(0, 0),
                                   new Index(0, 1),
                                   new Index(0, 2),
                                   new Index(0, 3),
                                   new Index(0, 4)
                               };
            List<Index> actualPath = _pathFinder.FindPath(maze, entrance, exit);
            
            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void FindPath_WhenMazeIsOneStraightVerticalLine_ShouldSucceed()
        {
            var entrance = new Index(0, 0);
            var exit = new Index(4, 0);
            var maze = new uint[,]
                       {
                           {0},
                           {0},
                           {0},
                           {0},
                           {0}
                       };

            var expectedPath = new List<Index>()
                               {
                                   new Index(0, 0),
                                   new Index(1, 0),
                                   new Index(2, 0),
                                   new Index(3, 0),
                                   new Index(4, 0)
                               };
            List<Index> actualPath = _pathFinder.FindPath(maze, entrance, exit);
            
            CollectionAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void FindPath_OnDeadEnd_ShouldReturnEmptyList()
        {
            var entrance = new Index(0, 2);
            var exit = new Index(4, 4);
            var maze = new uint[,]
                       {
                           {1,0,0,1,1},
                           {1,0,1,1,1},
                           {1,1,0,0,1},
                           {1,1,1,0,1},
                           {1,1,1,0,1}
                       };
            IList<Index> path = _pathFinder.FindPath(maze, entrance, exit);

            Assert.IsNotNull(path);
            Assert.AreEqual(0, path.Count);
        }
    }
}
