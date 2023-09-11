using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideS7Wrong : MonoBehaviour
{
    public GameObject text;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Example());
        StartCoroutine(Example1());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(0);
        if (gameObject.tag == "StoveCol2")
        {
            text.SetActive(true);

        }
    }
    IEnumerator Example1()
    {
        yield return new WaitForSeconds(2);
        if (gameObject.tag == "StoveCol2")
        {
            //text.SetActive(true);
            SceneManager.LoadScene("WrongS7");

        }
    }
}
