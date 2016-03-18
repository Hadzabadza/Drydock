using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartsCount : MonoBehaviour {

    private Text shieldCount;
    private Text cargoBaysCount;

    void Start ()
    {
        shieldCount = GameObject.Find("ShieldCountText").GetComponent<Text>();
        cargoBaysCount = GameObject.Find("CargoBayCountText").GetComponent<Text>();

    }
	
	void Update ()
    {
        shieldCount.text = "X " + Ship.shields;
        cargoBaysCount.text = "X " + Ship.cargoBays;
    }
}
