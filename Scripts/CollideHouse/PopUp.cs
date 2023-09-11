using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
   
    public GameObject text;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Example());
        
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(0);
        if (gameObject.tag == "StoveCol")
        {
            text.SetActive(true);
           
        }
    }

}
