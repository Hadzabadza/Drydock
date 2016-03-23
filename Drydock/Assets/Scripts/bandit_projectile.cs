using UnityEngine;
using System.Collections;

public class bandit_projectile : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float maxSpeed;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
		rb2d.AddForce(transform.right * maxSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.x > GetComponentInParent<Transform>().position.x+Camera.main.orthographicSize*Camera.main.aspect || Camera.main.transform.position.x < GetComponentInParent<Transform>().position.x-Camera.main.orthographicSize*Camera.main.aspect || Camera.main.transform.position.y > GetComponentInParent<Transform>().position.y+Camera.main.orthographicSize || Camera.main.transform.position.y < GetComponentInParent<Transform>().position.y-Camera.main.orthographicSize) {
            Destroy(this.gameObject);
        }
    }

	void end()
	{
		Destroy (gameObject);
	}
    
}
