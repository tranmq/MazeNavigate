# MazeNavigate
The C# solution to finding the shortest path through a defined  maze from the entrance to the exit.

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


