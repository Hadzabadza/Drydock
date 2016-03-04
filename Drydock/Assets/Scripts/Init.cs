using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	public Transform CardBack;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 4; j++) {
				Instantiate (CardBack, new Vector3 (i * 3.0F - 3.0F, j*4.5F-4.5F, 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
