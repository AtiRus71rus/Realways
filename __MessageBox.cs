using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class __MessageBox : MonoBehaviour {

    public Button buttonYes;
    public Text textMessage;

    public GameObject buttonYseNo;
    public GameObject buttonOk;
    
    public enum TypeButton
    {
        YesNo,
        Ok
    }

    public void Show( string message, UnityAction unityAction = null, TypeButton typeButton= TypeButton.YesNo )
    {
        gameObject.SetActive(true);
        textMessage.text = message;

        switch (typeButton)
        {
            case TypeButton.YesNo:
                buttonYseNo.SetActive(true);
                buttonOk.SetActive(false);

                buttonYes.onClick.RemoveAllListeners();
                buttonYes.onClick.AddListener(Hide);

                buttonYes.onClick.AddListener(unityAction);
                break;
            case TypeButton.Ok:
                if(buttonYseNo!=null)buttonYseNo.SetActive(false);

                buttonYes.onClick.RemoveAllListeners();
                buttonYes.onClick.AddListener(Hide);
                buttonYes.onClick.AddListener(unityAction);
                

                buttonOk.SetActive(true);
                break;
            default:
                break;
        }

        

    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
