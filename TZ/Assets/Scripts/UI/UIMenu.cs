using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene(0);
    } 
    public void NextLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
