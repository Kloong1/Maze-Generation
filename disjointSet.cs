using System;
using ElementType = System.Int32;

namespace Set{

	public class DisjointSet {
		private ElementType[] Set;

		public DisjointSet() { }

		public DisjointSet(int n){
			Init(n);
		}

		public void Init(int n) {
			Set = new ElementType[n+1];
			
			for(int i = 1; i <= n; i++)
				Set[i] = 0;
		}

		public ElementType Find(ElementType x){
			while(Set[x] > 0)
				x = Set[x];

			return x;
		}

		public void Union(ElementType r1, ElementType r2){
			/* if rank of r1 tree is larger than r2*/
			if(Set[r1] < Set[r2])
				Set[r2] = r1;
			/* if rank of r1 tree is same or smaller than r1*/
			else{
				if(Set[r1] == Set[r2]) //same rank
					Set[r2]--; // rank up
				Set[r1] = r2;
			}

		}
	}
}
