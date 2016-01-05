using UnityEngine;
using System.Collections;

public class BallState : MonoBehaviour {

    public bool shoot = false;
    public float rotationSpeed;

    void FixedUpdate()
    {
        rotationSpeed *= Time.deltaTime * 10 ;
        if (shoot)
        {
            ballsMove();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (shoot)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Wall") || col.gameObject.layer == LayerMask.NameToLayer("Brick"))
            {
                if (col.tag == "Destroy")
                {
                    shoot = false;
                    this.gameObject.SetActive(false);
                }
                Vector3 incomingVector = this.gameObject.transform.parent.forward.normalized;
                Vector3 normalVector = col.gameObject.transform.forward.normalized;
                Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);
                reflectVector = reflectVector.normalized;

                this.gameObject.transform.parent.forward = reflectVector;
            }
        }
    }

    void ballsMove()
    {
        this.transform.parent.transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}


