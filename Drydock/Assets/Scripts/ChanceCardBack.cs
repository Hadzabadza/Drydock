using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChanceCardBack : MonoBehaviour
{
	Animator anim;
	AnimatorStateInfo state;

	public GameObject main;
	public GameObject card;


	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		//type = (int)Mathf.Round (Random.Range (-0.4f, 8.4f));
	}

	// Update is called once per frame
	void Update ()
	{
		state = anim.GetCurrentAnimatorStateInfo (0);
		if (state.IsName ("Del")) {
			GameObject newCard = Instantiate (card) as GameObject;
			float chance = Random.Range (0.0f, 100.0f);
			if (chance < 28) {
				newCard.GetComponent<ChanceCard> ().type = 0;
			} else {
				if (chance < 56) {
					newCard.GetComponent<ChanceCard> ().type = 1;
				} else {
					if (chance < 84) {
						newCard.GetComponent<ChanceCard> ().type = 2;
					} else {
						newCard.GetComponent<ChanceCard> ().type = 3;
					}
				}
			}
			newCard.transform.SetParent (gameObject.transform.parent);
			newCard.GetComponent<RectTransform> ().position = GetComponent<RectTransform> ().position;
			newCard.GetComponent<ChanceCard> ().main = main;
			Destroy (gameObject);
		}
	}
			
	void turn()
	{
		anim.CrossFade ("Clicked", 0.0f);
	}
}
