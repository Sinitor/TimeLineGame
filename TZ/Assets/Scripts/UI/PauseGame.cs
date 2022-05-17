using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Image pausePanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.gameObject.SetActive(true);
        }
    } 
    public void ExitGame()
    {
        Application.Quit();
    } 
    public void UnPause()
    {
        Time.timeScale = 1;
        pausePanel.gameObject.SetActive(false);
    }
}
