using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scenamanager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EndLevel01")
            SceneManager.LoadScene("Note1");
        if (collision.gameObject.name == "EndLevel02")
            SceneManager.LoadScene("Scene02");
        if (collision.gameObject.name == "EndLevel03")
            SceneManager.LoadScene("Note2");
        if (collision.gameObject.name == "EndLevel04")
            SceneManager.LoadScene("Scene04");
    }
}
