using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreShield : MonoBehaviour
{

    private Text cardText;

    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        cardText = GameObject.Find("Description").GetComponent<Text>();
    }

    void Update()
    {

    }

    void OnMouseEnter()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        cardText.text = "Shields protect your ship from incoming damage. Part of the shield energy is restored each turn.";
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        cardText.text = "";
    }
}
