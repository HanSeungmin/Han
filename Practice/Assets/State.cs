using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

    public GameObject player;
    public GameObject statebar;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            statebar.GetComponent<UISlider>().value -= 0.1f;
        }
	
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.position += Vector3.forward;
        }
   

	}

}
