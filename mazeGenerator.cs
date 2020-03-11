using System;
using Set;

namespace MazeGenerator{
	public class MazeGenerator{
		/* disjoint set for generating maze */
		DisjointSet ds;

		/* the number of rows, cols, and cells of maze  */
		int numRow = 0, numCol = 0, numCell = 0;

		/* each cell is element of disjoint set */
		int[,] cellArr;

		/* horizontal edges and vertical edges of maze.
		 * -1: outer edge(wall) of maze. can't delete it except start and end point's
		 * 0: deleted edge.
		 * 1: not deleted edge. */
		int[,] hEdgeArr;
		int[,] vEdgeArr;

		/* for random edge selection */
		int HorV = 0, row = 0, col = 0;

		Random rd;

		public MazeGenerator() {
			Init(5,5);
		}

		public MazeGenerator(int numRow, int numCol){
			Init(numRow, numCol);
		}

		public void Init(int numRow, int numCol){
			/* size of maze */
			this.numRow = numRow;
			this.numCol = numCol;
			numCell = numRow * numCol;

			ds = new DisjointSet(numCell);

			cellArr = new int[numRow, numCol];
			hEdgeArr = new int[numRow+1, numCol];
			vEdgeArr = new int[numRow, numCol+1];

			/* each cell is element of disjoint set */
			int cell = 1;
			for(int i = 0; i < numRow; i++){
				for(int j = 0; j < numCol; j++){
					cellArr[i,j] = cell++;
				}
			}

			/* initialize hEdgeArr and vEdgeArr */
			InitEdgeArr();

			rd = new Random();
		}

		private void InitEdgeArr(){
			int i = 0, j = 0;

			/* Initialize horizontal edge array */

			/*  top and bottom horizontal wall(edge) of maze  */
			for(j = 0; j < numCol; j++){
				hEdgeArr[0,j] = -1;
				hEdgeArr[numRow, j] = -1;
			}

			/* inside horizontal wall(edge) of maze */
			for(i = 1; i < numRow; i++){
				for(j = 0; j < numCol; j++){
					hEdgeArr[i,j] = 1;
				}
			}

			/* Initialize vertical edge array */

			/* leftmost and rightmost vertical wall(edge) of maze */
			for(i = 0; i < numRow; i ++){
				vEdgeArr[i,0] = -1;
				vEdgeArr[i, numCol] = -1;
			}

			/* inside vertical wall(edge) of maze */
			for(i = 0; i < numRow; i++){
				for(j = 1; j < numCol; j++){
					vEdgeArr[i,j] = 1;
				}
			}

			/* delete left wall(edge) of start cell and right wall(edge) of end cell */
			vEdgeArr[0,0] = 0;
			vEdgeArr[numRow-1, numCol] = 0;
		}

		private void EdgeSelect(){
			HorV = rd.Next(2); //0 or 1. 0: horizontal edge   1: vertical edge

			/* horizontal edge */
			if(HorV == 0){
				/* row >= 1 && row < numRow. the value of cells in first and last row are always -1. */
				row = rd.Next(1, numRow);
				col = rd.Next(numCol);
			}
			
			/* vertical edge */
			else{
				/* col >= 1 && col < numCol. the value of cells in first and last column are always -1. */
				row = rd.Next(numRow);
				col = rd.Next(1, numCol);
			}
		}

		public void GenerateMaze(){
			int count = 1;
			int e1 = 0, e2 = 0;
			int r1 = 0, r2 = 0;

			/* initialize hEdgeArr and vEdgeArr */
			InitEdgeArr();

			/* initialize disjoint set */
			ds.Init(numCell);

			/* maze is generated by only (numCell -1) times union operation  */
			while(count < numCell){
				/* random edge selection */
				EdgeSelect();

				/* selected horizontal edge*/
				if(HorV == 0){
					e1 = cellArr[row-1, col];
					e2 = cellArr[row, col];

					r1 = ds.Find(e1);
					r2 = ds.Find(e2);

					if(r1 != r2){
						ds.Union(r1, r2);
						hEdgeArr[row, col] = 0; //delete edge
						count++;
					}
				}

				/* selected vertical edge */
				else{
					e1 = cellArr[row, col-1];
					e2 = cellArr[row, col];

					r1 = ds.Find(e1);
					r2 = ds.Find(e2);

					if(r1 != r2){
						ds.Union(r1, r2);
						vEdgeArr[row, col] = 0; //delete edge
						count++;
					}
				}
			}
		}

		public void PrintMaze(){
			int i = 0, j = 0;

			while(i < numRow+1){
				Console.Write("aa");
				for(j = 0; j < numCol; j++)
					PrintHorizontalEdge(hEdgeArr[i,j]);
				Console.WriteLine();

				for(j = 0; j < numCol+1 && i < numRow; j++ )
					PrintVerticalEdge(vEdgeArr[i,j]);
				Console.WriteLine();

				i++;
			}

		}

		/* "aa" is a wall. "  " is a way. */
		private void PrintHorizontalEdge(int n){
			switch (n)
			{
				case -1:
				case 1:
					Console.Write("aaaa");
					break;
				case 0:
					Console.Write("  aa");
					break;
			}
		}

		private void PrintVerticalEdge(int n){
			switch (n)
			{
				case -1:
				case 1:
					Console.Write("aa  ");
					break;
				case 0:
					Console.Write("    ");
					break;
			}
		}



	}
}
