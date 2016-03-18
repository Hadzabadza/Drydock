using UnityEngine;
using System.Collections;

public class CargoBayButton : MonoBehaviour
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
}
