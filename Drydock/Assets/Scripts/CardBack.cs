using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardBack : MonoBehaviour
{
	Animator anim;
	AnimatorStateInfo state;

	public GameObject drydock;
	public GameObject exit;
	public GameObject bandits;
	public GameObject asteroids;
	public GameObject nebula;
	public GameObject deepSpace;
	public GameObject solarFlare;
	public GameObject trader;
	public GameObject shipwreck;
	[Multiline]
	public string tooltip;
	[Multiline]
	public string naah;
	public bool active;
	public int type;

	public GameObject main;
	public GameObject TT;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		//type = (int)Mathf.Round (Random.Range (-0.4f, 8.4f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (type == 0) {
			if ((!main.GetComponent<MainStage> ().zoomOut) && (!main.GetComponent<MainStage> ().zoom)) {
				anim.CrossFade ("Clicked", 0.0f);
				//Camera.main.GetComponent<Transform> ().Translate (new Vector3 (gameObject.GetComponent<Transform> ().position.x - Camera.main.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y - Camera.main.GetComponent<Transform> ().position.y, -10));
				main.GetComponent<MainStage> ().zoom = true;
				main.GetComponent<MainStage> ().zoomSpeed = 0.0f;
				main.GetComponent<MainStage> ().camSpeed = new Vector2 (0.0f, 0.0f);
				main.GetComponent<MainStage> ().camFocus = gameObject.GetComponent<Transform> ().position;
			}
		}
		state = anim.GetCurrentAnimatorStateInfo (0);
		if (state.IsName ("Del")) {
			if (type == 0) {
				GameObject aCard = Instantiate (drydock, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 1) {
				GameObject aCard = Instantiate (exit, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 2) {
				GameObject aCard = Instantiate (bandits, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 3) {
				GameObject aCard = Instantiate (asteroids, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 4) {
				GameObject aCard = Instantiate (nebula, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 5) {
				GameObject aCard = Instantiate (deepSpace, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 6) {
				GameObject aCard = Instantiate (solarFlare, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 7) {
				GameObject aCard = Instantiate (trader, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}
			if (type == 8) {
				GameObject aCard = Instantiate (shipwreck, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
				aCard.GetComponent<ActiveCard> ().main = main;
			}

			Destroy (gameObject);
		}


	}

	void OnMouseDown ()
	{
		if ((!main.GetComponent<MainStage> ().zoomOut) && (!main.GetComponent<MainStage> ().zoom)&&(!main.GetComponent<MainStage> ().mGInProgress)) {
			anim.CrossFade ("Clicked", 0.0f);
			//Camera.main.GetComponent<Transform> ().Translate (new Vector3 (gameObject.GetComponent<Transform> ().position.x - Camera.main.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y - Camera.main.GetComponent<Transform> ().position.y, -10));
			main.GetComponent<MainStage> ().zoom = true;
			main.GetComponent<MainStage> ().zoomSpeed = 0.0f;
			main.GetComponent<MainStage> ().camSpeed = new Vector2 (0.0f, 0.0f);
			main.GetComponent<MainStage> ().camFocus = gameObject.GetComponent<Transform> ().position;
		}
	}

	void OnMouseOver(){
		if (TT.GetComponent<Tooltip> ().alpha < 1.0f) {
			TT.GetComponent<Tooltip> ().alpha += 0.04f;
		}
		TT.GetComponent<Text> ().text = tooltip+naah;
	}
}
