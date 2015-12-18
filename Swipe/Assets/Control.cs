using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

    public bool isShoot = false;
    public bool isOntouch = false;
    public Vector3 TouchPOS;
    public Vector3 DragPOS;
    public float AimAngle = 0.0f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        
        Debug.Log(OBJBall.Referance_Object[OBJBall.Referance_Object.Count-1].transform.position);

        if (TouchPOS != DragPOS && !isOntouch)
        {
            isShoot = true;
        }
    }
}
