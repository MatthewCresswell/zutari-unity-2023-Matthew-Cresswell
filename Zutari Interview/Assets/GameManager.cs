using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
