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
                SetTransparency(day.Value.option, transparentAlpha);
                // day.Value.option.SetActive(false);
                day.Value.table.SetActive(false);
                day.Value.total.SetActive(false);
            }
            else
            {
                // Past days before today
                SetTransparency(day.Value.option, transparentAlpha); // Past days are transparent but not disabled
            }
        }
    }
}
