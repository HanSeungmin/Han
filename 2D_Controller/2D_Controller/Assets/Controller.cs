using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public GameObject Player_OBJ;          // 움직일 오브젝트
    public GameObject Camera;               // 카메라가 오브젝트를 하나의 각도로 따라다님(TPS는 아님)
    public float speed;                     // 움직일 오브젝트의 속도.
    public float Angle;                     // 처음 터치된 위치를 기준으로 움드래그로 이동되는 포인트와의 각도
    Vector3 cameraPos;                      // 움직일 오브젝트와 카메라와의 거리


    // 터치 포인트를 가시적으로 표현하기 위해 Unity의 메뉴중 GameObject > UI > Image를 2개 사용하였다.
    public GameObject PNT_A;                // 처음 터치시 포인터 이미지.
    public GameObject PNT_B;                // 터치후 드래그로 이동되는 포인터 이미지.

    public Vector2 pickA;                   // 처음 터치시 포인트의 위치.
    public Vector2 pickB;                   // 터치후 드래그로 이동되는 포인트의 위치.

    bool isTouch = false;                   // 터치여부 확인



    // Use this for initialization
    void Start()
    {
        cameraPos = Camera.transform.position - Player_OBJ.transform.position; // 시작하면서 움직일 오브젝트와 카메라와의 거리를 정한다.
    }

    // Update is called once per frame

    void Update()
    {

        // 테스트용 코딩으로, 움직일 오브젝트를 지속적으로 앞(Forward)방향으로 이동시킴.
        Vector3 Obj_Forward = Player_OBJ.transform.forward;
        Vector3 Obj_POS = Player_OBJ.transform.position;
        Vector3 Obj_Move = Obj_POS + Obj_Forward * speed * Time.deltaTime;
        Player_OBJ.transform.position = Obj_Move;
        Camera.transform.position = cameraPos + Player_OBJ.transform.position;
        ////////////////////////////////////////////////////////////////////////////////

        if (Input.GetMouseButtonDown(0))                        // 화면 터치상태라면.
        {
            PNT_A.transform.position = Input.mousePosition;     // 처음 터치시 포인트의 위치로 지정함.
            isTouch = true;                                     // 터치를 활성화.
        }

        if (Input.GetMouseButtonUp(0))                          // 터치가 아니라면
        {
            isTouch = false;                                    // 터치활성화를 끔.
        }

        if (isTouch)                                            // 터치활성화 상태라면
        {
            PNT_B.transform.position = Input.mousePosition;     // 드래그 포인트의 위치를 지속적으로 터치 포인트의 위치로 갱신시킴.
            PNT_A.SetActive(true);                              // 처음 터치 포인터를 켬
            PNT_B.SetActive(true);                              // 드래그 터치 포인터를 켬

            if (PNT_B.transform.position != PNT_A.transform.position)       // 자연스러움을 위해 터치즉시 각도를 변경하는게 아니라 드래그가 발생되면 각도를 변경시킴
            {
                trigonometric_function();                           // 처음 터치 포인터의 위치와, 드래그 포인터의 위치의 각도를 삼각함수로 계산하는 함수.(직접만듬)
            }

        }

        if (!isTouch)                                           // 터치활성화가 꺼져 있다면.
        {
            PNT_A.SetActive(false);                             // 처음 터치 포인터를 끈다. 
            PNT_B.SetActive(false);                             // 드래그 포인터를 끈다.
        }
    }

    void trigonometric_function()
    {
        float Under = (PNT_A.transform.position.x - PNT_B.transform.position.x); // 밑변(Under)의 길이(처음 터치 포인트의 위치 x와 드래그 터치 포인트의 위치 x와의 거리로 산출함)
        float oblique = Mathf.Pow(((PNT_A.transform.position.y * PNT_A.transform.position.y) + (PNT_A.transform.position.x * PNT_A.transform.position.x)) * ((PNT_A.transform.position.y * PNT_A.transform.position.y) + (PNT_A.transform.position.x * PNT_A.transform.position.x)), 2);
        // 빗변(oblique)의 길이를 산출함. 공식 (y*y)+(x*x) = c^2
        // Pow의 매개변수 Pow (float f, float p) : f = 값, p = 몇 제곱.
        Angle = Mathf.Atan2(PNT_A.transform.position.x - PNT_B.transform.position.x, PNT_A.transform.position.y - PNT_B.transform.position.y) * 180 / Mathf.PI + 180;
        // 하나의 백터는 방향성과, 크기를 갖고 있다는 점을 반드시 기억할것.
        // Atan2는 하나의 백터를 이용하여 Tan값을 산출함. 그러므로 중심이 되는 위치(PNT_A)에서 목표위치(PNT_B)값을 구해야 하기 때문에 PNT_A - PNT_B를 한 x, y값을 대입해줌.
        // 삼각함수의 최대 값은 삼각형의 각도값인 90도 이기 때문에  (삼각함수 * 180 / Mathf.PI) 로 보정해줌.
        //  + 180를 한 이유는 화면의 위쪽을 0으로 셋팅하기 위함
        // Angle값이 일반적인 각도로 산출됨.

        Player_OBJ.transform.eulerAngles = new Vector3(0, Angle, 0);
        // 오브젝트를 우리가 알고 있는 360도법 각도로 회전시키기 위해서는 반드시 eulerAngles(오일러 앵글)을 사용해야 함.
        // transform.rotation은 360도법을 이해하지 못함. 반드시 transform.eulerAngles을 이용해야 함.
    }
}


