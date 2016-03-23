using UnityEngine;
using System.Collections;

public class asteroid_movement : MonoBehaviour {
    private Rigidbody2D rb2d;
    public Transform target;
    private float range;
    private float rotate;
    private float force = 200.0f;
    private Vector2 aim;
    public GameObject spawner;
	public bool peaceful;
	public Sprite harmless;

	// Use this for initialization
	void Start () {
		gameObject.transform.SetParent (spawner.transform);
        rb2d = GetComponent<Rigidbody2D>();
        range = Random.Range(-1, 1);
        rotate = Random.Range(-3, 3);
        if (rotate < 1 && rotate >= 0) {
            rotate = 1;
        }
        if (rotate >= -1 && rotate < 0) {
            rotate = -1;
        }
        
		if (target != null) {
			aim = (target.position - transform.position);
			aim.x += range;
			aim.y += range;
			rb2d.AddForce (aim * force);
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotate));
		if (transform.position.x < spawner.transform.position.x -Camera.main.orthographicSize * Camera.main.aspect*1.5 || transform.position.x > spawner.transform.position.x +Camera.main.orthographicSize * Camera.main.aspect*1.5 || transform.position.y < spawner.transform.position.y -Camera.main.orthographicSize*1.5 || transform.position.y > spawner.transform.position.y +Camera.main.orthographicSize*1.5) {
            Destroy(gameObject);
        }
		if (peaceful) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = harmless;
		}
    }

	void end()
	{
		Destroy (gameObject);
	}
}
