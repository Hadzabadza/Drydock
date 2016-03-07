using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
	public Transform asteroids;
	public Transform exit;
	public Transform deepSpace;
	public Transform solarFlare;
	public Transform bandits;
	public Transform nebula;
	public Transform trader;
	public Transform shipwreck;
	public int flip;
	private bool flipping;
	private float flipAngle;
   
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flipping) {
			flipAngle++;
			gameObject.GetComponent<Transform> ().Rotate (new Vector3 (0.0F, flipAngle * Mathf.Deg2Rad, 0.0F));
			if (flipAngle >= 100.0F) {
				gameObject.GetComponent<Transform> ().Rotate (new Vector3 (0.0F, 0.0F, 0.0F));
				Flipped ();
			}
		}
	}

	void OnMouseDown ()
	{
		flipping = true;
	}

	void Flipped ()
	{
		
		if (flip == 0) {
			Instantiate (asteroids, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}
		if (flip == 1) {
			Instantiate (nebula, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}
		if (flip == 2) {
			Instantiate (solarFlare, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}
		if (flip == 3) {
			Instantiate (shipwreck, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}
		if (flip == 4) {
			Instantiate (bandits, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}
		if (flip == 5) {
			Instantiate (trader, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}
		if (flip == 6) {
			Instantiate (exit, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}
		if (flip == 7) {
			Instantiate (deepSpace, gameObject.GetComponent<Transform> ().position, new Quaternion (0.0F, 0.0F, 0.0F, 0.0F));
		}

		Destroy (gameObject);
	}
}
