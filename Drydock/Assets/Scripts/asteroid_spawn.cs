using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class asteroid_spawn : MonoBehaviour
{
	private int side;
	private int type;
	public int level;
	public int gameType;
	private float spawnTimer;
	public float delay;
	public GameObject asteroid1;
	public GameObject asteroid2;
	public GameObject asteroid3;
	public GameObject asteroid4;
	public GameObject target;
	public GameObject Player;
	public GameObject Bandit;
	public GameObject main;
	public GameObject newAster;
	public GameObject countdown;
	public GameObject controls;
	public bool active;
	public float escapeTime;
	public float timer;
	public bool hadHint;

	// public GameObject Shield;
	public GameObject player;
	// Use this for initialization
	void Start ()
	{
		//Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, -10.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (main.GetComponent<MainStage> ().mGInProgress) {
			if (gameType == 0) {
				Vector2 up = new Vector2 (Random.Range (transform.position.x - Camera.main.orthographicSize * Camera.main.aspect * 1.3f, transform.position.x + Camera.main.orthographicSize * Camera.main.aspect * 1.3f), transform.position.y + Camera.main.orthographicSize * 1.3f);
				Vector2 down = new Vector2 (Random.Range (transform.position.x - Camera.main.orthographicSize * Camera.main.aspect * 1.3f, transform.position.x + Camera.main.orthographicSize * Camera.main.aspect * 1.3f), transform.position.y - Camera.main.orthographicSize * 1.3f);
				Vector2 left = new Vector2 (transform.position.x - Camera.main.orthographicSize * Camera.main.aspect * 1.3f, Random.Range (transform.position.y - Camera.main.orthographicSize * 1.3f, transform.position.y + Camera.main.orthographicSize * 1.3f));
				Vector2 right = new Vector2 (transform.position.x + Camera.main.orthographicSize * Camera.main.aspect * 1.3f, Random.Range (transform.position.y - Camera.main.orthographicSize * 1.3f, transform.position.y + Camera.main.orthographicSize * 1.3f));
				spawnTimer++;
				delay++;
				timer += Time.deltaTime;
				if (timer < escapeTime) {

					if (delay > 60)
					if (active)
					if (spawnTimer > 35 + 20 / level) {			
						spawnTimer = Random.Range (0, 5 + level / 2);
						;
						side = Random.Range (0, 4);
						type = Random.Range (0, 4);
						if (type == 0) {
							if (side == 0) {
								newAster = Instantiate (asteroid1, up, transform.rotation) as GameObject;
							}
							if (side == 1) {
								newAster = Instantiate (asteroid1, down, transform.rotation) as GameObject;
                    
							}
							if (side == 2) {
								newAster = Instantiate (asteroid1, left, transform.rotation) as GameObject;
                   
							}
							if (side == 3) {
								newAster = Instantiate (asteroid1, right, transform.rotation) as GameObject;
                    
							}
						}
						if (type == 1) {
							if (side == 0) {
								newAster = Instantiate (asteroid2, up, transform.rotation) as GameObject;
                   
							}
							if (side == 1) {
								newAster = Instantiate (asteroid2, down, transform.rotation) as GameObject;
                    
							}
							if (side == 2) {
								newAster = Instantiate (asteroid2, left, transform.rotation) as GameObject;
                    
							}
							if (side == 3) {
								newAster = Instantiate (asteroid2, right, transform.rotation) as GameObject;
                    

							}
						}
						if (type == 2) {
							if (side == 0) {
								newAster = Instantiate (asteroid3, up, transform.rotation) as GameObject;
                    
							}
							if (side == 1) {
								newAster = Instantiate (asteroid3, down, transform.rotation) as GameObject;
                    
							}
							if (side == 2) {
								newAster = Instantiate (asteroid3, left, transform.rotation) as GameObject;
                    
							}
							if (side == 3) {
								newAster = Instantiate (asteroid3, right, transform.rotation) as GameObject;
                    
							}
						}
						if (type == 3) {
							if (side == 0) {
								newAster = Instantiate (asteroid4, up, transform.rotation) as GameObject;
                    
							}
							if (side == 1) {
								newAster = Instantiate (asteroid4, down, transform.rotation) as GameObject;
                    
							}
							if (side == 2) {
								newAster = Instantiate (asteroid4, left, transform.rotation) as GameObject;
                    
							}
							if (side == 3) {
								newAster = Instantiate (asteroid4, right, transform.rotation) as GameObject;                  
							}
						}
						newAster.GetComponent<asteroid_movement> ().target = player.transform;
						newAster.GetComponent<asteroid_movement> ().spawner = gameObject;
						newAster.GetComponent<Rigidbody2D> ().mass = Random.Range (8.0f, 25.0f);
						newAster.transform.localScale = new Vector2 (newAster.GetComponent<Rigidbody2D> ().mass / 10, newAster.GetComponent<Rigidbody2D> ().mass / 10);
					}
					countdown.GetComponent<Text> ().text = "" + Mathf.RoundToInt (escapeTime - timer);
				} else {
					endGame ();
				}
			} 
			if (gameType == 1) {
				timer += Time.deltaTime;
				if (timer < escapeTime) {
					countdown.GetComponent<Text> ().text = "" + Mathf.RoundToInt (escapeTime - timer);
				} else {
					endGame ();
				}
			}
		}
	}

	void split ()
	{

	}

	void startAsteroids ()
	{
		if (hadHint) {
			controls.SetActive (false);
		} else {
			controls.SetActive (true);
			hadHint = true;
		}
		delay = 0;
		spawnTimer = 0;
		timer = 0;
		player = Instantiate (Player, transform.position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
		for (int i = 1; i < main.GetComponent<MainStage> ().parts.Count; i++) {
			Part part = (main.GetComponent<MainStage> ().parts [i]).GetComponent<Part> ();
			if (!part.broken && !part.stunned) {
				if (part.type == 1)
					player.GetComponent<movement> ().shieldCount++;
				if (part.type == 2)
					player.GetComponent<movement> ().gunCount++;
				if (part.type == 3)
					player.GetComponent<movement> ().thrusterCount++;
			}
		}
		player.GetComponent<movement> ().spawner = gameObject;
		escapeTime = Mathf.RoundToInt (Random.Range (15.0f, 30.0f)) + level - player.GetComponent<movement> ().thrusterCount;
		countdown.gameObject.SetActive (true);
		player.SendMessage ("begin");
	}

	void startBandits ()
	{
		if (hadHint) {
			controls.SetActive (false);
		} else {
			controls.SetActive (true);
			hadHint = true;
		}
		timer = 0;
		GameObject bandit = null;
		player = Instantiate (Player, new Vector2(transform.position.x+Camera.main.orthographicSize/2,transform.position.y), gameObject.GetComponent<Transform> ().rotation) as GameObject;
		for (int i = 1; i < main.GetComponent<MainStage> ().parts.Count; i++) {
			Part part = (main.GetComponent<MainStage> ().parts [i]).GetComponent<Part> ();
			if (!part.broken && !part.stunned) {
				if (part.type == 1)
					player.GetComponent<movement> ().shieldCount++;
				if (part.type == 2)
					player.GetComponent<movement> ().gunCount++;
				if (part.type == 3)
					player.GetComponent<movement> ().thrusterCount++;
			}
		}
		player.GetComponent<movement> ().spawner = gameObject;
		escapeTime = Mathf.RoundToInt (Random.Range (15.0f, 25.0f)) + level * 2 - player.GetComponent<movement> ().thrusterCount * 2;
		countdown.gameObject.SetActive (true);
		player.SendMessage ("begin");
		for (int i = 0; i < level; i++) {
			Vector2 pos = new Vector2 (transform.position.x + Random.Range (-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect), transform.position.y + Random.Range (-Camera.main.orthographicSize, Camera.main.orthographicSize));
			bandit = Instantiate (Bandit, pos, Quaternion.identity) as GameObject;
			bandit.GetComponent<bandit_movement> ().target = player;
			bandit.transform.SetParent (gameObject.transform);
		}
	}

	void startAmbush ()
	{
		if (hadHint) {
			controls.SetActive (false);
		} else {
			controls.SetActive (true);
			hadHint = true;
		}
		timer = 0;
		GameObject bandit = null;
		player = Instantiate (Player, new Vector2(transform.position.x+Camera.main.orthographicSize/2*Camera.main.aspect,transform.position.y), gameObject.GetComponent<Transform> ().rotation) as GameObject;
		for (int i = 1; i < main.GetComponent<MainStage> ().parts.Count; i++) {
			Part part = (main.GetComponent<MainStage> ().parts [i]).GetComponent<Part> ();
			if (!part.broken && !part.stunned) {
				if (part.type == 1)
					player.GetComponent<movement> ().shieldCount++;
				if (part.type == 2)
					player.GetComponent<movement> ().gunCount++;
				if (part.type == 3)
					player.GetComponent<movement> ().thrusterCount++;
			}
		}
		player.GetComponent<movement> ().spawner = gameObject;
		escapeTime = Mathf.RoundToInt (Random.Range (20.0f, 28.0f)) + level * 2 - player.GetComponent<movement> ().thrusterCount * 2;
		countdown.gameObject.SetActive (true);
		player.SendMessage ("begin");
		for (int i = 0; i < level * 1.5; i++) {
			Vector2 pos = new Vector2 (transform.position.x - Camera.main.orthographicSize * Camera.main.aspect/2+(Camera.main.orthographicSize*Mathf.Cos(Mathf.Deg2Rad*(360.0f*(i/(level*1.5f))))), transform.position.y +(Camera.main.orthographicSize*Mathf.Sin(Mathf.Deg2Rad*(360.0f*(i/(level*1.5f))))));
			bandit = Instantiate (Bandit, pos, Quaternion.identity) as GameObject;
			bandit.GetComponent<bandit_movement> ().target = player;
			bandit.transform.LookAt (player.transform.position);
			bandit.transform.SetParent (gameObject.transform);
			//transform.Rotate (0, -90, 0);
		}
	}

	void endGame ()
	{
		countdown.gameObject.SetActive (false);
		main.GetComponent<MainStage> ().mGInProgress = false;
		main.GetComponent<MainStage> ().currentCard.tag = "RESOLVED";
		BroadcastMessage ("end");
		main.GetComponent<MainStage> ().SendMessage ("focusCurrent");
		if (main.GetComponent<MainStage> ().stunTime > 0)
			main.GetComponent<MainStage> ().stunTime--;
		controls.SetActive (false);
	}
}
