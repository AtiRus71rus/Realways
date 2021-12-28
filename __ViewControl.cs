using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __ViewControl : MonoBehaviour
{
    public GameObject coupe;
    public GameObject platscart;
    public GameObject restourant;


    public void UpdateDisplay(CarriageData carriage)
    {
        coupe.SetActive(false);
        platscart.SetActive(false);
        restourant.SetActive(false);

        if (carriage is CarriageCoupeData)
            coupe.SetActive(true);
        else if(carriage is CarriagePlatscartData)
            platscart.SetActive(true);
        else if (carriage is CarriageRestourantData)
            restourant.SetActive(true);
    }
}
