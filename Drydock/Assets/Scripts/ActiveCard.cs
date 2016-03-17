using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActiveCard : MonoBehaviour {
	public string tooltip;
	public GameObject TT;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	}

	void OnMouseOver(){
		if (TT.GetComponent<Tooltip> ().alpha < 1.0f) {
			TT.GetComponent<Tooltip> ().alpha += 0.04f;
		}
		TT.GetComponent<Text> ().text = tooltip;
	}
}
