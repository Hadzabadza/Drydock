using UnityEngine;
using System.Collections;

public class asteroid_spawn : MonoBehaviour {
    private int side;
    private int type;
    public int level;
    private float spawnTimer;
	public float delay;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject asteroid4;
    public GameObject target;
    public GameObject Player;
	public GameObject main;
    public bool active;

   // public GameObject Shield;
    public GameObject player;
    // Use this for initialization
    void Start () {
		//Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, -10.0f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 up = new Vector2(Random.Range(transform.position.x -Camera.main.orthographicSize * Camera.main.aspect, transform.position.x +Camera.main.orthographicSize * Camera.main.aspect), transform.position.y +Camera.main.orthographicSize);
		Vector2 down = new Vector2(Random.Range(transform.position.x -Camera.main.orthographicSize * Camera.main.aspect, transform.position.x +Camera.main.orthographicSize * Camera.main.aspect), transform.position.y -Camera.main.orthographicSize);
		Vector2 left = new Vector2(transform.position.x -Camera.main.orthographicSize * Camera.main.aspect, Random.Range(transform.position.y -Camera.main.orthographicSize, transform.position.y + Camera.main.orthographicSize));
		Vector2 right = new Vector2(transform.position.x + Camera.main.orthographicSize * Camera.main.aspect, Random.Range(transform.position.y -Camera.main.orthographicSize, transform.position.y + Camera.main.orthographicSize));
        spawnTimer++;
		delay++;
		if (delay > 60)
        if (active)
		if (spawnTimer > 35+35/level)
        {
			spawnTimer = Random.Range (0, 5+level/2);;
            side = Random.Range(0, 4);
            type = Random.Range(0, 4);
            if (type == 0)
            {
                if (side == 0)
                {
                    GameObject newAster = Instantiate(asteroid1, up, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.transform;
                    newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 1)
                {
                    GameObject newAster = Instantiate(asteroid1, down, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 2)
                {
                    GameObject newAster = Instantiate(asteroid1, left, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 3)
                {
                    GameObject newAster = Instantiate(asteroid1, right, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
            }
            if (type == 1)
            {
                if (side == 0)
                {
                    GameObject newAster = Instantiate(asteroid2, up, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 1)
                {
                    GameObject newAster = Instantiate(asteroid2, down, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 2)
                {
                    GameObject newAster = Instantiate(asteroid2, left, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 3)
                {
                    GameObject newAster = Instantiate(asteroid2, right, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;

                    }
            }
            if (type == 2)
            {
                if (side == 0)
                {
                    GameObject newAster = Instantiate(asteroid3, up, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 1)
                {
                    GameObject newAster = Instantiate(asteroid3, down, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 2)
                {
                    GameObject newAster = Instantiate(asteroid3, left, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 3)
                {
                    GameObject newAster = Instantiate(asteroid3, right, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
            }
            if (type == 3)
            {
                if (side == 0)
                {
                    GameObject newAster = Instantiate(asteroid4, up, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 1)
                {
                    GameObject newAster = Instantiate(asteroid4, down, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 2)
                {
                    GameObject newAster = Instantiate(asteroid4, left, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
                if (side == 3)
                {
                    GameObject newAster = Instantiate(asteroid4, right, transform.rotation) as GameObject;
                    newAster.GetComponent<asteroid_movement>().target = player.GetComponent<Transform>();
                        newAster.GetComponent<asteroid_movement>().spawner = gameObject;
                    }
            }
        }
	}
    void split() {

    }
	void startAsteroids()
	{
		delay = 0;
		spawnTimer = 0;
		player = Instantiate(Player, transform.position, gameObject.GetComponent<Transform>().rotation) as GameObject;
		player.GetComponent<movement>().spawner = gameObject;
	}
}
