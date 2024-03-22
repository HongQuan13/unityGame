using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Image maleOption, femaleOption, burnFatOption, fitterOption, massOption;
    [SerializeField] private Image monOption, tueOption, wedOption, thuOption, friOption, satOption, sunOption;
    [SerializeField] private GameObject monTable, tueTable, wedTable, thuTable, friTable, satTable, sunTable;
    [SerializeField] private GameObject monTotal, tueTotal, wedTotal, thuTotal, friTotal, satTotal, sunTotal;

    private Dictionary<string, (Image option, GameObject table, GameObject total)> optionsMapping;

    private float transparentAlpha = 0.1f;
    private float opaqueAlpha = 0.7f;

    private void Awake()
    {
        // Initialize the mapping
        optionsMapping = new Dictionary<string, (Image, GameObject, GameObject)>
        {
            {"Mon", (monOption, monTable, monTotal)},
            {"Tue", (tueOption, tueTable, tueTotal)},
            {"Wed", (wedOption, wedTable, wedTotal)},
            {"Thu", (thuOption, thuTable, thuTotal)},
            {"Fri", (friOption, friTable, friTotal)},
            {"Sat", (satOption, satTable, satTotal)},
            {"Sun", (sunOption, sunTable, sunTotal)}
        };

        DisableFutureDays();
    }

    public void LoadSceneByName(string sceneName) => SceneManager.LoadScene(sceneName);

    public void LoadNextBuild() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

     public void SetToPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Call this method when the "Set to Landscape" button is clicked
    public void SetToLandscape()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft; // Or LandscapeRight, depending on your preference
    }
    private void OnApplicationQuit()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        // Additionally, you might want to set which orientations are allowed if you've changed these at runtime.
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
    }
    public void OnGenderOptionClicked(Image selectedOption)
    {
        SetTransparency(maleOption, selectedOption == maleOption ? opaqueAlpha : transparentAlpha);
        SetTransparency(femaleOption, selectedOption == femaleOption ? opaqueAlpha : transparentAlpha);
    }

    public void OnGoalOptionClicked(Image selectedOption)
    {
        SetTransparency(burnFatOption, selectedOption == burnFatOption ? opaqueAlpha : transparentAlpha);
        SetTransparency(fitterOption, selectedOption == fitterOption ? opaqueAlpha : transparentAlpha);
        SetTransparency(massOption, selectedOption == massOption ? opaqueAlpha : transparentAlpha);
    }

    public void OnDayOptionClicked(string day)
    {
        foreach (var entry in optionsMapping)
        {
            bool isSelected = entry.Key == day;
            SetTransparency(entry.Value.option, isSelected ? opaqueAlpha : transparentAlpha);
            entry.Value.table.SetActive(isSelected);
            entry.Value.total.SetActive(isSelected);
        }
    }

    private void SetTransparency(Image image, float alpha)
    {
        if (image != null)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }

    private void DisableFutureDays()
    {
        string today = DateTime.Now.DayOfWeek.ToString().Substring(0, 3);
        bool foundToday = false;

        foreach (var day in optionsMapping)
        {
            if (day.Key.Equals(today, StringComparison.OrdinalIgnoreCase))
            {
                foundToday = true;
                SetTransparency(day.Value.option, opaqueAlpha);
                continue;
            }

            if (foundToday)
            {
                // Future days after today
                  if (day.Value.option.gameObject.GetComponent<Button>() != null)
                    {
                        day.Value.option.gameObject.GetComponent<Button>().interactable = false; // Disable button if it exists
                    }
                    day.Value.option.gameObject.SetActive(false); // Make the option invisible and non-interactive
                    day.Value.table.SetActive(false); // Also disable related tables
                    day.Value.total.SetActive(false); // And totals
            }
            else
            {
                // Past days before today
                SetTransparency(day.Value.option, transparentAlpha); 
            }
        }
    }
}
