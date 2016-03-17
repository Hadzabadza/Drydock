using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreCargoBay : MonoBehaviour
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
        cardText.text = "CargoBays allows your ship to carry more resources to the next level.";
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        cardText.text = "";
    }

}
