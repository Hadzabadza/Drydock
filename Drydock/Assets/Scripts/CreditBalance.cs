using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditBalance : MonoBehaviour
{

    private Text CreditsText;
    static public int credits = 10;

    void Start()
    {
        CreditsText = GameObject.Find("CreditBalance").GetComponent<Text>();
    }

    void Update()
    {
        CreditsText.text = "Credits balance: " + credits;
    }
}
