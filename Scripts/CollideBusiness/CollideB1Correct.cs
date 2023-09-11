using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideB1Correct : MonoBehaviour
{
    public GameObject text;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(0);
        if (gameObject.tag == "PopupB1")
        {
            text.SetActive(true);

        }
    }
}
