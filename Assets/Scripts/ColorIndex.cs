using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndex : MonoBehaviour
{
    public int SetIndex;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Index"))
        {
            PlayerPrefs.SetInt("Index", 0);
        }
        SetIndex = PlayerPrefs.GetInt("Index");
    }
    public void SetColorIndex(int setIndex)
    {
        PlayerPrefs.SetInt("Index", setIndex);
        SetIndex = setIndex;
    }
}
