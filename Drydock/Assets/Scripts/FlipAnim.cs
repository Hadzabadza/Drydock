using UnityEngine;
using System.Collections;

public class FlipAnim : MonoBehaviour {
	public float flipAngle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (flipAngle > 0.0F) {
			if (flipAngle < 1.0F) {
				flipAngle = 0.0F;
			}
			flipAngle--;
		}
		gameObject.GetComponent<Transform>().Rotate(new Vector3(0.0F,flipAngle*Mathf.Deg2Rad,0.0F));
	}
}
