using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainStage : MonoBehaviour
{
	public int level;
	public GameObject card;
	public GameObject miniGameArea;
	public GameObject PartBlueprint;
	public GameObject ship;

	public bool zoom;
	public bool zoomOut;
	public bool mGInProgress;
	public bool interfaceLock;
	public float zoomSpeed;
	public Vector2 camSpeed;
	public Vector3 camFocus;
	public GameObject TT;
	public GameObject mGAreaRef;
	public GameObject countdown;
	public GameObject resCount;
	public GameObject currentCard;
	public GameObject exitUI;
	public GameObject lossUI;
	public GameObject shipwreckUI;
	public GameObject solarFlareUI;
	public GameObject traderUI;
	public GameObject nebulaUI;
	public GameObject repairUI;
	public GameObject deepSpaceUI;
	public GameObject controls;
	public bool debug;
	public List<GameObject> parts = new List<GameObject> ();
	public Canvas canv;
	public Canvas drydock;
	public int resources;
	public int stunTime;
	public float angle;
	public Quaternion rot = Quaternion.identity;

	public int[] deck;
	public int[] deckLayout;
	public int cardAmount;
	public int width = 0;
	public GameObject[] events;

	// Use this for initialization
	void Start ()
	{
		deck = new int[9];
		//newDeck ();
		mGAreaRef = Instantiate (miniGameArea, new Vector3 (-50, 0, 0), transform.rotation)as GameObject;
		mGAreaRef.GetComponent<asteroid_spawn> ().main = gameObject;
		mGAreaRef.GetComponent<asteroid_spawn> ().countdown = countdown;
		mGAreaRef.GetComponent<asteroid_spawn> ().controls = controls;
		parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
		(parts [0]).GetComponent<Part> ().type = 0;
		(parts [0]).GetComponent<Part> ().num = 0;
		(parts [0]).GetComponent<Part> ().canv = canv;
		(parts [0]).GetComponent<Part> ().spawner = mGAreaRef;
		(parts [0]).GetComponent<Part> ().main = gameObject;
		(parts [0]).transform.SetParent (gameObject.transform);
		canv.transform.SetParent (transform);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
		resCount.GetComponent<Text> ().text = "" + resources;
		if (currentCard != null) {
			ship.SetActive (true);
			ship.transform.position = new Vector3 (currentCard.transform.position.x + 1.4f * Mathf.Cos (Mathf.Deg2Rad * (angle)), currentCard.transform.position.y + 2.0f * Mathf.Sin (Mathf.Deg2Rad * (angle)), 0.0f);
			rot.eulerAngles = new Vector3 (0.0f, 0.0f, angle + 90);
			ship.transform.rotation = rot;
		} else {
			ship.SetActive (false);
		}
		angle += Time.deltaTime * 40;
		if (!mGInProgress) {
			/*if (Input.GetKeyUp ("space")) {
				clearCards ();
				dock ();
			}*/
			if (Input.GetMouseButton (1)) {
				if (!zoom) {
					if (!zoomOut) {
						zoomSpeed = 0.0f;
						if (Camera.main.GetComponent<Camera> ().orthographicSize > 9) {
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
		unlockUI ();
		width = 0;
		level++;
		cardAmount = (2 + level / 2 + (level % 2)) * (3 + (level / 2)) - 2;
		events = new GameObject[cardAmount + 2];
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
				width++;
				newCards++;
				GameObject newCard = Instantiate (card, new Vector3 (-1.5f * (level / 2 + level % 2) + i * 3.0f, -2.25f * (3.0f + level / 2) + j * 4.5f, 0.0f), gameObject.gameObject.GetComponent<Transform> ().rotation) as GameObject;
				newCard.GetComponent<CardBack> ().main = gameObject;
				newCard.GetComponent<CardBack> ().TT = TT;
				newCard.GetComponent<CardBack> ().index = newCards - 1;
				events [newCards - 1] = newCard;
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
		width = width / (2 + (level / 2 + level % 2));
	}

	void clearCards ()
	{
		for (int i = 0; i < events.Length; i++)
			events [i].SendMessage ("removeCard");
	}

	void newShield ()
	{
		int hardParts = 0;
		for (int i = 1; i < parts.Count; i++) {
			if ((parts [i]).GetComponent<Part> ().type != 0 && !(parts [i]).GetComponent<Part> ().golden) {
				hardParts++;
			}
		}
		if (resources > 0 && hardParts < 5) {
			parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
			(parts [parts.Count - 1]).GetComponent<Part> ().type = 1;
			(parts [parts.Count - 1]).GetComponent<Part> ().num = parts.Count - 1;
			(parts [parts.Count - 1]).GetComponent<Part> ().canv = canv;
			(parts [parts.Count - 1]).GetComponent<Part> ().spawner = mGAreaRef;
			(parts [parts.Count - 1]).GetComponent<Part> ().main = gameObject;
			(parts [parts.Count - 1]).transform.SetParent (gameObject.transform);
			resources--;
		}
	}

	void newCannon ()
	{
		int hardParts = 0;
		for (int i = 1; i < parts.Count; i++) {
			if ((parts [i]).GetComponent<Part> ().type != 0 && !(parts [i]).GetComponent<Part> ().golden) {
				hardParts++;
			}
		}
		if (resources > 0 && hardParts < 5) {
			parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
			(parts [parts.Count - 1]).GetComponent<Part> ().type = 2;
			(parts [parts.Count - 1]).GetComponent<Part> ().num = parts.Count - 1;
			(parts [parts.Count - 1]).GetComponent<Part> ().canv = canv;
			(parts [parts.Count - 1]).GetComponent<Part> ().spawner = mGAreaRef;
			(parts [parts.Count - 1]).GetComponent<Part> ().main = gameObject;
			(parts [parts.Count - 1]).transform.SetParent (gameObject.transform);
			resources--;
		}
	}

	void newThruster ()
	{
		int hardParts = 0;
		for (int i = 1; i < parts.Count; i++) {
			if ((parts [i]).GetComponent<Part> ().type != 0 && !(parts [i]).GetComponent<Part> ().golden) {
				hardParts++;
			}
		}
		if (resources > 0 && hardParts < 5) {
			parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
			(parts [parts.Count - 1]).GetComponent<Part> ().type = 3;
			(parts [parts.Count - 1]).GetComponent<Part> ().num = parts.Count - 1;
			(parts [parts.Count - 1]).GetComponent<Part> ().canv = canv;
			(parts [parts.Count - 1]).GetComponent<Part> ().spawner = mGAreaRef;
			(parts [parts.Count - 1]).GetComponent<Part> ().main = gameObject;
			(parts [parts.Count - 1]).transform.SetParent (gameObject.transform);
			resources--;

		}
	}

	void newCargoBay ()
	{
		int hardParts = 0;
		for (int i = 1; i < parts.Count; i++) {
			if ((parts [i]).GetComponent<Part> ().type != 0 && !(parts [i]).GetComponent<Part> ().golden) {
				hardParts++;
			}
		}
		if (resources > 0 && hardParts < 5) {
			parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
			(parts [parts.Count - 1]).GetComponent<Part> ().type = 4;
			(parts [parts.Count - 1]).GetComponent<Part> ().num = parts.Count - 1;
			(parts [parts.Count - 1]).GetComponent<Part> ().canv = canv;
			(parts [parts.Count - 1]).GetComponent<Part> ().spawner = mGAreaRef;
			(parts [parts.Count - 1]).GetComponent<Part> ().main = gameObject;
			(parts [parts.Count - 1]).transform.SetParent (gameObject.transform);
			resources--;
		}
	}

	void newWarpDrive ()
	{
		int hardParts = 0;
		for (int i = 1; i < parts.Count; i++) {
			if ((parts [i]).GetComponent<Part> ().type != 0 && !(parts [i]).GetComponent<Part> ().golden) {
				hardParts++;
			}
		}
		if (resources > 2 && hardParts < 5) {
			parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
			(parts [parts.Count - 1]).GetComponent<Part> ().type = 5;
			(parts [parts.Count - 1]).GetComponent<Part> ().num = parts.Count - 1;
			(parts [parts.Count - 1]).GetComponent<Part> ().canv = canv;
			(parts [parts.Count - 1]).GetComponent<Part> ().spawner = mGAreaRef;
			(parts [parts.Count - 1]).GetComponent<Part> ().main = gameObject;
			(parts [parts.Count - 1]).transform.SetParent (gameObject.transform);
			resources -= 3;
		}
	}

	void newGolden ()
	{
		parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
		(parts [parts.Count - 1]).GetComponent<Part> ().type = Mathf.RoundToInt (Random.Range (0.6f, 3.4f));
		(parts [parts.Count - 1]).GetComponent<Part> ().num = parts.Count - 1;
		(parts [parts.Count - 1]).GetComponent<Part> ().canv = canv;
		(parts [parts.Count - 1]).GetComponent<Part> ().spawner = mGAreaRef;
		(parts [parts.Count - 1]).GetComponent<Part> ().main = gameObject;
		(parts [parts.Count - 1]).GetComponent<Part> ().golden = true;
		(parts [parts.Count - 1]).transform.SetParent (gameObject.transform);
	}

	void newSalvaged (int type)
	{
		parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
		(parts [parts.Count - 1]).GetComponent<Part> ().type = type;
		(parts [parts.Count - 1]).GetComponent<Part> ().num = parts.Count - 1;
		(parts [parts.Count - 1]).GetComponent<Part> ().canv = canv;
		(parts [parts.Count - 1]).GetComponent<Part> ().spawner = mGAreaRef;
		(parts [parts.Count - 1]).GetComponent<Part> ().main = gameObject;
		(parts [parts.Count - 1]).GetComponent<Part> ().salvaged = true;
		(parts [parts.Count - 1]).transform.SetParent (gameObject.transform);
	}

	void closeDock ()
	{
		drydock.gameObject.SetActive (false);
		newDeck ();
		resources++;
	}

	void dock ()
	{
		int golds = 0;
		drydock.gameObject.SetActive (true);
		for (int i = 0; i < 2; i++) {
			if ((parts [0]).GetComponent<Part> ().hpCurrent<(parts [0]).GetComponent<Part> ().hpMax)
			(parts [0]).GetComponent<Part> ().hpCurrent++;
		}

		for (int i = parts.Count - 1; i > 0; i--) {
			if ((parts [i]).GetComponent<Part> ().golden) {
				golds++;
				(parts [i]).GetComponent<Part> ().hpCurrent = (parts [i]).GetComponent<Part> ().hpMax;
				(parts [i]).GetComponent<Part> ().broken = false;
				(parts [i]).GetComponent<Part> ().num = golds;
				(parts [i]).GetComponent<Part> ().SendMessage ("move");
			} else {
				if ((parts [i]).GetComponent<Part> ().type == 4) {
					if ((parts [i]).GetComponent<Part> ().broken) {
						resources += 1;
					}
					(parts [i]).GetComponent<Part> ().SendMessage ("end");

				} else {
					if ((parts [i]).GetComponent<Part> ().type == 5) {
						resources += 2;
					}
					if (!(parts [i]).GetComponent<Part> ().salvaged)
						resources++;
					(parts [i]).GetComponent<Part> ().SendMessage ("end");
				}
			}
		}
	}

	void disableExit ()
	{
		lockUI ();
		exitUI.SetActive (false);
	}

	void focusCurrent ()
	{
		camFocus.x = currentCard.transform.position.x;
		camFocus.y = currentCard.transform.position.y;
	}

	void checkMovement ()
	{
		bool hasWarp = false;
		for (int i = 1; i < parts.Count; i++) {
			Part part = parts [i].GetComponent<Part> ();
			if (part.type == 5 && !part.broken && !part.stunned) {
				hasWarp = true;
			}
		}
		if (hasWarp) {
			for (int i = 0; i < events.Length; i++) {
				if ((events [i].GetComponent ("ActiveCard")as ActiveCard) != null) {
					events [i].GetComponent<ActiveCard> ().allowed = true;
				} else {
					events [i].GetComponent<CardBack> ().allowed = true;
				}
			}
		} else {
			int currIndex = 0;
			if ((currentCard.GetComponent ("ActiveCard")as ActiveCard) != null) {
				currIndex = currentCard.GetComponent<ActiveCard> ().index;
			} else {
				currIndex = currentCard.GetComponent<CardBack> ().index;
			}
			for (int i = 0; i < events.Length; i++) {
				if ((events [i].GetComponent ("ActiveCard")as ActiveCard) != null) {
					events [i].GetComponent<ActiveCard> ().allowed = false;
				} else {
					events [i].GetComponent<CardBack> ().allowed = false;
				}
			}

			if (currIndex + 1 < events.Length) {
				if ((events [currIndex + 1].GetComponent ("ActiveCard")as ActiveCard) != null) {
					if (currentCard.transform.position.x == events [currIndex + 1].transform.position.x)
						events [currIndex + 1].GetComponent<ActiveCard> ().allowed = true;
				} else {
					if (currentCard.transform.position.x == events [currIndex + 1].transform.position.x)
						events [currIndex + 1].GetComponent<CardBack> ().allowed = true;
				}
			}
			if (currIndex > 0) {
				if ((events [currIndex - 1].GetComponent ("ActiveCard")as ActiveCard) != null) {
					if (currentCard.transform.position.x == events [currIndex - 1].transform.position.x)
						events [currIndex - 1].GetComponent<ActiveCard> ().allowed = true;
				} else {
					if (currentCard.transform.position.x == events [currIndex - 1].transform.position.x)
						events [currIndex - 1].GetComponent<CardBack> ().allowed = true;
				}
			}
			if (currIndex + width <= events.Length - 1) {
				if ((events [currIndex + width].GetComponent ("ActiveCard")as ActiveCard) != null) {
					events [currIndex + width].GetComponent<ActiveCard> ().allowed = true;
				} else {
					events [currIndex + width].GetComponent<CardBack> ().allowed = true;
				}
			}
			if (currIndex - width >= 0) {
				if ((events [currIndex - width].GetComponent ("ActiveCard")as ActiveCard) != null) {
					events [currIndex - width].GetComponent<ActiveCard> ().allowed = true;
				} else {
					events [currIndex - width].GetComponent<CardBack> ().allowed = true;
				}
			}
		}
	}

	void lockUI ()
	{
		interfaceLock = true;
	}

	void unlockUI ()
	{
		interfaceLock = false;
	}

	void restart ()
	{
		deck = new int[9];
		resources = 3;
		stunTime = 0;
		parts = new List<GameObject> ();
		parts.Add (Instantiate (PartBlueprint, transform.position, transform.rotation)as GameObject);
		(parts [0]).GetComponent<Part> ().type = 0;
		(parts [0]).GetComponent<Part> ().num = 0;
		(parts [0]).GetComponent<Part> ().canv = canv;
		(parts [0]).GetComponent<Part> ().spawner = mGAreaRef;
		(parts [0]).GetComponent<Part> ().main = gameObject;
		(parts [0]).transform.SetParent (gameObject.transform);
		level = 0;
		clearCards ();
		dock ();
		lossUI.SetActive (false);
	}

	void repairBroken ()
	{
		List < GameObject > repairs = new List<GameObject> ();
		for (int i = 1; i < parts.Count; i++) {
			if ((parts [i]).GetComponent<Part> ().broken) {
				repairs.Add (parts [i]);
			}
		}
		if (repairs.Count > 0) {
			int repPart = Mathf.RoundToInt (Random.Range (-0.4f, repairs.Count - 1));
			(repairs [repPart]).GetComponent<Part> ().hpCurrent++;
			traderUI.SetActive (true);
			traderUI.GetComponent<TraderUI> ().SendMessage ("repaired", (repairs [repPart]).GetComponent<Part> ().type);
		} else {
			traderUI.SetActive (true);
			int ayy = 0;
			traderUI.GetComponent<TraderUI> ().SendMessage ("repaired", ayy);
		}
	}

	void lose ()
	{
		interfaceLock = true;
		lossUI.SetActive (true);
		GetComponent<AudioSource> ().Play();
		BroadcastMessage ("end");
	}

	void restoreShields ()
	{
		for (int i = 0; i < parts.Count; i++) {
			(parts [i]).GetComponent<Part> ().SendMessage ("restoreShield");
		}
	}
}