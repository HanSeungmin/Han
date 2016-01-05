using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("this");
	}
}
