using UnityEngine;
using System.Collections;
using Assets.CodeResource;

public class Ball_State : MonoBehaviour {

    public static float Angle = 0.0f;
    public float fAngle = 0.0f;
    public static Vector3 lendingPos;
    public int BounceCNT = 0;
    float spinLevel = 0.0f;
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
            Vector3 newPOS = thisPOS + Dirction * maingame.GameSpeed * Time.deltaTime;
            this.gameObject.transform.position = newPOS;
            fAngle = Angle;

            if (maingame.BestBounce < BounceCNT)
            {
                maingame.BestBounce = BounceCNT;
            }
        }
        else
        {
            BounceCNT = 0;
        }

        if (Control.isShoot)
        {
            Vector3 newspin = new Vector3(0, spinLevel, 0);
            spinLevel += 0.1f;
            newspin.y = spinLevel;
            this.gameObject.transform.Rotate(newspin);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Item"))
        {
        }

        else if (col.gameObject.CompareTag("DeadLine"))
        {
        }

        else if (col.gameObject.CompareTag("Brick"))
        {
        }

        else if (col.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("bingo");
            BounceCNT++;
            Angle -= 180 ;
            if (Angle > 360)
            {
                Angle -= 360;
            }
            if (Angle < 0)
            {
                Angle += 360;
            }
        }
    }
}
