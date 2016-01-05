using UnityEngine;
using System.Collections;

public class SunRotate : MonoBehaviour {

	public float Rotate;

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate (Rotate * Time.deltaTime * -1, 0, 0, Space.World);
	}
}
