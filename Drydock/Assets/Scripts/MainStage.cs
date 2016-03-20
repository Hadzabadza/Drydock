using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainStage : MonoBehaviour
{
	public int level;
	public GameObject card;
	public GameObject miniGameArea;
	public GameObject PartBlueprint;

	public bool zoom;
	public bool zoomOut;
	public bool mGInProgress;
	public float zoomSpeed;
	public Vector2 camSpeed;
	public Vector3 camFocus;
	public GameObject TT;
	public GameObject mGAreaRef;
	public List<GameObject> parts = new List<GameObject> ();
	public Canvas canv;
	public Vector2 shipPos;

	public int[] deck;
	public int[] deckLayout;
	public int cardAmount;
	public GameObject[] events;

	// Use this for initialization
	void Start ()
	{
		deck = new int[9];
		newDeck ();
		mGAreaRef = Instantiate (miniGameArea, new Vector3 (-50, 0, 0), transform.rotation)as GameObject;
		mGAreaRef.GetComponent<asteroid_spawn> ().main = gameObject;
		parts.Add( Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
		(parts [0]).GetComponent<Part> ().type = 0;
		(parts [0]).GetComponent<Part> ().num = 0;
		(parts [0]).GetComponent<Part> ().canv =canv;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!mGInProgress) {
			if (Input.GetMouseButton (1)) {
				if (!zoom) {
					if (!zoomOut) {
						zoomSpeed = 0.0f;
						if (Camera.main.GetComponent<Camera> ().orthographicSize >9) {
							if (zoomOut)
								zoomOut = false;
							zoom = true;
						} else {
							if (Camera.main.GetComponent<Camera> ().orthographicSize < 4)
							if (zoom)
								zoom = false;
								zoomOut = true;
						}
					}
				}
			}
			if (Input.GetMouseButton (2)) {
				Vector3 conv = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				camFocus.x = conv.x;
				camFocus.y = conv.y;
			}
		}
		if (zoom) {
			zoomSpeed += 0.004f;
			if (Camera.main.GetComponent<Camera> ().orthographicSize - zoomSpeed > 3) {
				Camera.main.GetComponent<Camera> ().orthographicSize -= zoomSpeed;
			} else {
				Camera.main.GetComponent<Camera> ().orthographicSize = 3;
				zoom = false;
			}
		}
		if (zoomOut) {
			zoomSpeed += 0.004f;
			if (Camera.main.GetComponent<Camera> ().orthographicSize + zoomSpeed < 10) {
				Camera.main.GetComponent<Camera> ().orthographicSize += zoomSpeed;
			} else {
				Camera.main.GetComponent<Camera> ().orthographicSize = 10;
				zoomOut = false;
			}
		}


		if (camFocus.x < Camera.main.GetComponent<Transform> ().position.x - camSpeed.x) {
			camSpeed.x += 0.01f;
			Camera.main.GetComponent<Transform> ().position = new Vector3 (Camera.main.GetComponent<Transform> ().position.x - camSpeed.x, Camera.main.GetComponent<Transform> ().position.y, Camera.main.GetComponent<Transform> ().position.z);
		} else {
			if (camFocus.x > Camera.main.GetComponent<Transform> ().position.x + camSpeed.x) {
				camSpeed.x += 0.01f;
				Camera.main.GetComponent<Transform> ().position = new Vector3 (Camera.main.GetComponent<Transform> ().position.x + camSpeed.x, Camera.main.GetComponent<Transform> ().position.y, Camera.main.GetComponent<Transform> ().position.z);
			} else {
				Camera.main.GetComponent<Transform> ().position = new Vector3 (camFocus.x, Camera.main.GetComponent<Transform> ().position.y, Camera.main.GetComponent<Transform> ().position.z);
				camSpeed.x = 0;
			}
		}
		if (camFocus.y < Camera.main.GetComponent<Transform> ().position.y - camSpeed.y) {
			camSpeed.y += 0.01f;
			Camera.main.GetComponent<Transform> ().position = new Vector3 (Camera.main.GetComponent<Transform> ().position.x, Camera.main.GetComponent<Transform> ().position.y - camSpeed.y, Camera.main.GetComponent<Transform> ().position.z);
		} else {
			if (camFocus.y > Camera.main.GetComponent<Transform> ().position.y + camSpeed.y) {
				camSpeed.y += 0.01f;
				Camera.main.GetComponent<Transform> ().position = new Vector3 (Camera.main.GetComponent<Transform> ().position.x, Camera.main.GetComponent<Transform> ().position.y + camSpeed.y, Camera.main.GetComponent<Transform> ().position.z);
			} else {
				Camera.main.GetComponent<Transform> ().position = new Vector3 (Camera.main.GetComponent<Transform> ().position.x, camFocus.y, Camera.main.GetComponent<Transform> ().position.z);
				camSpeed.y = 0;
			}	
		}
	}

	void newDeck ()
	{
		deck [0] = 1;
		deck [1] = 1;
		level++;
		cardAmount = (2 + level / 2 + (level % 2)) * (3 + (level / 2)) - 2;
		events = new GameObject[cardAmount+2];
		int layoutNumber = 0;
		for (int i = 0; i < cardAmount; i++) {
			if (layoutNumber < deckLayout.Length - 1) {
				layoutNumber++;
			} else {
				layoutNumber = 0;
			}
			deck [deckLayout [layoutNumber]]++;
		}
		int newCards = 0;
		for (int i = 0; i < 2 + (level / 2 + level % 2); i++) {
			for (int j = 0; j < 3 + (level / 2); j++) {
				newCards++;
				GameObject newCard = Instantiate (card, new Vector3 (-1.5f * (2.0f + level % 2) + i * 3.0f, -2.25f * (3.0f + level / 2) + j * 4.5f, 0.0f), gameObject.gameObject.GetComponent<Transform> ().rotation) as GameObject;
				newCard.GetComponent<CardBack> ().main = gameObject;
				newCard.GetComponent<CardBack> ().TT = TT;
				events [newCards-1] = newCard;
				bool drawn = false;
				while (!drawn) {
					int currentCardType = Mathf.RoundToInt (Random.Range (-0.4f, deck.Length - 1 + 0.4f));
					if (deck [currentCardType] > 0) {
						newCard.GetComponent<CardBack> ().type = currentCardType;
						deck [currentCardType]--;
						drawn = true;
					}
				}
			}
		}
	}
}
