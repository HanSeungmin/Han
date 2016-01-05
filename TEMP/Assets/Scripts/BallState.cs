using UnityEngine;
using System.Collections;

public class BallState : MonoBehaviour {

    public bool shoot = false;
    public bool gohome = false;
    float ballSpeed = 7.0f;
    Vector3 normalVector;

    void FixedUpdate()
    {
        if (shoot)
        {
            ballsMove();
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        Vector3 incommingVec = this.transform.parent.forward;
        Vector3 NomalVec = col.contacts[0].normal;
        this.transform.parent.forward = Vector3.Reflect(incommingVec, NomalVec).normalized;
        col.gameObject.GetComponent<objLife>().objectLife--;
    }

    void ballsMove()
    {
        this.transform.parent.transform.Translate(0,0,Time.fixedDeltaTime * ballSpeed);
    }
}


