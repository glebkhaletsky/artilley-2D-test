using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveToggle : MonoBehaviour
{
    public List<Toggle> Toggles = new List<Toggle>();
    private int _currentIndex;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Index"))
        {
            PlayerPrefs.SetInt("Index", 0);
        }
        _currentIndex = PlayerPrefs.GetInt("Index");

        for (int i = 0; i < Toggles.Count; i++)
        {
            if (i == _currentIndex)
            {
                Toggles[i].isOn = true;
            }
            else
            {
                Toggles[i].isOn = false;
            }
        }
    }
}
