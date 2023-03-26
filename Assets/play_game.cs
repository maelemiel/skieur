using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_game : MonoBehaviour
{
    // Start is called before the first frame update
    public void play_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quit_Game()
    {
        Application.Quit();
    }
}
