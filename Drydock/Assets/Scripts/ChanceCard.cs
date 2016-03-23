using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
