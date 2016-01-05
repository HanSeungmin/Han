using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float RotateAngle;

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate (0.0f, RotateAngle, 0.0f, Space.Self);
	}
}
