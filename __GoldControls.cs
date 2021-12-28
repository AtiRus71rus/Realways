using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;
using UnityEngine.Serialization;

public class __GoldControls : MonoBehaviour
{
    [ReadOnlyField]
    public PlayerData playerData;

    private void Awake()
    {
        playerData = FindObjectOfType<SaveSystem>().PlayerData;
    }

    public bool BuyGold(uint price)
    {
        if (playerData.Gold < price)
            return false;
        GameObject.FindObjectOfType<SaveSystem>().PlayerData.TaskActionContainer.SpentGold.Invoke(price);
        playerData.Gold -=price;
        return true;
    }

    public bool BuyDiamond(uint price)
    {
        if (playerData.Diamond < price)
            return false;
        playerData.Diamond -= price;
        GameObject.FindObjectOfType<SaveSystem>().PlayerData.TaskActionContainer.SpentRealCoin.Invoke(price);
        return true;
    }
}
