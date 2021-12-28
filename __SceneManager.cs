using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __SceneManager : MonoBehaviour {

    public void ButtonLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }
}
