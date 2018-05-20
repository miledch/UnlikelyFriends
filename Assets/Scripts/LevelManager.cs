using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);


    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");

        Application.Quit();
    }

    public void LoadNextLevel()
    {
        print(SceneManager.GetActiveScene().buildIndex + 1);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLastLevel()
    {
        print(SceneManager.sceneCount - 1);
        SceneManager.LoadScene(SceneManager.sceneCount - 1);
    }


    /*
    public void BrickDestroyed()
    {
        if (Brick.breakableCount == 0)
        {
            buildIndex++;

            print("index = " + buildIndex);
            print("winIndex = " + winIndex);

            if (buildIndex == winIndex)
            {
                buildIndex = 2;
            }
            else
            {

            }
            LoadNextLevel();
        }
    }

    */

}
