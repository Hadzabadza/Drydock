using UnityEngine;
using System.Collections;

public class CardBack : MonoBehaviour
{
	Animator anim;
	AnimatorStateInfo state;

	public GameObject asteroids;
	public GameObject nebula;
	public GameObject bandits;
	public GameObject trader;
	public GameObject exit;
	public GameObject drydock;
	public bool active;
	public int type;
	public GameObject main;
	public GameObject TT;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		type = (int)Mathf.Round (Random.Range (-0.4f, 5.0f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		state = anim.GetCurrentAnimatorStateInfo (0);
		if (state.IsName ("Del")) {
			if (type == 0) {
				GameObject aCard=Instantiate (asteroids, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
                CardsEvent.show = true;
                CardsEvent.MessageBoxIndex =5;
            }
			if (type == 1) {
				GameObject aCard=Instantiate (bandits, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
                CardsEvent.show = true;
                CardsEvent.MessageBoxIndex =4;
            }
			if (type == 2) {
				GameObject aCard=Instantiate (trader, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
                CardsEvent.show = true;
                CardsEvent.MessageBoxIndex =6;
            }
			if (type == 3) {
				GameObject aCard=Instantiate (exit, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
                CardsEvent.show = true;
                CardsEvent.MessageBoxIndex =3;
            }
			if (type == 4) {
				GameObject aCard=Instantiate (drydock, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
			}
			if (type == 5) {
				GameObject aCard=Instantiate (nebula, gameObject.GetComponent<Transform> ().position, gameObject.GetComponent<Transform> ().rotation) as GameObject;
				aCard.GetComponent<ActiveCard> ().TT = TT;
                CardsEvent.show = true;
                CardsEvent.MessageBoxIndex =8;
            }
            Destroy (gameObject);
		}


	}

	void OnMouseDown ()
	{
		if ((!main.GetComponent<MainStage> ().zoomOut)&&(!main.GetComponent<MainStage> ().zoom))
		{
			anim.CrossFade ("Clicked", 0.0f);
			//Camera.main.GetComponent<Transform> ().Translate (new Vector3 (gameObject.GetComponent<Transform> ().position.x - Camera.main.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y - Camera.main.GetComponent<Transform> ().position.y, -10));
			main.GetComponent<MainStage> ().zoom = true;
			main.GetComponent<MainStage> ().zoomSpeed = 0.0f;
			main.GetComponent<MainStage> ().camSpeed =new Vector2( 0.0f,0.0f);
			main.GetComponent<MainStage> ().camFocus = gameObject.GetComponent<Transform>().position;
		}
	}
}
