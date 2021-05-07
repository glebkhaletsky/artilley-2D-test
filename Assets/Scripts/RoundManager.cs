using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public float TimeRound=60f;
    public PlayerMove PlayerMove;
    public Aim Aim;
    public bool PlayerTurn;
    private float _defaultTimeRound;

    public EnemyScript Enemy;

    public PhysicMaterial PlayerPhysicMaterial;

    public Text TimeText;
    public Text RoundText;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    private bool _gameOver;
    private void Start()
    {
        _defaultTimeRound = TimeRound;
        NewRound();
    }

    private void Update()
    {
        if (!_gameOver)
        {
            TimeRound -= Time.deltaTime;
            if (TimeRound <= 0)
            {
                NewRound();
                TimeRound = _defaultTimeRound;
            }

            if (Aim.ShotDone)
            {
                ToHide();
            }
            if (Enemy.EnemyShotDone)
            {
                TimeRound = 5f;
            }


            TimeText.text = TimeRound.ToString("00");
        }
        
    }

    public void ToHide()
    {
        TimeRound = 5f;
        Aim.enabled = false;
    }
    public void NewRound()
    {
        
        PlayerTurn = !PlayerTurn;
        if (PlayerTurn)
        {
            RoundText.text = "Ваш ход!";
            PlayerPhysicMaterial.dynamicFriction = 0f;
            PlayerMove.enabled = true;
            Aim.enabled = true;
            if (Enemy != null)
            {
                Enemy.enabled = false;
            }
        }
        else
        {
            if(Enemy != null)
            {
                RoundText.text = "Ход соперника!";
                PlayerPhysicMaterial.dynamicFriction = 10f;
                PlayerMove.enabled = false;
                Aim.enabled = false;
                Enemy.enabled = true;
                Enemy.IsStoped = false;
            }
        }        
    }

    public void PlayerDie()
    {
        _gameOver = true;
        Enemy.enabled = false;
        LoseScreen.SetActive(true);
        RoundText.text = null;
        TimeText.text = null;
    }
    public void EnemyDie()
    {
        _gameOver = true;
        PlayerMove.enabled = false;
        WinScreen.SetActive(true);
        RoundText.text = null;
        TimeText.text = null;
    }



}
