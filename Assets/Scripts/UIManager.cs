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
    public Image monOption;
    public Image tueOption;
    public Image wedOption;
    public Image thuOption;
    public Image friOption;
    public Image satOption;
    public Image sunOption;
    public GameObject monTable;
    public GameObject tueTable;
    public GameObject wedTable;
    public GameObject thuTable;
    public GameObject friTable;
    public GameObject satTable;
    public GameObject sunTable;
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

     public void OnMonClicked()
    {
        SetTransparency(monOption, opaqueAlpha);
        SetTransparency(tueOption, transparentAlpha);
        SetTransparency(wedOption, transparentAlpha);
        SetTransparency(thuOption, transparentAlpha);
        SetTransparency(friOption, transparentAlpha);
        SetTransparency(satOption, transparentAlpha);
        SetTransparency(sunOption, transparentAlpha);
        monTable.SetActive(true);
        tueTable.SetActive(false);
        wedTable.SetActive(false);
        thuTable.SetActive(false);
        friTable.SetActive(false);
        satTable.SetActive(false);
        sunTable.SetActive(false);
        
    }
    public void OnTueClicked()
    {
        SetTransparency(tueOption, opaqueAlpha);
        SetTransparency(monOption, transparentAlpha);
        SetTransparency(wedOption, transparentAlpha);
        SetTransparency(thuOption, transparentAlpha);
        SetTransparency(friOption, transparentAlpha);
        SetTransparency(satOption, transparentAlpha);
        SetTransparency(sunOption, transparentAlpha);
        monTable.SetActive(false);
        tueTable.SetActive(true);
        wedTable.SetActive(false);
        thuTable.SetActive(false);
        friTable.SetActive(false);
        satTable.SetActive(false);
        sunTable.SetActive(false);
    }
    public void OnWedClicked()
    {
        SetTransparency(wedOption, opaqueAlpha);
        SetTransparency(tueOption, transparentAlpha);
        SetTransparency(monOption, transparentAlpha);
        SetTransparency(thuOption, transparentAlpha);
        SetTransparency(friOption, transparentAlpha);
        SetTransparency(satOption, transparentAlpha);
        SetTransparency(sunOption, transparentAlpha);
        monTable.SetActive(false);
        tueTable.SetActive(false);
        wedTable.SetActive(true);
        thuTable.SetActive(false);
        friTable.SetActive(false);
        satTable.SetActive(false);
        sunTable.SetActive(false);
    }
    public void OnThuClicked()
    {
        SetTransparency(thuOption, opaqueAlpha);
        SetTransparency(tueOption, transparentAlpha);
        SetTransparency(wedOption, transparentAlpha);
        SetTransparency(monOption, transparentAlpha);
        SetTransparency(friOption, transparentAlpha);
        SetTransparency(satOption, transparentAlpha);
        SetTransparency(sunOption, transparentAlpha);
        monTable.SetActive(false);
        tueTable.SetActive(false);
        wedTable.SetActive(false);
        thuTable.SetActive(true);
        friTable.SetActive(false);
        satTable.SetActive(false);
        sunTable.SetActive(false);
    }
    public void OnFriClicked()
    {
        SetTransparency(friOption, opaqueAlpha);
        SetTransparency(tueOption, transparentAlpha);
        SetTransparency(wedOption, transparentAlpha);
        SetTransparency(thuOption, transparentAlpha);
        SetTransparency(monOption, transparentAlpha);
        SetTransparency(satOption, transparentAlpha);
        SetTransparency(sunOption, transparentAlpha);
        monTable.SetActive(false);
        tueTable.SetActive(false);
        wedTable.SetActive(false);
        thuTable.SetActive(false);
        friTable.SetActive(true);
        satTable.SetActive(false);
        sunTable.SetActive(false);
    }
    public void OnSatClicked()
    {
        SetTransparency(satOption, opaqueAlpha);
        SetTransparency(tueOption, transparentAlpha);
        SetTransparency(wedOption, transparentAlpha);
        SetTransparency(thuOption, transparentAlpha);
        SetTransparency(friOption, transparentAlpha);
        SetTransparency(monOption, transparentAlpha);
        SetTransparency(sunOption, transparentAlpha);
        monTable.SetActive(false);
        tueTable.SetActive(false);
        wedTable.SetActive(false);
        thuTable.SetActive(false);
        friTable.SetActive(false);
        satTable.SetActive(true);
        sunTable.SetActive(false);
    }
    public void OnSunClicked()
    {
        SetTransparency(sunOption, opaqueAlpha);
        SetTransparency(tueOption, transparentAlpha);
        SetTransparency(wedOption, transparentAlpha);
        SetTransparency(thuOption, transparentAlpha);
        SetTransparency(friOption, transparentAlpha);
        SetTransparency(monOption, transparentAlpha);
        SetTransparency(satOption, transparentAlpha);
        monTable.SetActive(false);
        tueTable.SetActive(false);
        wedTable.SetActive(false);
        thuTable.SetActive(false);
        friTable.SetActive(false);
        satTable.SetActive(false);
        sunTable.SetActive(true);
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