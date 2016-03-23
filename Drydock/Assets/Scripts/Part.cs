using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Part : MonoBehaviour
{
	public int type;
	public GameObject core;
	public GameObject shield;
	public GameObject cannon;
	public GameObject thruster;
	public GameObject cargoBay;
	public GameObject warp;
	public GameObject spawner;
	public Canvas canv;
	public GameObject image;
	public GameObject main;

	public GameObject hp;
	public GameObject sp;

	public int hpMax;
	public int hpCurrent;
	public int spMax;
	public int spCurrent;
	public int num;

	public bool salvaged;
	public bool golden;
	public bool broken;
	public bool stunned;

	List<GameObject> health = new List<GameObject> ();
	List<GameObject> shields = new List<GameObject> ();
	// Use this for initialization
	void Start ()
	{
		if (type == 0) {
			hpMax = 10;
			hpCurrent = hpMax;
			spMax = 1;
			spCurrent = spMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			image = Instantiate (core, pos, transform.rotation) as GameObject;
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
		if (type == 1) {
			hpMax = 1;
			hpCurrent = hpMax;
			spMax = 0;
			spCurrent = spMax;
			Vector3 pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 30.0f;
			image = Instantiate (shield, pos, transform.rotation) as GameObject;
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
			image = Instantiate (cannon, pos, transform.rotation) as GameObject;
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
			image = Instantiate (thruster, pos, transform.rotation) as GameObject;
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
			image = Instantiate (cargoBay, pos, transform.rotation) as GameObject;
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
			image = Instantiate (warp, pos, transform.rotation) as GameObject;
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
		if (main.GetComponent<MainStage> ().stunTime > 0 && type != 0) {
			stunned = true;
		} else {
			stunned = false;
		}
		if (hpCurrent <= hpMax) {
			for (int i = 0; i < hpCurrent; i++) {
				(health [i]).GetComponent<Shutdown> ().on = true;
			}
			for (int i = hpCurrent; i < hpMax; i++) {
				(health [i]).GetComponent<Shutdown> ().on = false;
			}
		}
		if (hpCurrent == 0) {
			spCurrent = 0;
			if (!broken) {
				movement m = spawner.GetComponent<asteroid_spawn> ().player.GetComponent<movement> ();
				broken = true;
				if (type == 1) {
					m.shieldCount--;
				}
				if (type == 2) {
					m.gunCount--;
				}
				if (type == 3) {
					m.thrusterCount--;
				}
				if (type == 0) {
					spawner.GetComponent<asteroid_spawn> ().SendMessage ("endGame");
					main.GetComponent<MainStage> ().SendMessage ("lose");
					Destroy (gameObject);
				}
			} else {
				image.GetComponent<Image> ().color = new Vector4 (1.0f, 0.5f, 0.5f, 1.0f);
			}
		}
		if (stunned && type != 0) {
			if (!broken) {
				image.GetComponent<Image> ().color = new Vector4 (0.5f, 0.8f, 1.0f, 1.0f);
			} else {
				image.GetComponent<Image> ().color = new Vector4 (1.0f, 0.3f, 1.0f, 1.0f);
			}
			image.GetComponent<RectTransform> ().position = new Vector3 (30.0f + 60 * num + Random.Range (-2.0f, 2.0f), 30.0f + Random.Range (-2.0f, 2.0f), 0.0f);
		} else {
			image.GetComponent<Image> ().color = new Vector4 (1, 1, 1, 1);
		}
		if (broken && hpCurrent > 0) {
			broken = false;
		}
		if (golden) {
			image.GetComponent<Image> ().color = new Vector4 (1, 1, 0.3f, 1);
		}
		if (salvaged) {
			image.GetComponent<Image> ().color = new Vector4 (0.5f, 0.5f, 0.5f, 1);
		}
		if (spCurrent <= spMax) {
			for (int i = 0; i < spCurrent; i++) {
				(shields [i]).GetComponent<Shutdown> ().on = true;
			}
			for (int i = spCurrent; i < spMax; i++) {
				(shields [i]).GetComponent<Shutdown> ().on = false;
			}
		}						
	}

	void end ()
	{
		for (int i = 0; i < hpMax; i++) {
			Destroy (health [i]);
		}
		for (int i = 0; i < spMax; i++) {
			Destroy (shields [i]);
		}
		main.GetComponent<MainStage> ().parts.Remove (gameObject);
		Destroy (image);
		Destroy (gameObject);
	}

	void move ()
	{
		Vector3 pos = transform.position;
		pos.x = 30.0f + 60 * num;
		pos.y = 30.0f;
		image.transform.position = pos;
		for (int i = 0; i < hpMax; i++) {
			pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 80.0f + 40 * i;
			(health [i]).transform.position = pos;
		}
		for (int i = 0; i < spMax; i++) {
			pos = transform.position;
			pos.x = 30.0f + 60 * num;
			pos.y = 80.0f + 40 * i + 40 * hpMax;
			(shields [i]).transform.position = pos;
		}
	}
	void restoreShield()
	{
		if (hpCurrent > 0)
		spCurrent=spMax;
	}
}

