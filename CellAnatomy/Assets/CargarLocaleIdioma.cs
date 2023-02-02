using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class CargarLocaleIdioma : MonoBehaviour
{
  
    private bool active = false;
    public Toggle localToggle;
    public int localeID;
    public Locale[] localesArray;

    private void Start()
    {
     
        //ChangeLocale();
    }
    public void ChangeLocale()
    {
        if (localToggle.isOn == true)
        {
            Debug.Log("LOCAL TOGGLE ON" + localToggle.name);
            if (active == true)
                return;
            StartCoroutine(SetLocale(localeID));
        }   

    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }


}
