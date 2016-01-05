using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    bool ismove = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ismove = true;
        }
    }

    void FixedUpdate()
    {
        if (ismove)
        {
            move();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Vector3 incommingVec = this.transform.forward;
        Vector3 NomalVec = col.contacts[0].normal;
        this.transform.forward = Vector3.Reflect(incommingVec, NomalVec).normalized;
        col.gameObject.GetComponent<objLife>().objectLife--;
    }

    void move()
    {
        this.transform.Translate(0, 0, 1 * Time.deltaTime * 8.0f);
    }
}
