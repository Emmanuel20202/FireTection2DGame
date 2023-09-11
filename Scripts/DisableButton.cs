using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button newButton;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewButton()
    {
        Debug.Log("Hello World");
        newButton.interactable = false;
    }
}
