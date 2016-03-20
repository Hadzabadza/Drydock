using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tooltip : MonoBehaviour
{
	public float alpha;
	public Image back;
	// Use this for initialization
	void Start ()
	{
		//gameObject.GetComponent<T
		//gameObject.GetComponent<RectTransform> ().position = new Vector3 (Screen.width-120, Screen.height/2, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		if (Input.mousePosition.x < Screen.width/2) {
			gameObject.GetComponent<RectTransform> ().position = new Vector3 (Screen.width-120, Screen.height/2, 0);
		} else {
			gameObject.GetComponent<RectTransform> ().position = new Vector3 (120, Screen.height/2, 0);
		}
		*/
		if (alpha > 0) {
			alpha -= 0.02f;
		}
		if (alpha > 0.9f)
			alpha = 0.9f;
		gameObject.GetComponent<Text> ().color = new Vector4 (1, 1, 1, alpha);
		back.GetComponent<Image> ().color = new Vector4 (1, 1, 1, alpha);
	}
}
