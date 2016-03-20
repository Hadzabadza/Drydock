using UnityEngine;
using System.Collections;

public class ShieldImpact : MonoBehaviour {

	public float lifeTime;

	// Use this for initialization
	void Start () {
		lifeTime = 255;
		gameObject.GetComponent<Rigidbody2D> ().AddForce( new Vector2 (500 * Mathf.Cos (Mathf.Deg2Rad *transform.rotation.eulerAngles.z), 500 * Mathf.Sin (Mathf.Deg2Rad * transform.rotation.eulerAngles.z)));
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime-=5;
		if (lifeTime > 0) {
			transform.localScale = new Vector3 (6.5f - 5 * lifeTime / 255, 10 - 10 * lifeTime / 255);
			gameObject.GetComponent<SpriteRenderer> ().color = new Vector4 (1, lifeTime / 255, lifeTime / 255, lifeTime / 255);
		} else {
			Destroy (gameObject);
		}
	}
}
