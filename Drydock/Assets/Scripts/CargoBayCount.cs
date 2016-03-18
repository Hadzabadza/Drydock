using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CargoBayCount : MonoBehaviour
{

    private Text cargoBayCount;

    void Start()
    {
        cargoBayCount = GameObject.Find("CargoBayCountText").GetComponent<Text>();
    }

    void Update()
    {
        cargoBayCount.text = "X " + Ship.cargoBays;
    }
}
