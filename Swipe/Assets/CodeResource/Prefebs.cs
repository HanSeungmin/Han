using UnityEngine;
using System.Collections;

public class Prefebs : MonoBehaviour {

    public GameObject PlayerBall;
    public GameObject Brick;
    public GameObject Item;
    public static GameObject stt_PlayerBall;
    public static GameObject stt_Brick;
    public static GameObject stt_Item;

    // Use this for initialization
    void Start () {
        stt_Brick = Brick;
        stt_Item = Item;
        stt_PlayerBall = PlayerBall;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
