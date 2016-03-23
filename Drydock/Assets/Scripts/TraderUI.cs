using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TraderUI : MonoBehaviour
{
	public Sprite thruster;
	public Sprite shield;
	public Sprite cannon;
	public Sprite cargoBay;
	public Sprite warpDrive;
	public Image Icon;
	public GameObject main;
	public float timer;
	public float showTime;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer >= showTime) {
			gameObject.SetActive (false);
		}
	}

	void repaired (int type)
	{
		timer = 0;
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
		if (type == 4) {
			Icon.GetComponent<Image> ().sprite = cargoBay;
		}
		if (type == 5) {
			Icon.GetComponent<Image> ().sprite = warpDrive;
		}
		if (type == 0) {
			Icon.GetComponent<Image> ().color = new Vector4 (1, 1, 1, 0);
		}
	}
	void hide()
	{
		gameObject.SetActive (false);
	}
}
