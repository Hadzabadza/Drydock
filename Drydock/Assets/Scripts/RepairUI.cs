using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RepairUI : MonoBehaviour
{
	public GameObject main;
	public GameObject exiter;
	public GameObject repairBTN;
	public Text repairsRemaining;
	public List<GameObject> parts;
	public int repairs=0;
	// Use this for initialization
	void findParts ()
	{
		for (int i = 0; i < parts.Count; i++) {
			Destroy (parts [i]);
		}
		parts = new List<GameObject> ();
		for (int i = 0; i < main.GetComponent<MainStage> ().parts.Count; i++) {
			if ((main.GetComponent<MainStage> ().parts [i]).GetComponent<Part> ().hpCurrent < (main.GetComponent<MainStage> ().parts [i]).GetComponent<Part> ().hpMax) {
				parts.Add (main.GetComponent<MainStage> ().parts [i]);
			}
		}
		if (parts.Count == 0) {
			repairs = 0;
		} else
			for (int i = 0; i < parts.Count; i++) {
				GameObject partBTN = Instantiate (repairBTN) as GameObject;
				partBTN.transform.SetParent (gameObject.transform);
				partBTN.GetComponent<RepairBTN> ().part = parts [i];
				parts [i] = partBTN;
				partBTN.GetComponent<RectTransform> ().position = new Vector2 (transform.position.x - 65.0f * parts.Count + 130.0f * i, transform.position.y+0.0f);
			}
	}
	
	// Update is called once per frame
	void Update ()
	{
		repairsRemaining.GetComponent<Text> ().text = "x" + repairs;
		if (repairs <= 0) {
			exiter.SetActive (true);
		} else {
			exiter.SetActive (false);
		}
	}

	void hide ()
	{
		main.GetComponent<MainStage> ().SendMessage ("unlockUI");
		gameObject.SetActive (false);
	}
}
