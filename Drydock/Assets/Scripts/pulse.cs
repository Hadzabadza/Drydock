using UnityEngine;
using System.Collections;

public class pulse : MonoBehaviour {
    public Transform player;
	public GameObject impact;
    public float distance;
    public float angle;
    public Quaternion rot = Quaternion.identity;
    public string axis = "Horizontal2";
    public string axis2 = "Vertical2";
    public float shift;


    // Use this for initialization
    void Start () {
        distance = 3;
	}
	
	// Update is called once per frame
	void Update () {
        angle += Input.GetAxisRaw(axis)*3;
        if ((distance>2)||(Input.GetAxisRaw(axis2)>0))
        distance += Input.GetAxisRaw(axis2)/5;
        transform.position = new Vector3(player.position.x + distance * Mathf.Cos(Mathf.Deg2Rad* (angle+ shift)), player.position.y + distance * Mathf.Sin(Mathf.Deg2Rad * (angle+shift)), 0.0f);
        rot.eulerAngles = new Vector3(0.0f,0.0f,angle+shift);
        transform.rotation = rot;
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
	}

