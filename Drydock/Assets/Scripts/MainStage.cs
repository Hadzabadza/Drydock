using UnityEngine;
using System.Collections;

public class MainStage : MonoBehaviour
{
	public int level;
	public GameObject card;
	public bool zoom;
	public bool zoomOut;
	public float zoomSpeed;
	public Vector2 camSpeed;
	public Vector3 camFocus;
	public GameObject TT;

	// Use this for initialization
	void Start ()
	{
		//level = 8;
		for (int i = 0; i < 2 + (level / 2 + level % 2); i++) {
			for (int j = 0; j < 3 + (level / 2); j++) {
				GameObject newCard = Instantiate (card, new Vector3 (-1.5f * (2.0f + level % 2) + i * 3.0f, -2.25f * (3.0f + level / 2) + j * 4.5f, 0.0f), gameObject.gameObject.GetComponent<Transform> ().rotation) as GameObject;
				newCard.GetComponent<CardBack> ().main = gameObject;
				newCard.GetComponent<CardBack> ().TT = TT;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (1)) {
			if (!zoom) {
				if (!zoomOut) {
					zoomSpeed = 0.0f;
				}
				zoomOut = true;
			}
		}

		if (Input.GetMouseButton(2)) {
			Vector3 conv = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			camFocus.x = conv.x;
			camFocus.y = conv.y;
		}

		if (zoom) {
			zoomSpeed += 0.004f;
			if (Camera.main.GetComponent<Camera> ().orthographicSize - zoomSpeed > 2) {
				Camera.main.GetComponent<Camera> ().orthographicSize -= zoomSpeed;
			} else {
				Camera.main.GetComponent<Camera> ().orthographicSize = 2;
				zoom = false;
			}
		}
		if (zoomOut) {
			zoomSpeed += 0.004f;
			if (Camera.main.GetComponent<Camera> ().orthographicSize + zoomSpeed < 9) {
				Camera.main.GetComponent<Camera> ().orthographicSize += zoomSpeed;
			} else {
				Camera.main.GetComponent<Camera> ().orthographicSize = 9;
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
}
