using UnityEngine;
using System.Collections;

public class ShieldButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buyShield()
    {
        if(CreditBalance.credits>1)
        {
            CreditBalance.credits -= 2;
            Ship.shields += 1;
        }
    }
}
