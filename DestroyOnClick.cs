using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClick : MonoBehaviour
{
    public Button destroyButton;
    public GameObject objectToDestroy;

    private void Start()
    {
        destroyButton.onClick.AddListener(DestroyObject);
    }

    public void DestroyObject()
    {
        Destroy(objectToDestroy);
    }
}
