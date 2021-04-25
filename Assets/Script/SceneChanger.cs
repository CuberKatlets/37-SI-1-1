using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public void ChangeScene(int sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	public void Exit()
	{
		Application.Quit();
	}
}