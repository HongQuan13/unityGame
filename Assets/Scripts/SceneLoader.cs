using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
    //  void OnMouseDown(string sceneName)
    // {
    //     Debug.Log("Object clicked!");
    //     SceneManager.LoadScene(sceneName);
    // }
    public void LoadSceneByName( string sceneName)
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(sceneName);
    }

    // // Update is called once per frame
    public void LoadNextBuild()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
