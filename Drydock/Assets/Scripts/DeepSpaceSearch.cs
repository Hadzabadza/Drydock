using UnityEngine;
using System.Collections;

public class DeepSpaceSearch : MonoBehaviour {
	public GameObject nebulaUI;
	public GameObject failUI;
	public GameObject main;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void rollForChance()
	{
		if (Random.Range (0.0f, 2.0f) > 1) {
			nebulaUI.SetActive (true);
			nebulaUI.GetComponent<ChanceUI> ().SendMessage ("newChance");
			gameObject.SetActive (false);
		} else {
			main.GetComponent<MainStage> ().SendMessage ("unlockUI");
			failUI.SetActive (true);
			if (main.GetComponent<MainStage> ().stunTime>0)
				main.GetComponent<MainStage> ().stunTime--;
			gameObject.SetActive (false);
		}

	}
	void naah()
	{
		main.GetComponent<MainStage> ().SendMessage ("unlockUI");
		if (main.GetComponent<MainStage> ().stunTime>0)
			main.GetComponent<MainStage> ().stunTime--;
		gameObject.SetActive (false);
	}
}
