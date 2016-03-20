using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActiveCard : MonoBehaviour
{
	[Multiline]
	public string tooltip;
	public GameObject main;
	public GameObject TT;
	public bool resolved;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		if (gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			if (!resolved) {
				if (tag == "ASTEROIDS") {
					asteroids ();
				}
				resolved =true;
			}
		}
	}

	void OnMouseOver ()
	{
		if (TT.GetComponent<Tooltip> ().alpha < 1.0f) {
			TT.GetComponent<Tooltip> ().alpha += 0.04f;
		}
		TT.GetComponent<Text> ().text = tooltip;
	}
	void asteroids(){
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().active = true;
		main.GetComponent<MainStage> ().camFocus.x = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.x;
		main.GetComponent<MainStage> ().camFocus.y = main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().transform.position.y;
		main.GetComponent<MainStage> ().zoomOut = true;
		main.GetComponent<MainStage> ().mGInProgress = true;
		main.GetComponent<MainStage> ().mGAreaRef.GetComponent<asteroid_spawn> ().level = main.GetComponent<MainStage> ().level;
		main.GetComponent<MainStage> ().mGAreaRef.SendMessage ("startAsteroids");
	}
}
