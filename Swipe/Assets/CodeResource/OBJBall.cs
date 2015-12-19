using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class OBJBall : MonoBehaviour {

    public static Vector3 stt_fstBallsLendingPos;
    public static float ShootAngle;
    public GameObject Orignal_Object;


    public static List<GameObject> Referance_Object;

    // Use this for initialization
    void Start () {
        Referance_Object = new List<GameObject>();     // Unity의 Inspector에서 받아온 오브젝트를 Static으로 옮겨 준다.
        Referance_Object.Add(Orignal_Object);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
