using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public List<Renderer> PlayerRenderers = new List<Renderer>();
    public Text PlayerName;
    public Text EditorPlayerName;
    private string _currentName;
    
    public void SetMaterial (Material material)
    {
        for (int i = 0; i < PlayerRenderers.Count; i++)
        {
            PlayerRenderers[i].material = material;
        }
    }

    public void SetName(string name)
    {
        PlayerName.text = name;
    }

    public void SaveName()
    {
        _currentName = EditorPlayerName.text;
        PlayerPrefs.SetString("Name", _currentName);
    }
}
