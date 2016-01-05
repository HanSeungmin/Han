using UnityEngine;
using System.Collections;

public class OBJRotate : MonoBehaviour {

	public float RotateSpeed;		// 초당 변하길 원하는 각도를 넣습니다.

	bool in1 = false;
	bool in2 = false;
	bool in3 = false;
	bool in4 = false;
	bool in5 = false;
	bool in6 = false;
	bool in7 = false;
	bool in8 = false;
	bool in9 = false;

	//배열이 어렵지 않다면 이렇게 bool[] nowin = new bool[9];


	void Update () {
		
		int i = Random.Range(1, 10); //1~9중 랜덤하게 정하기
		if (i == 1 && in1 == false)
		// 배열을 쓰셨다면 이렇게 if (i == 1 && !nowin[0])
		{
			GameObject instance = Instantiate(Resources.Load("Coin", typeof(GameObject))) as GameObject; //코인불러오기
			instance.transform.position = new Vector3(-1.9f, 0.1f, 0); //1번자리에 소환하기
			Destroy(instance, 5.5f);// 5.5초뒤 사라지기
			in1 = true;
			// 배열을 쓰셨다면 이렇게 nowin[0] = true;

			
		}
		if (i == 2) // 위와 같음
		{
	}
}


