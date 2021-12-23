using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationHandler : MonoBehaviour
{
    public static string CurrentLanguage()
    {
        return LocalizationSettings.SelectedLocale.ToString();
    }
}