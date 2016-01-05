using UnityEngine;
using System.Collections;

public class PickColor : MonoBehaviour {
	public Color picColor;
	public Material Mat;

	public void setColor(GameObject button)
	{
		picColor = button.GetComponent<UIButtonColor>().defaultColor;
		Mat.color = picColor;
	}

}
