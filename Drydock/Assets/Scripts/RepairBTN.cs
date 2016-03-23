using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RepairBTN : MonoBehaviour
{
	public GameObject part;
	public Sprite shield;
	public Sprite cannon;
	public Sprite thruster;
	public Sprite cargoBay;
	public Sprite warpDrive;

	// Use this for initialization
	void Start ()
	{
		if (part.GetComponent<Part> ().type == 1) {
			GetComponent<Image> ().sprite = shield;
		}
		if (part.GetComponent<Part> ().type == 2) {
			GetComponent<Image> ().sprite = cannon;
		}
		if (part.GetComponent<Part> ().type == 3) {
			GetComponent<Image> ().sprite = thruster;
		}
		if (part.GetComponent<Part> ().type == 4) {
			GetComponent<Image> ().sprite = cargoBay;
		}
		if (part.GetComponent<Part> ().type == 5) {
			GetComponent<Image> ().sprite = warpDrive;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (part.GetComponent<Part> ().golden) {
			GetComponent<Image> ().color = new Vector4 (1, 1, 0.3f, 1);
		}
		if (part.GetComponent<Part> ().salvaged) {
			GetComponent<Image> ().color = new Vector4 (0.5f, 0.5f, 0.5f, 1);
		}
	}

	void repair ()
	{
		if (GetComponentInParent<RepairUI> ().repairs > 0) {
			part.GetComponent<Part> ().hpCurrent++;
			GetComponentInParent<RepairUI> ().repairs--;
			if (part.GetComponent<Part> ().hpCurrent == part.GetComponent<Part> ().hpMax) {
				GetComponentInParent<RepairUI> ().SendMessage ("findParts");
			}
		} else {
			GetComponentInParent<RepairUI> ().gameObject.SetActive (false);
		}
	}
}
