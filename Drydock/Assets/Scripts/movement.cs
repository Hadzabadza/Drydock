using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float maxSpeed = 2.0f;
	public float rotation = 5.0f;
	public int damageTaken;
	public string axis = "Vertical";
	public GameObject pulse;
	private Vector3 location;
	private float theta;
	private float pause;
	public int shieldCount;
	public int gunCount;
	public int thrusterCount;
	public GameObject Shield;
	public GameObject spawner;
	public bool arc;
	private Vector3 temp;

	// Use this for initialization
	void Start ()
	{
		maxSpeed = 2.0f + thrusterCount;
		rb2d = GetComponent<Rigidbody2D> ();
		theta = 0;
		for (int i = 0; i < shieldCount; i++) {
			GameObject shield = Instantiate (Shield, transform.position, transform.rotation) as GameObject;
			shield.GetComponent<pulse> ().player = transform;
			if (arc)
				shield.GetComponent<pulse> ().shift = i * 25;
			else
				shield.GetComponent<pulse> ().shift = i * 360 / shieldCount;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float horizontal = -Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxisRaw (axis);
		float shoot = Input.GetAxis ("Fire1");
		Vector2 pos = new Vector2 (horizontal, vertical);
		rb2d.AddForce (transform.right * vertical * maxSpeed);
		rb2d.AddTorque (horizontal * rotation);
		theta += (horizontal / 10);
		location = transform.position + transform.right;
		//location.x = transform.position.x + 3 * Mathf.Cos(theta);
		//location.y = transform.position.y + 3 * Mathf.Sin(theta);
		if (pause > 0) {
			pause--;
		}
		if (shoot == 1 && pause <= 0 && gunCount>0) {
			Instantiate (pulse, location, transform.rotation);
			pause = 50 / gunCount;
		}
		temp = transform.position;

		if (temp.x < spawner.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect) {
			temp.x = spawner.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
		}
		if (temp.x > spawner.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect) {
			temp.x = spawner.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
		}
		if (temp.y < spawner.transform.position.y - Camera.main.orthographicSize) {
			temp.y = spawner.transform.position.y+ Camera.main.orthographicSize;
		}
		if (temp.y > spawner.transform.position.y + Camera.main.orthographicSize) {
			temp.y = spawner.transform.position.y - Camera.main.orthographicSize;
		}
		transform.position = temp;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Asteroid"&&!other.gameObject.GetComponent<asteroid_movement> ().peaceful) {
			damageComponent ();
			other.gameObject.GetComponent<asteroid_movement> ().peaceful = true;
			//gameObject.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity+other.gameObject.GetComponent<Rigidbody2D> ().velocity;
			//other.gameObject.GetComponent<Rigidbody2D>().velocity=other.gameObject.GetComponent<Rigidbody2D>().velocity*(-1);

		}
	}
	void damageComponent()
	{
		bool damaged=false;
		while (!damaged)
		{
			GameObject chosen = spawner.GetComponent<asteroid_spawn> ().main.GetComponent<MainStage> ().parts [Mathf.RoundToInt(Random.Range (-0.4f, spawner.GetComponent<asteroid_spawn> ().main.GetComponent<MainStage> ().parts.Count - 1))];
			if (chosen.GetComponent<Part> ().hpCurrent > 0) {
				chosen.GetComponent<Part> ().hpCurrent--;
			}
			damaged = true;
		}
	}
}
