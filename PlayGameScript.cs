using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGameScript : MonoBehaviour
{
    public UnityEngine.UI.Text Text;

    public bool isAuthStart;

    // Start is called before the first frame update
    void Start()
    {
        if (!isAuthStart)
            return;
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;


        SignIn();
    }

    public void SignIn()
    {
        Social.localUser.Authenticate(a => {
            if (a)
                Text.text = Social.localUser.userName;
            else
                Text.text = "No Authenticate";
        });
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
        if (Social.localUser.authenticated == false)
        {
            Text.text = "No Authenticate";
        }
    }

    public void ShowAchivmets()
    {
        Social.ShowAchievementsUI();
    }

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
}