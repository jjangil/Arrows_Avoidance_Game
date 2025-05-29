using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void f_ReStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void f_EndGame()
    {
        Application.Quit();
        Debug.Log("END");
    }
}

