using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideB2Correct : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(Example());

    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        if (gameObject.tag == "SceneCol")
        {

            Debug.Log("Collision Detected It Works");
            SceneManager.LoadScene("CorrectB2");
        }
    }
}
