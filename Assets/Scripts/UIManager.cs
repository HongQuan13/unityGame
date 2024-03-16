using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Include the UI namespace

public class SceneLoader : MonoBehaviour
{
    public Image maleOption; // Assign through the inspector
    public Image femaleOption; // Assign through the inspector
    public Image burnFatOption;
    public Image fitterOption;
    public Image massOption;
    private float transparentAlpha = 0.1f; // 80% transparent
    private float opaqueAlpha = 0.7f; // 100% opaque

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Call this when the male option is clicked
    public void OnMaleClicked()
    {
        SetTransparency(maleOption, opaqueAlpha);
        SetTransparency(femaleOption, transparentAlpha);
    }

    // Call this when the female option is clicked
    public void OnFemaleClicked()
    {
        SetTransparency(femaleOption, opaqueAlpha);
        SetTransparency(maleOption, transparentAlpha);
    }

     public void OnBurnFatClicked()
    {
        SetTransparency(burnFatOption, opaqueAlpha);
        SetTransparency(fitterOption, transparentAlpha);
        SetTransparency(massOption, transparentAlpha);

    }

    // Call this when the female option is clicked
    public void OnFitterClicked()
    {
        SetTransparency(burnFatOption, transparentAlpha);
        SetTransparency(fitterOption, opaqueAlpha);
        SetTransparency(massOption, transparentAlpha);
    }
    public void OnMassClicked()
    {
        SetTransparency(burnFatOption, transparentAlpha);
        SetTransparency(fitterOption, transparentAlpha);
        SetTransparency(massOption, opaqueAlpha);
    }

    // Helper method to set transparency
    private void SetTransparency(Image image, float alpha)
    {
        if (image != null)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }
}
