using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public void LoadScene(int sceneIndex)
  {
    SceneManager.LoadScene(sceneIndex);
  }

  public void LoadScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
    Debug.Log("pindah scene"+ sceneName);
  }

  public void quit()
  {
    Application.Quit();
    Debug.Log("Quit Game");
  }
}
