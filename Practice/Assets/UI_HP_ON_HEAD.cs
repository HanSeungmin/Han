using UnityEngine;
using System.Collections;

public class UI_HP_ON_HEAD : MonoBehaviour {
    public GameObject target;
    public Camera camera2D;


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        Vector3 pos  = target.transform.position;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        this.transform.position = camera2D.ScreenToWorldPoint(screenPos);


    }


}
