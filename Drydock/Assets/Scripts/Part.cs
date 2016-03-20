using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Part : MonoBehaviour
{
	public int type;
	public GameObject core;
	public GameObject shield;
	public GameObject cannon;
	public GameObject thruster;
	public GameObject cargoBay;
	public GameObject warp;
	public Canvas canv;

	public GameObject hp;
	public GameObject sp;

	public int hpMax;
	public int hpCurrent;
	public int spMax;
	public int spCurrent;
	public int num;
	public bool shipwrecked;
	public bool golden;

	List<GameObject> health = new List<GameObject> ();
	List<GameObject> shields = new List<GameObject> ();
	// Use this for initialization
	void Start ()
	{
		if (type == 0) {
			hpMax = 10;
			hpCurrent = hpMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			GameObject image = Instantiate (core, pos, transform.rotation) as GameObject;
			image.transform.SetParent (canv.transform);
			for (int i = 0; i < hpMax; i++) {
				pos = transform.position;
				pos.x = 30.0f + 60 * num;
				pos.y = 76.0f + 40 * i;
				health.Add (Instantiate (hp, pos, transform.rotation) as GameObject);
				(health [i]).transform.SetParent (canv.transform);
				//(health [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
				(health [i]).GetComponent<RectTransform> ().position = pos;
			}
		}
		if (type == 1) {
			hpMax = 2;
			hpCurrent = hpMax;
			spMax = 2;
			spCurrent = spMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			GameObject image = Instantiate (shield, pos, transform.rotation) as GameObject;
			image.transform.SetParent (canv.transform);
			for (int i = 0; i < hpMax; i++) {
				pos = transform.position;
				pos.x = 30.0f + 60 * num;
				pos.y = 80.0f + 40 * i;
				health.Add (Instantiate (hp, pos, transform.rotation) as GameObject);
				(health [i]).transform.SetParent (canv.transform);
				//(health [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
				(health [i]).GetComponent<RectTransform> ().position = pos;
			}
			for (int i = 0; i < spMax; i++) {
				pos = transform.position;
				pos.x = 30.0f + 60 * num;
				pos.y = 80.0f + 40 * i + 40 * hpMax;
				shields.Add (Instantiate (sp, pos, transform.rotation) as GameObject);
				(shields [i]).transform.SetParent (canv.transform);
				//(health [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
				(shields [i]).GetComponent<RectTransform> ().position = pos;
			}
		}
		if (type == 2) {
			hpMax = 2;
			hpCurrent = hpMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			GameObject image = Instantiate (cannon, pos, transform.rotation) as GameObject;
			image.transform.SetParent (canv.transform);
			for (int i = 0; i < hpMax; i++) {
				pos = transform.position;
				pos.x = 30.0f + 60 * num;
				pos.y = 76.0f + 40 * i;
				health.Add (Instantiate (hp, pos, transform.rotation) as GameObject);
				(health [i]).transform.SetParent (canv.transform);
				//(health [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
				(health [i]).GetComponent<RectTransform> ().position = pos;
			}
		}
		if (type == 3) {
			hpMax = 2;
			hpCurrent = hpMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			GameObject image = Instantiate (thruster, pos, transform.rotation) as GameObject;
			image.transform.SetParent (canv.transform);
			for (int i = 0; i < hpMax; i++) {
				pos = transform.position;
				pos.x = 30.0f + 60 * num;
				pos.y = 76.0f + 40 * i;
				health.Add (Instantiate (hp, pos, transform.rotation) as GameObject);
				(health [i]).transform.SetParent (canv.transform);
				//(health [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
				(health [i]).GetComponent<RectTransform> ().position = pos;
			}
		}
		if (type == 4) {
			hpMax = 3;
			hpCurrent = hpMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			GameObject image = Instantiate (cargoBay, pos, transform.rotation) as GameObject;
			image.transform.SetParent (canv.transform);
			for (int i = 0; i < hpMax; i++) {
				pos = transform.position;
				pos.x = 30.0f + 60 * num;
				pos.y = 76.0f + 40 * i;
				health.Add (Instantiate (hp, pos, transform.rotation) as GameObject);
				(health [i]).transform.SetParent (canv.transform);
				//(health [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
				(health [i]).GetComponent<RectTransform> ().position = pos;
			}
		}
		if (type == 5) {
			hpMax = 1;
			hpCurrent = hpMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			GameObject image = Instantiate (warp, pos, transform.rotation) as GameObject;
			image.transform.SetParent (canv.transform);
			for (int i = 0; i < hpMax; i++) {
				pos = transform.position;
				pos.x = 30.0f + 60 * num;
				pos.y = 76.0f + 40 * i;
				health.Add (Instantiate (hp, pos, transform.rotation) as GameObject);
				(health [i]).transform.SetParent (canv.transform);
				//(health [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
				(health [i]).GetComponent<RectTransform> ().position = pos;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hpCurrent <= hpMax) {
			for (int i = 0; i < hpCurrent; i++) {
				(health [i]).GetComponent<Shutdown> ().on = true;
			}
			for (int i = hpCurrent; i < hpMax; i++) {
				(health [i]).GetComponent<Shutdown> ().on = false;
			}
		}
		if (hpCurrent == 0)
			spCurrent = 0;
		if (spCurrent <= spMax) {
			for (int i = 0; i < spCurrent; i++) {
				(shields [i]).GetComponent<Shutdown> ().on = true;
			}
			for (int i = spCurrent; i < spMax; i++) {
				(shields [i]).GetComponent<Shutdown> ().on = false;
			}
		}						
	}
}

