using UnityEngine;
using System.Collections;

public class ItemEquip : MonoBehaviour {

    public GameObject ItemPrefeb;

    GameObject Item;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Item)
            {
                Item = Instantiate(ItemPrefeb);
            }
            else if (Item)
            {
                Destroy(Item);
            }
        }
	
	}
}
