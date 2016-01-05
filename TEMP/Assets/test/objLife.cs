using UnityEngine;
using System.Collections;

public class objLife : MonoBehaviour {
    public int objectLife;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.FindChild("life").GetComponent<TextMesh>().text = objectLife.ToString();
        if (objectLife == 0)
        {
            //Destroy(this.gameObject);
        }
    }
}
