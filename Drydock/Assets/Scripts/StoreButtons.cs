using UnityEngine;
using System.Collections;

public class StoreButtons : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buyCargoBay()
    {
        if (CreditBalance.credits > 0)
        {
            CreditBalance.credits -= 1;
            Ship.cargoBays += 1;
        }
    }

    public void buyShield()
    {
        if (CreditBalance.credits > 1)
        {
            CreditBalance.credits -= 2;
            Ship.shields += 1;
        }
    }
}
