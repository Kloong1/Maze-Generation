using System;

namespace MazeGeneration{
	public class MazeGeneration{
		DisjointSet ds;

		int numRow = 0, numCol = 0, numCell = 0;

		int[,] cellArr;
		int[,] hEdgeArr;
		int[,] vEdgeArr;

		public MazeGeneration() {}

		public MazeGeneration(int numRow, int numCol){
			Init(numRow, numCol);
		}

		public void Init(int numRow, int numCol){
			this.numRow = numRow;
			this.numCol = numCol;
			numCell = numRow * numCol;

			ds = new DisjointSet(numCell);

			cellArr = new int[numRow, numCol];
			hEdgeArr = new int[numRow+1, numCol];
			vEdgeArr = new int[numRow, numCol+1];

			int cell = 1;
			for(int i = 0; i < numRow; i++){
				for(int j = 0; j < numCol; j++){
					cellArr[i,j] = cell++;
				}
			}

			InitEdgeArr();
		}

		public void InitEdgeArr(){
			int i = 0, j = 0;

			/* Initialize horizontal edge array */
			for(j = 0; j < numCol; j++){
				hEdgeArr[0,j] = -1;
				hEdgeArr[numRow, j] = -1;
			}

			for(i = 1; i < numRow; i++){
				for(j = 0; j < numCol; j++){
					hEdgeArr[i,j] = 1;
				}
			}

			/* Initialize horizontal edge array */
			for(i = 0; i < numRow; i ++){
				vEdgeArr[i,0] = -1;
				vEdgeArr[i, numCol] = -1;
			}

			for(i = 0; i < numRow; i++){
				for(j = 1; j < numCol; j++){
					vEdgeArr[i,j] = 1;
				}
			}

			/* start cell and end cell */
			vEdgeArr[0,0] = 0;
			vEdgeArr[numRow-1, numCol] = 0;
		}



	}
}
