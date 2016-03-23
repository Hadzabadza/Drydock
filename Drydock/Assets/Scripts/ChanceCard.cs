using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChanceCard : MonoBehaviour {
	Animator anim;
	AnimatorStateInfo state;
	public GameObject main;
	public GameObject cardBack;
	public Sprite repair;
	public Sprite ambush;
	public Sprite unfocused;
	public Sprite treasure;
	public int type;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator> ();
		if (type == 0) {
			gameObject.GetComponent<Image> ().sprite = ambush;
		}
		if (type == 1) {
			gameObject.GetComponent<Image> ().sprite = unfocused;
		}
		if (type == 2) {
			gameObject.GetComponent<Image> ().sprite = repair;
		}
		if (type == 3) {
			gameObject.GetComponent<Image> ().sprite = treasure;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void claim()
	{
		if (type == 0) {
			claimAmbush ();
		}

		if (type == 1) {
			List<GameObject> jumps = new List<GameObject> ();
			for (int i = 0; i < main.GetComponent<MainStage> ().events.Length; i++) {
				if((main.GetComponent<MainStage>().events [i].GetComponent ("CardBack")as CardBack) != null)
					jumps.Add(main.GetComponent<MainStage>().events [i]);
			}
			if (jumps.Count>0)
			{
				int chosen=Mathf.RoundToInt(Random.Range(-0.4f,0.6f+jumps.Count-1));
				(jumps[chosen]).GetComponent<CardBack>().anim.CrossFade ("Clicked", 0.0f);
				//Camera.main.GetComponent<Transform> ().Translate (new Vector3 (gameObject.GetComponent<Transform> ().position.x - Camera.main.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y - Camera.main.GetComponent<Transform> ().position.y, -10));
				main.GetComponent<MainStage> ().zoom = true;
				main.GetComponent<MainStage> ().zoomSpeed = 0.0f;
				main.GetComponent<MainStage> ().camSpeed = new Vector2 (0.0f, 0.0f);
				main.GetComponent<MainStage> ().camFocus = (jumps[chosen]).GetComponent<Transform> ().position;
				main.GetComponent<MainStage> ().currentCard = (jumps[chosen]);
				main.GetComponent<MainStage> ().SendMessage ("restoreShields");
			}
		}

		if (type == 2) {
			main.GetComponent<MainStage> ().repairUI.SetActive (true);
			main.GetComponent<MainStage> ().repairUI.GetComponent<RepairUI> ().repairs = 3 + main.GetComponent<MainStage> ().level / 3;
			main.GetComponent<MainStage> ().repairUI.SendMessage ("findParts");
			main.GetComponent<MainStage> ().SendMessage ("lockUI");
		}

		if (type == 3) {
			claimTreasure ();
		}

		main.GetComponent<MainStage>().nebulaUI.SetActive(false);
		main.GetComponent<MainStage>().SendMessage("unlockUI");
		if (main.GetComponent<MainStage> ().stunTime>0)
			main.GetComponent<MainStage> ().stunTime--;
		Destroy (gameObject);
	}

	void claimAmbush ()
	{
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().active = true;
		main.GetComponent<MainStage> ().camFocus.x = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.x;
		main.GetComponent<MainStage> ().camFocus.y = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.y;
		main.GetComponent<MainStage> ().zoomOut = true;
		main.GetComponent<MainStage> ().mGInProgress = true;
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().level = main.GetComponent<MainStage> ().level;
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().gameType = 1;
		main.GetComponent<MainStage> ().mGAreaRef.SendMessage ("startAmbush");
	}

	void claimTreasure()
	{
		main.GetComponent<MainStage> ().SendMessage ("newGolden");
	}
}
