using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

	private int CompareByY (Vector3 lhs, Vector3 rhs) {
		if (lhs == null) return (rhs == null) ? 0 : -1;
		if (rhs == null) return 1;

		return lhs.y.CompareTo(rhs.y);
	}

	public int wayPointsNumber = 10;
	public int falls;
	public float pathDuration = 100;
	public List<Vector3> positions;
	public List<float> arrivalTimes;

	void Start() {
		falls = 0;
		positions = new List<Vector3> ();
		arrivalTimes = new List<float> ();

		for (int i = 0; i < wayPointsNumber; i++) {
			float t = Random.Range (0.0f, pathDuration);
			Vector3 pos = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(0.0f, 2.0f), Random.Range(-0.2f, 0.2f)); 
			// TODO: Adjust the values

			positions.Add(pos);
			arrivalTimes.Add(t);
		}
		arrivalTimes.Sort();
		positions.Sort (CompareByY);

		for(int i=0; i<falls; i++) {
			int pos = Random.Range(1, wayPointsNumber);

			Vector3 tmp = positions [pos];
			positions [pos] = tmp;
			positions [pos - 1] = tmp;
		}
	}
}
