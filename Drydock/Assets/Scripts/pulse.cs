using UnityEngine;
using System.Collections;

public class pulse : MonoBehaviour
{
	public GameObject player;
	public GameObject impact;
	public float distance;
	public float angle;
	public Quaternion rot = Quaternion.identity;
	public string axis = "Horizontal2";
	public string axis2 = "Vertical2";
	public int shieldNumber;
	public float shift;


	// Use this for initialization
	void Start ()
	{
		gameObject.transform.SetParent (player.GetComponent<movement> ().spawner.transform);
		distance = 3;
	}
	
	// Update is called once per frame
	void Update ()
	{
		angle += Input.GetAxisRaw (axis) * 3;
		if ((distance > 2) || (Input.GetAxisRaw (axis2) > 0))
			distance += Input.GetAxisRaw (axis2) / 5;
        
		if (player.GetComponent<movement> ().arc) {
			transform.position = new Vector3 (player.transform.position.x + distance * Mathf.Cos (Mathf.Deg2Rad * (angle + shift)), player.transform.position.y + distance * Mathf.Sin (Mathf.Deg2Rad * (angle + shift)), 0.0f);
			rot.eulerAngles = new Vector3 (0.0f, 0.0f, angle + shift);
		} else {
			transform.position = new Vector3 (player.transform.position.x + distance * Mathf.Cos (Mathf.Deg2Rad * (angle + 360 / player.GetComponent<movement> ().shieldCount * shieldNumber)), player.transform.position.y + distance * Mathf.Sin (Mathf.Deg2Rad * (angle + 360 / player.GetComponent<movement> ().shieldCount * shieldNumber)), 0.0f);
			rot.eulerAngles = new Vector3 (0.0f, 0.0f, angle + 360 / player.GetComponent<movement> ().shieldCount * shieldNumber);
		}
        
		transform.rotation = rot;
		if (shieldNumber >= player.GetComponent<movement> ().shieldCount) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Vector4 (1.0f, 0.2f, 0.2f, 0.0f);
			gameObject.layer = 11;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Vector4 (1.0f, 1.0f, 1.0f, 1.0f);
			gameObject.layer = 8;
		}
		//transform.position += transform.right/10;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Asteroid") {
			Instantiate (impact, transform.position, transform.rotation);
			//gameObject.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity+other.gameObject.GetComponent<Rigidbody2D> ().velocity;
			//other.gameObject.GetComponent<Rigidbody2D>().velocity=other.gameObject.GetComponent<Rigidbody2D>().velocity*(-1);

		}
	}

	void end ()
	{
		Destroy (gameObject);
	}
}

