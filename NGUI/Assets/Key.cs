using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    string str = "Press Space bar";
    float accountTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (str == "Hello Jack")
            {
                str = "Press Space bar";
            }
            else if (str == "Press Space bar")
            {
                str = "Hello Jack";
            }
            this.GetComponent<UILabel>().text = str;
        }
        accountTime = accountTime < 1 ? accountTime + 0.1f : accountTime - 0.1f;
        this.transform.parent.GetComponent<UIPanel>().alpha = accountTime;

    }
}
