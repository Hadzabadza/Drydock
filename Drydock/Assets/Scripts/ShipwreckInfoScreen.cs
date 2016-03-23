using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipwreckInfoScreen : MonoBehaviour {
	public Sprite thruster;
	public Sprite shield;
	public Sprite cannon;
	public Image Icon;
	public GameObject main;
	public float timer;
	public float showTime;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= showTime) {
			gameObject.SetActive (false);
		}
	}
	void trySalvage()
	{
		timer = 0;
		if (Random.Range (0.0f, 100.0f) > 50.0f) {
			int type = Mathf.RoundToInt (Random.Range (0.6f, 3.4f));
			main.GetComponent<MainStage> ().SendMessage ("newSalvaged", type);
			Icon.GetComponent<Image> ().color = new Vector4 (1, 1, 1, 1);
			if (type == 1) {
				Icon.GetComponent<Image> ().sprite = shield;
			}
			if (type == 2) {
				Icon.GetComponent<Image> ().sprite = cannon;
			}
			if (type == 3) {
				Icon.GetComponent<Image> ().sprite = thruster;
			}
		} else {
			Icon.GetComponent<Image> ().color = new Vector4 (1, 1, 1, 0);
		}
	}
	void hide()
	{
		gameObject.SetActive (false);
	}
}
