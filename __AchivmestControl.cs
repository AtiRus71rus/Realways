using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __AchivmestControl : MonoBehaviour
{
    public void UnlockAchivmest(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) => {
            // handle success or failure
        });
    }
}
