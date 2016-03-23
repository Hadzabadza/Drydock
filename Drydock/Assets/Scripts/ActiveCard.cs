using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActiveCard : MonoBehaviour
{
	[Multiline]
	public string tooltip;
	[Multiline]
	public string naah;
	[Multiline]
	public string here;
	public GameObject main;
	public GameObject TT;
	public bool resolved;
	public bool allowed;
	public int index;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		if (tag!="RESOLVED")
		if (gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			
			if (tag == "ASTEROIDS" && !main.GetComponent<MainStage> ().debug) {
				asteroids ();
				tag = "RESOLVED";
			}
			if (tag == "SOLARFLARE" && !main.GetComponent<MainStage> ().debug) {
					main.GetComponent<MainStage> ().stunTime++;
				main.GetComponent<MainStage> ().solarFlareUI.SetActive (true);
				main.GetComponent<MainStage> ().solarFlareUI.GetComponent<SFOverlay> ().timer = 0;
				tag = "RESOLVED";
			}
			if (tag == "BANDITS" && !main.GetComponent<MainStage> ().debug) {
				bandits ();
				tag = "RESOLVED";
			}
			if (tag == "NEBULA" && !main.GetComponent<MainStage> ().debug) {
				main.GetComponent<MainStage> ().nebulaUI.SetActive (true);
				main.GetComponent<MainStage> ().nebulaUI.GetComponent<ChanceUI> ().SendMessage ("newChance");
				main.GetComponent<MainStage> ().SendMessage ("lockUI");
				if (main.GetComponent<MainStage> ().stunTime>0)
					main.GetComponent<MainStage> ().stunTime--;
				tag = "RESOLVED";
			}
			if (tag == "SHIPWRECK" && !main.GetComponent<MainStage> ().debug) {
				main.GetComponent<MainStage> ().shipwreckUI.SetActive(true);
				main.GetComponent<MainStage> ().shipwreckUI.SendMessage ("trySalvage");;
				if (main.GetComponent<MainStage> ().stunTime>0)
					main.GetComponent<MainStage> ().stunTime--;
				tag = "RESOLVED";
			}
			if (tag == "TRADER" && !main.GetComponent<MainStage> ().debug) {
				main.GetComponent<MainStage> ().SendMessage ("repairBroken");
				if (main.GetComponent<MainStage> ().stunTime>0)
					main.GetComponent<MainStage> ().stunTime--;
				tag = "RESOLVED";
			}
			if (tag == "DEEPSPACE" && !main.GetComponent<MainStage> ().debug) {
				main.GetComponent<MainStage> ().nebulaUI.SetActive (true);
				main.GetComponent<MainStage> ().nebulaUI.GetComponent<ChanceUI> ().SendMessage ("newChance");
				main.GetComponent<MainStage> ().SendMessage ("lockUI");

				if (main.GetComponent<MainStage> ().stunTime>0)
					main.GetComponent<MainStage> ().stunTime--;
				tag = "RESOLVED";
			}
		}
	}

	void OnMouseDown ()
	{
		if ((!main.GetComponent<MainStage> ().interfaceLock)&&(allowed)&&(!main.GetComponent<MainStage> ().zoomOut) && (!main.GetComponent<MainStage> ().zoom)&&(!main.GetComponent<MainStage> ().mGInProgress)) {
			//Camera.main.GetComponent<Transform> ().Translate (new Vector3 (gameObject.GetComponent<Transform> ().position.x - Camera.main.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y - Camera.main.GetComponent<Transform> ().position.y, -10));
			main.GetComponent<MainStage> ().zoom = true;
			main.GetComponent<MainStage> ().zoomSpeed = 0.0f;
			main.GetComponent<MainStage> ().camSpeed = new Vector2 (0.0f, 0.0f);
			main.GetComponent<MainStage> ().camFocus = gameObject.transform.position;
			main.GetComponent<MainStage> ().currentCard = gameObject;
			if (tag == "EXIT") {
				main.GetComponent<MainStage> ().exitUI.SetActive (true);
				main.GetComponent<MainStage> ().interfaceLock = true;
			}
		}
	}
	void OnMouseOver ()
	{
		main.GetComponent<MainStage> ().SendMessage ("checkMovement");
		if (TT.GetComponent<Tooltip> ().alpha < 1.0f) {
			TT.GetComponent<Tooltip> ().alpha += 0.04f;
		}
		if (allowed) {
			
			TT.GetComponent<Text> ().text = tooltip;
		} else {
			if (main.GetComponent<MainStage> ().currentCard == gameObject) {
				TT.GetComponent<Text> ().text = tooltip + here;
			}
			else
			TT.GetComponent<Text> ().text = tooltip + naah;
		}
	}

	void asteroids ()
	{
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().active = true;
		main.GetComponent<MainStage> ().camFocus.x = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.x;
		main.GetComponent<MainStage> ().camFocus.y = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.y;
		main.GetComponent<MainStage> ().zoomOut = true;
		main.GetComponent<MainStage> ().mGInProgress = true;
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().level = main.GetComponent<MainStage> ().level;
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().gameType = 0;
		main.GetComponent<MainStage> ().mGAreaRef.SendMessage ("startAsteroids");
	}
	void bandits ()
	{
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().active = true;
		main.GetComponent<MainStage> ().camFocus.x = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.x;
		main.GetComponent<MainStage> ().camFocus.y = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.y;
		main.GetComponent<MainStage> ().zoomOut = true;
		main.GetComponent<MainStage> ().mGInProgress = true;
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().level = main.GetComponent<MainStage> ().level;
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().gameType = 1;
		main.GetComponent<MainStage> ().mGAreaRef.SendMessage ("startBandits");
	}

	void removeCard ()
	{
		Destroy (gameObject);
	}
}
