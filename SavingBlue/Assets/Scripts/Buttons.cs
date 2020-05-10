using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(SceneManager.GetActiveScene().name == "YouLose" || SceneManager.GetActiveScene().name == "CreditsScene")
            {
                Menu();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
    public void LevelOne()
    {
        SceneManager.LoadScene("NewLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoseScene()
    {
        SceneManager.LoadScene("YouLose");
    }
    public void WinScene()
    {
        SceneManager.LoadScene("YouWin");
    }
}
