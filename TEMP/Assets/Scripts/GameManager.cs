using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject BallsParentGameObject;
    public GameObject ballPrefab;

    public static Vector3 home;

    public static List<GameObject> LST_Ball;
    int ballIND = 0;

    public int beingBallCnt;         // 현재 화면에 있는 볼
    public int UserLevel = 1;
    float CreateTimmer = 0.0f;
    public int ballCNT;
    public static int sballCNT;

    public static float gameSpeed = 1.0f;
    public bool isStart = false;

    void Awake()
    {
        LST_Ball = new List<GameObject>();
        LST_Ball.Add(Instantiate(ballPrefab));
        beingBallCnt++;
        LST_Ball[LST_Ball.Count - 1].transform.parent = BallsParentGameObject.transform;
    }

    // Update is called once per frame
    void Update () {

        ballCNT = LST_Ball.Count;
        sballCNT = ballCNT;
        CreateTimmer += Time.fixedDeltaTime * gameSpeed * 5.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballIND = -1;
            isStart = true;
            LST_Ball[0].transform.FindChild("BallOBJ").GetComponent<BallState>().shoot = true;
            home = Vector3.zero;
        }

        if (isStart)
        {
            if (CreateTimmer > 0.5f && beingBallCnt < UserLevel)
            {
                CreateTimmer = 0.0f;
                beingBallCnt++;
                LST_Ball.Add(Instantiate(ballPrefab));
                LST_Ball[LST_Ball.Count - 1].transform.parent = BallsParentGameObject.transform;
                LST_Ball[LST_Ball.Count - 1].transform.FindChild("BallOBJ").GetComponent<BallState>().shoot = true;
            }
        }

        checkBallLST();
    }

    void checkBallLST()
    {
        for (int i = 0; i < LST_Ball.Count; i++)
        {
            if (LST_Ball[i] == null)
            {
                LST_Ball.Remove(LST_Ball[i]);
            }
        }
        if (LST_Ball.Count == 0)
        {
            isStart = false;
            beingBallCnt = 0;
        }
    }
}
