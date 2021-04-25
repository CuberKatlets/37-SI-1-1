using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayCurrentLevel()
    {

    }

    public void OpenLevelList()
    {
        SceneManager.LoadScene(1);
    }
}