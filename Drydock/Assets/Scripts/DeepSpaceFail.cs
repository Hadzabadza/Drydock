using UnityEngine;
using System.Collections;

public class DeepSpaceFail : MonoBehaviour {
	public float timer;
	public float showTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= showTime) {
			gameObject.SetActive (false);
		}
	}
	void hide()
	{
		gameObject.SetActive (false);
	}
}
