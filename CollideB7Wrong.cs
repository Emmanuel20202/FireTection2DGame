using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideB7Wrong : MonoBehaviour
{
    public GameObject text;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        StartCoroutine(Example1());
    }
 
    IEnumerator Example1()
    {
        yield return new WaitForSeconds(1);
        if (gameObject.tag == "ColB7Wrong")
        {
            //text.SetActive(true);
            SceneManager.LoadScene("WrongB7");

        }
    }
}
