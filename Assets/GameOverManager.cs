using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    public void ClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ClickResume()
    {
        Cursor.lockState = CursorLockMode.None;
        menuPanel.SetActive(false);
        Cursor.visible = false;
    }
}
