# MazeNavigate
The C# solution to finding the shortest path through a defined  maze from the ENTRANCE to the EXIT.

The maze is defined as a matrix/2D array with 0s representing paths and 1s representing blocks.

### Sample mazes:

Circle:
~~~
{{0,0,0,0,0},
 {0,1,1,1,0},
 {0,1,1,1,0},
 {0,1,1,1,0},
 {0,0,0,0,0}};
~~~

Spiral:
~~~
{{0,0,0,0,0},
 {0,1,1,1,1},
 {0,1,0,0,1},
 {0,1,1,0,1},
 {0,0,0,0,1}}
~~~

Horizontal Line:
~~~
{{0,0,0,0,0}};
~~~

Vertical Line:
~~~
{{0},
 {0},
 {0},
 {0},
 {0}};
~~~

The **ENTRANCE** and the **EXIT** are the indices of the 2 elements on the matrix.

If there is a path from the **ENTRANCE** to the **EXIT**, a list with all the indices connecting the **ENTRANCE** and the **EXIT** is returned.

If there are multiple choices, the list of the shortest path is returned.

If there is no path from the **ENTRANCE** to the **EXIT**, the empty list is returned.

## The Implementation

The class that implements the algorithm is the `MazePathFinder` class which implements the `IMazePathFinder` interface.  There is only 1 public function in the class, the `List<Index> FindPath(uint[,] maze, Index entrance, Index exit)`.  The `MazePathFinderUnitTests` is a good place to find out how to use the function.

Intuitively, I would want to read the matrix representation of the maze, import the paths (elements with 0s as values) into some data structure then perform BFS on it.  But if the maze is large, say 1000x1000, and there are only 10 0-elements, it'll be a waste scanning the large amount of 1-elements in the array.  So I decided to perform BFS on discovery starting from the **ENTRANCE**.  Hence, the `Node` class and the `HashSet` of `Node` objects to track visited elements in the array.  The `Path` property of the `Node` class is only for backtracking to build the path from the **ENTRANCE** to the **EXIT**.

For unit testing, I usually use [NUnit](https://www.nunit.org/ "NUnit").  But I use MSTest here because it serves me well for all the test cases I wanted to write.  No need to reference NUnit NuGet package.
