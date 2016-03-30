using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell  {


	public List<GameObject> Members = new List<GameObject>();

	public BoundingCircle BCircle;

		public Cell(Vector3 v3, float r){
			BCircle = new BoundingCircle(v3, r);
		}

}
