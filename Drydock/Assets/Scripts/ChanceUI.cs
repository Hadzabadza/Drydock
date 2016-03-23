using UnityEngine;
using System.Collections;

public class ChanceUI : MonoBehaviour {
	public GameObject card;
	public GameObject main;
	// Use this for initialization
	void Start () {
		//GameObject newCard=Instantiate (card)as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void newChance()
	{
		GameObject newCard = Instantiate (card) as GameObject;
		newCard.transform.SetParent (gameObject.transform);
		newCard.GetComponent<RectTransform> ().position = GetComponent<RectTransform> ().position;
		newCard.GetComponent<ChanceCardBack> ().main = main;
	}
}
