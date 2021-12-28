using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class __ButtonBack : MonoBehaviour
{
    public Button back;

    void Start()
    {
        back = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            back.onClick.Invoke();
    }
}
