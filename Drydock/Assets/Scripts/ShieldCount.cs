using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldCount : MonoBehaviour {

    private Text shieldCount;

    void Start ()
    {
        shieldCount = GameObject.Find("ShieldCountText").GetComponent<Text>();
    }
	
	void Update ()
    {
        shieldCount.text = "X " + Ship.shields;
    }
}
