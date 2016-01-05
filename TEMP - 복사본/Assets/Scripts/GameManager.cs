using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject BallsParentGameObject;
    public GameObject ballPrefab;

    public static List<GameObject> LST_Ball;
    int ballIND = 0;

    public int beingBallCnt;         // 현재 화면에 있는 볼
    public int UserLevel = 1;
    float CreateTimmer = 0.0f;
    public int ballCNT;
    public static int sballCNT;

    public static float gameSpeed = 10.0f;
    bool isStart = false;

    void Awake()
    {
        LST_Ball = new List<GameObject>();
        LST_Ball.Add(Instantiate(ballPrefab));
        beingBallCnt++;
        LST_Ball[LST_Ball.Count - 1].transform.parent = BallsParentGameObject.transform;
    }
    // Use this for initialization

    void Start () {
        if (beingBallCnt < UserLevel)
        {
            for (int i = 1; i <= UserLevel - 1; i++)
            {
                LST_Ball.Add(Instantiate(ballPrefab));
                LST_Ball[LST_Ball.Count - 1].transform.parent = BallsParentGameObject.transform;
                if (i != 0)
                {
                    LST_Ball[LST_Ball.Count - 1].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        ballCNT = LST_Ball.Count;
        sballCNT = ballCNT;
        CreateTimmer += Time.fixedDeltaTime * gameSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && !isStart)
        {
            CreateTimmer = 0;
            ballIND = -1;
            isStart = true;
        }

        if (CreateTimmer - 0.5f > 0.5f && ballIND < UserLevel)
        {
            CreateTimmer = 0.0f;
            ballIND++;
        }

        if (isStart)
        {
            if (CreateTimmer < UserLevel && !LST_Ball[ballIND].transform.FindChild("BallOBJ").GetComponent<BallState>().shoot)
            {
                LST_Ball[ballIND].SetActive(true);
                LST_Ball[ballIND].transform.FindChild("BallOBJ").GetComponent<BallState>().shoot = true;
                beingBallCnt++;
            }
        }
    }
}
