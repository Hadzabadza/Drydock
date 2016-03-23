using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardBack : MonoBehaviour
{
	public Animator anim;
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
	public bool resolved;
	public bool allowed;
	public int type;
	public int index;

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
				main.GetComponent<MainStage> ().currentCard = gameObject;
			}
		}
		state = anim.GetCurrentAnimatorStateInfo (0);
		if (state.IsName ("Del")) {
			GameObject aCard =null;
			if (type == 0) {
				aCard = Instantiate (drydock, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			if (type == 1) {
				aCard = Instantiate (exit, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				main.GetComponent<MainStage> ().exitUI.SetActive (true);
				main.GetComponent<MainStage> ().interfaceLock=true;
	}
			if (type == 2) {
				aCard = Instantiate (bandits, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			if (type == 3) {
				aCard = Instantiate (asteroids, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			if (type == 4) {
				aCard = Instantiate (nebula, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			if (type == 5) {
				aCard = Instantiate (deepSpace, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			if (type == 6) {
				aCard = Instantiate (solarFlare, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			if (type == 7) {
				aCard = Instantiate (trader, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			if (type == 8) {
				aCard = Instantiate (shipwreck, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;

			}
			aCard.GetComponent<ActiveCard> ().TT = TT;
			aCard.GetComponent<ActiveCard> ().main = main;
			aCard.GetComponent<ActiveCard> ().index = index;
			main.GetComponent<MainStage> ().events [index] = aCard;
			main.GetComponent<MainStage> ().currentCard = aCard;
			Destroy (gameObject);
		}


	}

	void OnMouseDown ()
	{
		if ((!main.GetComponent<MainStage> ().interfaceLock)&&(allowed)&&(!main.GetComponent<MainStage> ().zoomOut) && (!main.GetComponent<MainStage> ().zoom)&&(!main.GetComponent<MainStage> ().mGInProgress)&&(main.GetComponent<MainStage> ().currentCard.tag=="RESOLVED"||main.GetComponent<MainStage> ().currentCard.tag=="EXIT"||main.GetComponent<MainStage> ().currentCard.tag=="DRYDOCK")) {
			anim.CrossFade ("Clicked", 0.0f);
			//Camera.main.GetComponent<Transform> ().Translate (new Vector3 (gameObject.GetComponent<Transform> ().position.x - Camera.main.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y - Camera.main.GetComponent<Transform> ().position.y, -10));
			main.GetComponent<MainStage> ().zoom = true;
			main.GetComponent<MainStage> ().zoomSpeed = 0.0f;
			main.GetComponent<MainStage> ().camSpeed = new Vector2 (0.0f, 0.0f);
			main.GetComponent<MainStage> ().camFocus = gameObject.GetComponent<Transform> ().position;
			main.GetComponent<MainStage> ().currentCard = gameObject;
			main.GetComponent<MainStage> ().SendMessage ("restoreShields");
		}
	}

	void OnMouseOver(){
		main.GetComponent<MainStage> ().SendMessage ("checkMovement");
		if (TT.GetComponent<Tooltip> ().alpha < 1.0f) {
			TT.GetComponent<Tooltip> ().alpha += 0.04f;
		}
		if (allowed) {

			TT.GetComponent<Text> ().text = tooltip;
		} else {
			TT.GetComponent<Text> ().text = tooltip + naah;
		}
	}

	void removeCard()
	{
		Destroy (gameObject);
	}
}
