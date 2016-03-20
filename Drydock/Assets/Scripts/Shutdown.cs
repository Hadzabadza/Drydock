using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shutdown : MonoBehaviour {
	public Sprite onState;
	public Sprite offState;
	public bool on;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
			gameObject.GetComponent<Image> ().sprite = onState;
		}
		else
		{
			gameObject.GetComponent<Image> ().sprite = offState;
		}
	}
}
