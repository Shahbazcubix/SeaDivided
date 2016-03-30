using UnityEngine;
using System.Collections;

public class LightPosition : MonoBehaviour {

	public Vector3[] positions;
	public int i;
	public bool runChange;

	// Use this for initialization
	void Start () {

		runChange = true;

		transform.position = new Vector3 (500.0f, 900.0f, 500.0f);
		positions = new Vector3[6];
		positions[0] = new Vector3 (500.0f, 900.0f, 500.0f);
		positions [1] = new Vector3 (500.0f, 500.0f, 900.0f);
		positions [2] = new Vector3 (900.0f, 500.0f, 500.0f);
		positions [3] = new Vector3 (500.0f, 500.0f, 100.0f);
		positions [4] = new Vector3 (100.0f, 500.0f, 500.0f);
		positions [5] = new Vector3 (500.0f, 100.0f, 500.0f);

		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
	/*
		if (runChange) {
			StartCoroutine(changePositions());
		}
		*/
	}

	IEnumerator changePositions() {
		runChange = false;
		yield return new WaitForSeconds(30);
		i++;
		if (i > 5) {
			i = 0;
		}

		transform.position = positions[i];
		runChange = true;
	}
}
