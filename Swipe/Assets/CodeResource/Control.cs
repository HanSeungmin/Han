using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

    public static bool isShoot = false;
    public bool in_shoot = false;
    public bool isOntouch = false;
    public Vector3 TouchPOS;
    public Vector3 DragPOS;
    public float AimAngle = 0.0f;
    public int ballcnt = 0;
    public static int stt_ballCNT = 1;  // 삭제

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        isShoot = in_shoot;
        ballcnt = stt_ballCNT;
        if (TouchPOS != DragPOS && !isOntouch)
        {
            isShoot = true;
        }
    }
}
