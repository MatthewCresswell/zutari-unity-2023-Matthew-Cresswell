using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    CubeController cubeControllerScript;

    void Awake()
    {
        Instance =this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void LoadScne1()
    {
        SceneManager.LoadScene("Level One");
    }

    public void LoadScne2()
    {
        SceneManager.LoadScene("WeatherApp");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
