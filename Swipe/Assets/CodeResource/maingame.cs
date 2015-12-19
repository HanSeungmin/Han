using UnityEngine;
using System.Collections;

public class maingame : MonoBehaviour {

    public static int BestLevel = 0;
    public static float GameSpeed = 60.0f;
    public static int BestBounce = 0;
    public int pBestBounce; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        pBestBounce = BestBounce;
    }
}
