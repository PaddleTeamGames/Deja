using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;

    [SerializeField] private Material skyboxDay;
    [SerializeField] private Material skyboxNight;
    [SerializeField] private Material skyboxOther;

    Light sun;

    private void Start()
    {
        sun = GetComponent<Light>();
    }

    private void Update()
    {
        if (preset == null)
            return;

        if (Application.isPlaying)
        {

            //timeOfDay += Time.deltaTime;
            LevelHandler.timeOfDay %= 24;
            //UpdateLighting(LevelHandler.timeOfDay / 24f);
            if (LevelHandler.timeOfDay <= 18 && LevelHandler.timeOfDay >= 8)
            {
                RenderSettings.skybox = skyboxDay;
                sun.enabled = true;
                sun.intensity = 2;
                sun.shadowStrength = 0.78f;
            }
            else if (LevelHandler.timeOfDay < 21 && LevelHandler.timeOfDay > 18 || LevelHandler.timeOfDay < 8 && LevelHandler.timeOfDay > 6)
            {
                RenderSettings.skybox = skyboxOther;
                sun.intensity = 1f;
                sun.shadowStrength = 0;
            }
            else
            {
                RenderSettings.skybox = skyboxNight;
                sun.enabled = false;
            }
        }
        else
        {
            //UpdateLighting(LevelHandler.timeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
            directionalLight = RenderSettings.sun;
        else
        {
            Light[] lights = FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
