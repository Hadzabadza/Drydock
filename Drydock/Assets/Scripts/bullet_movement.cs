using UnityEngine;
using System.Collections;

public class bullet_movement : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float maxSpeed = 10.0f;
    public GameObject spawner;
	GameObject half1;
	GameObject half2;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.right * maxSpeed);
		gameObject.transform.SetParent (spawner.transform);
    }
	
	// Update is called once per frame
	void Update () {
        
		if (transform.position.x < Camera.main.transform.position.x -Camera.main.orthographicSize * Camera.main.aspect*1.5 || transform.position.x > Camera.main.transform.position.x +Camera.main.orthographicSize * Camera.main.aspect*1.5 || transform.position.y < Camera.main.transform.position.y -Camera.main.orthographicSize*1.5 || transform.position.y > Camera.main.transform.position.y +Camera.main.orthographicSize*1.5) {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Asteroid") {
			if (other.gameObject.GetComponent<Rigidbody2D>().mass>9.0f)
			{
				Debug.Log (other.gameObject.GetComponent<Rigidbody2D> ().mass);
				int type = Mathf.RoundToInt (Random.Range (0, 3));
				if (type == 0)
				 half1 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid1, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
				if (type == 1)
					 half1 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid2, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
				if (type == 2)
					 half1 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid3, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
				if (type == 3)
					half1 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid4, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*other.gameObject.transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
				type = Mathf.RoundToInt (Random.Range (0, 3));
				if (type == 0)
					half2 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid1, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
				if (type == 1)
					half2 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid2, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
				if (type == 2)
					half2 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid3, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
				if (type == 3)
					half2 = Instantiate (spawner.GetComponent<asteroid_spawn>().asteroid4, new Vector3 (other.gameObject.transform.position.x+0.5f*Mathf.Cos(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), other.gameObject.transform.position.y+0.5f*Mathf.Sin(Mathf.Deg2Rad*transform.rotation.eulerAngles.z), 0.0f), other.gameObject.transform.rotation) as GameObject;
		

				half1.GetComponent<Rigidbody2D> ().mass = other.gameObject.GetComponent<Rigidbody2D> ().mass * 0.4f;
				half1.transform.localScale = new Vector3 (other.gameObject.transform.localScale.x*0.4f, other.gameObject.transform.localScale.y*0.4f);
				half1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (other.gameObject.GetComponent<Rigidbody2D> ().velocity.y, other.gameObject.GetComponent<Rigidbody2D> ().velocity.x);
				half1.GetComponent<asteroid_movement> ().spawner = spawner;

				half2.transform.localScale = new Vector3 (other.gameObject.transform.localScale.x*0.4f, other.gameObject.transform.localScale.y*0.4f);
				half2.GetComponent<asteroid_movement> ().spawner = spawner;
				half2.GetComponent<Rigidbody2D> ().mass = other.gameObject.GetComponent<Rigidbody2D> ().mass * 0.4f;
				half2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-other.gameObject.GetComponent<Rigidbody2D> ().velocity.y, -other.gameObject.GetComponent<Rigidbody2D> ().velocity.x);
			}
            Destroy(other.gameObject);
			Destroy(gameObject);
        }
		if (other.tag == "Enemy") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
    }

	void end()
	{
		Destroy (gameObject);
	}
}
