using UnityEngine;
using System.Collections;

public class Minimap_Player_Point_Position : MonoBehaviour {

    public GameObject PlayerPOS;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = PlayerPOS.transform.position;
        temp.y = 190;
        this.transform.position = temp;
	}
}
