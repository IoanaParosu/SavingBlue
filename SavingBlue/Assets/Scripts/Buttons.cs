using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    bool changing = false;
    public float delay = 3;

    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && changing == false)
        {
            StartCoroutine(ChangeScene());
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

    IEnumerator ChangeScene()
    {
        changing = true;

        FindObjectOfType<AudioManager>().Play("ButtonSound");

        Instantiate(fade, Vector3.zero, Quaternion.identity);

        yield return new WaitForSeconds(delay);
        if (SceneManager.GetActiveScene().name == "YouLose" || SceneManager.GetActiveScene().name == "CreditsScene")
        {
            Menu();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
