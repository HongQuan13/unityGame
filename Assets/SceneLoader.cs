using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Fixed: Added missing semicolon

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
     void OnMouseDown()
    {
        // Add your click handling logic here
        Debug.Log("Object clicked!");
        SceneManager.LoadScene("FlappyBird");
    }
    public void LoadSceneByName(string sceneName) // Fixed: Added parameter to specify scene name
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    public void LoadNextBuild()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Fixed: Corrected typo from `builIndex` to `buildIndex`
    }
}
