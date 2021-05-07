using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSettings : MonoBehaviour
{
    public List<Material> PlayerColors = new List<Material>();
    public List<Renderer> PlayerRenderers = new List<Renderer>();
    public Text PlayerName;
    private Material _currerntMaterial;

    private int _currentIndex;

    private string _currentPlayerName;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Index"))
        {
            PlayerPrefs.SetInt("Index", 0);
        }
        _currentIndex = PlayerPrefs.GetInt("Index");

        if (!PlayerPrefs.HasKey("Name"))
        {
            PlayerPrefs.SetString("Name", "Player");
        }
        _currentPlayerName = PlayerPrefs.GetString("Name");
        PlayerName.text = _currentPlayerName;
        

        for (int i = 0; i < PlayerColors.Count; i++)
        {
            if (i == _currentIndex)
            {
                _currerntMaterial = PlayerColors[i];
                for (int y = 0; y < PlayerRenderers.Count; y++)
                {
                    PlayerRenderers[y].material = _currerntMaterial;
                }

            }
        }

    }
}
