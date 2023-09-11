using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S7Wrong : MonoBehaviour
{

    public Text collisionIndicatorText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("S7WrongCollide"))
        {
            collisionIndicatorText.gameObject.SetActive(true);
            collisionIndicatorText.text = "DOOR OPENED"; // show collision indicator text


            StartCoroutine(LoadNextScene()); // load next scene after 2 seconds
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("WrongS7");
    }
}
