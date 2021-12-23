using UnityEngine;
using UnityEngine.UI;

public class ResourcesHandler : MonoBehaviour
{
    /// <summary>
    /// Returns the specific line from the text file in the Resources folder
    /// </summary>
    public static string GetLine(string path, int line)
    {
       TextAsset textFile = (TextAsset)Resources.Load(path);

        string[] lines = textFile.text.Split('\n');
        return lines[line];
    }

    /// <summary>
    /// Returns the specific image in the Resources folder
    /// </summary>
    public static Sprite GetSprite(string path)
    {
        Sprite spriteFile = Resources.Load<Sprite>(path);
        return spriteFile;
    }

}