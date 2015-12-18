using UnityEngine;
using System.Collections;

public class Ball_State : MonoBehaviour {

    public static float Angle = 0.0f;
    public static Vector3 lendingPos;
    public static float Speed = 7.0f;
    public bool isMove = false;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isMove)
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, Angle, 0); ;

            Vector3 thisPOS = this.gameObject.transform.position;
            Vector3 Dirction = this.gameObject.transform.forward;
            Vector3 newPOS = thisPOS + Dirction * Speed * Time.deltaTime;
            this.gameObject.transform.position = newPOS;
        }
	 
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Item"))
        {
            Debug.Log("bingo");
        }

        else if (col.gameObject.CompareTag("DeadLine"))
        {
            Debug.Log("bingo");
        }

        else if (col.gameObject.CompareTag("Brick"))
        {
            Debug.Log("bingo");
            this.gameObject.transform.position = new Vector3(0, 0, 0);
        }

        else if (col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("bingo");
        }
    }
}
