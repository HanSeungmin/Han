using UnityEngine;
using System.Collections;
using Assets.CodeResource;

public class Ball_State : MonoBehaviour {

    private bool isShoot = false;
    private float Angle = 0.0f;
    public float fAngle = 0.0f;
    public static Vector3 lendingPos;
    public int BounceCNT = 0;
    public bool isMove = false;
    



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // 추후 볼에 대한 업데이트 부분은 델리게이트로 처리한다.
        if (Control.isShoot)
        {
            if (isMove)
            {
                if (!isShoot)
                {
                    Angle = OBJBall.ShootAngle;
                    isShoot = true;
                }

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
                isShoot = false;
            }
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
            if (Control.isShoot)
            {
                Instantiate(Prefebs.stt_PlayerBall);
                Control.stt_ballCNT++;
                BounceCNT++;
                Angle -= 180;
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
}
