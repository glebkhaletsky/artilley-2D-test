using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }
}
