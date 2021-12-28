using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class __Valuta : MonoBehaviour
{

    public Text money;
    public Text daimond;

    [ReadOnlyField]
    public PlayerData playerData;

    private void Awake()
    {
        playerData = FindObjectOfType<SaveSystem>().PlayerData;
    }

    uint moneyValue;
    uint goldValue;

    // Update is called once per frame
    void Update()
    {
        if (goldValue != playerData.Gold)
        {
            money.text = playerData.Gold.ToString();
            goldValue = playerData.Gold;
        }
        if (moneyValue != playerData.Gold)
        {
            daimond.text = playerData.Diamond.ToString();
            moneyValue = playerData.Diamond;

        }
    }
}
