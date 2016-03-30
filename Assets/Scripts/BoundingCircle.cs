using UnityEngine;
using System.Collections;

public class BoundingCircle {

	private Vector3 center;
	private float radius;

	public BoundingCircle(Vector3 v3, float r)
	{
				center = v3;
				radius = r;
	}

	public bool isOverlappedWith(BoundingCircle other)
	{
				if (Vector3.Distance (this.center, other.center) < 2 * radius)
						return true;
				else
						return false;
	}
		
	public Vector3 Center()
	{
				return center;
	}

	public float Radius()
	{
				return radius;
	}

}
