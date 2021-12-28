using System;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    private PlayerData PlayerData;

    public void Awake()
    {
        PlayerData = FindObjectOfType<SaveSystem>().PlayerData;
    }

    public void GivePrize(uint count, Reward reward)
    {
        if (reward.GetType() == typeof(RewardPerc))
            GivePrize(count, (RewardPerc)reward);
        if (reward.GetType() == typeof(RewardGold))
            GivePrize(count, (RewardGold)reward);
        if (reward.GetType() == typeof(RewardDaimond))
            GivePrize(count, (RewardDaimond)reward);
        if (reward.GetType() == typeof(RewardDaimond))
            GivePrize(count, (RewardDaimond)reward);
        if (reward.GetType() == typeof(RewardCase))
            GivePrize(count, (RewardCase)reward); 
        if (reward.GetType() == typeof(RewardCarriage))
            GivePrize(count, (RewardCarriage)reward);
    }
    
    public void GivePrize(uint count, RewardPerc perc)
    {
        PlayerData.Percs.Add(perc.PercData);
    }

    public void GivePrize(uint count, RewardGold gold)
    {
        PlayerData.Gold += count;
        PlayerData.TaskActionContainer.EarnGold.Invoke(count);
    }
    
    public void GivePrize(uint count, RewardDaimond diamod)
    {
        PlayerData.Diamond += count;
        PlayerData.TaskActionContainer.EarnRealCoin.Invoke(count);
    }
    
    public void GivePrize(uint count, RewardCase @case)
    {
        // todo: короче
        //PlayerData.
    }
    
    public void GivePrize(uint count, RewardCarriage carriage)
    {
        PlayerData.RegisterCarriage(carriage.carriageData);
        PlayerData.TaskActionContainer.ByCarriage.Invoke(count);
        if (carriage.carriageData.GetType() == typeof(CarriagePlatscartData))
            PlayerData.TaskActionContainer.ByPlatskart.Invoke(1);
        if (carriage.carriageData.GetType() == typeof(CarriageRestourantData))
            PlayerData.TaskActionContainer.ByRestourant.Invoke(1);
        if (carriage.carriageData.GetType() == typeof(CarriageCoupeData))
            PlayerData.TaskActionContainer.ByCoupe.Invoke(1);
    }
}