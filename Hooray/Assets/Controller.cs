using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public GameObject Player_OBJ;          // 움직일 오브젝트
    public GameObject Camera;               // 카메라가 오브젝트를 하나의 각도로 따라다님(TPS는 아님)
    public GameObject Control_Area;         // Control_Area
    public GameObject Course;                // 움직일 오브젝트

    public float speed;                     // 움직일 오브젝트의 속도.
    public float Rotspeed;                     // 움직일 오브젝트의 속도.
    public float Angle;                     // 처음 터치된 위치를 기준으로 움드래그로 이동되는 포인트와의 각도
    Vector3 cameraPos;                      // 움직일 오브젝트와 카메라와의 거리
    public Animator ani;

    // 터치 포인트를 가시적으로 표현하기 위해 Unity의 메뉴중 GameObject > UI > Image를 2개 사용하였다.
    public GameObject PNT_A;                // 처음 터치시 포인터 이미지.
    public GameObject PNT_B;                // 터치후 드래그로 이동되는 포인터 이미지.

    public Vector2 pickA;                   // 처음 터치시 포인트의 위치.
    public Vector2 pickB;                   // 터치후 드래그로 이동되는 포인트의 위치.

    bool isTouch = false;                   // 터치여부 확인



    // Use this for initialization
    void Start()
    {
        cameraPos = Camera.transform.position - Player_OBJ.transform.position;
        ani = Player_OBJ.GetComponent<Animator>();
    }

    // Update is called once per frame


    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (Input.GetMouseButtonDown(0))
        {
            PNT_A.transform.position = Control_Area.transform.position;

            isTouch = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
#elif UNITY_ANDROID
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PNT_A.transform.position = Control_Area.transform.position;
            isTouch = true;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isTouch = false;
        }
#endif
        if (isTouch)                                           
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            PNT_B.transform.position = Input.mousePosition;
#elif UNITY_ANDROID
            PNT_B.transform.position = Input.GetTouch(0).position;
#endif
            PNT_A.SetActive(true);                             
            PNT_B.SetActive(true);

            if (distance() >= 100)
            {
                speed = 100.0f * 0.5f;
            }
            if (distance() < 100)
            {
                speed = distance() * 0.5f;
            }
            ani.SetFloat("Length", speed / 30);
            if (PNT_B.transform.position != PNT_A.transform.position) 
            {
                trigonometric_function();                           
            }
            move();
            Vector3 temp = Player_OBJ.transform.position;
            temp.y += 0.2f;
            Course.transform.position = temp;
            Course.transform.eulerAngles = new Vector3(270, Angle, 0);

        }

        if (!isTouch)
        {
            PNT_A.SetActive(false);                             
            PNT_B.SetActive(false);
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            ani.SetFloat("Length", (ani.GetFloat("Length") - 0.03f));
#elif UNITY_ANDROID
            ani.SetFloat("Length", 0);
#endif
        }
    }

    void trigonometric_function()
    {
        float Under = (PNT_A.transform.position.x - PNT_B.transform.position.x); 
        float oblique = Mathf.Pow(((PNT_A.transform.position.y * PNT_A.transform.position.y) + (PNT_A.transform.position.x * PNT_A.transform.position.x)) * ((PNT_A.transform.position.y * PNT_A.transform.position.y) + (PNT_A.transform.position.x * PNT_A.transform.position.x)), 2);
        Angle = Mathf.Atan2(PNT_A.transform.position.x - PNT_B.transform.position.x, PNT_A.transform.position.y - PNT_B.transform.position.y) * 180 / Mathf.PI + 180;
        Vector3 tempAngle = Player_OBJ.transform.eulerAngles;
        if (Angle > tempAngle.y)
        {
            if (Angle > tempAngle.y + 180)
            {
                tempAngle.y -= 2;
                Player_OBJ.transform.eulerAngles = tempAngle;
            }
            else
            {
                tempAngle.y += 2;
                Player_OBJ.transform.eulerAngles = tempAngle;
            }
        }

        if (Angle < tempAngle.y)
        {
            if (Angle < tempAngle.y - 180)
            {
                tempAngle.y += 2;
                Player_OBJ.transform.eulerAngles = tempAngle;
            }
            else
            {
                tempAngle.y -= 2;
                Player_OBJ.transform.eulerAngles = tempAngle;
            }
        }
    }

    void move()
    {
        Vector3 Obj_Forward = Player_OBJ.transform.forward;
        Vector3 Obj_POS = Player_OBJ.transform.position;
        Vector3 Obj_Move = Obj_POS + Obj_Forward * speed * Time.deltaTime;
        Player_OBJ.transform.position = Obj_Move;
        Camera.transform.position = cameraPos + Player_OBJ.transform.position;
    }

    float distance()
    {
        float distance = Mathf.Sqrt((PNT_A.transform.position.x - PNT_B.transform.position.x) * (PNT_A.transform.position.x - PNT_B.transform.position.x) + (PNT_A.transform.position.y - PNT_B.transform.position.y) * (PNT_A.transform.position.y - PNT_B.transform.position.y));
        return distance;
    }
}


