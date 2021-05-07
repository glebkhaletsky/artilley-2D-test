using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    ToPlayer,
    ToHide
}
public class EnemyScript : MonoBehaviour
{
    public Transform PlayerPoint;
    public Transform HidePoint;

    public float Speed;
    public float StopTime;

    public Direction CurrentDirection;

    public bool IsStoped;


    public Transform RayDown;

    public EnemyGun EnemyGun;
    public bool EnemyShotDone;
    bool _isRedyShot;


    private void Start()
    {
        IsStoped = false;
        HidePoint.parent = null;
        PlayerPoint.parent = null;
    }

    private void Update()
    {
        if (IsStoped == true)
        {
            return;
        }

        RaycastHit hitDown;
        if (Physics.Raycast(RayDown.position, Vector3.down, out hitDown))
        {
            transform.position = hitDown.point;
            Debug.Log(hitDown);
        }

        if (CurrentDirection == Direction.ToHide)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0, 0);
            if (transform.position.x < HidePoint.position.x)
            {
                CurrentDirection = Direction.ToPlayer;
                IsStoped = true;

            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0, 0);
            if (transform.position.x > PlayerPoint.position.x)
            {
                IsStoped = true;
                _isRedyShot = true;
            }
        }

        if (_isRedyShot && IsStoped)
        {
            EnemyGun.EnemyGunActivate();

            Invoke("Shot", 0.5f);

        }
        else
        {
            EnemyGun.EnemyGunDiactivate();
        }
    }

    void Shot()
    {
        EnemyShotDone = true;
        EnemyGun.Shot();
        Invoke("AfterShot", 0.5f);
        Invoke("Hide", 1f);
    }
    void AfterShot()
    {
        EnemyShotDone = false;
        _isRedyShot = false;
        EnemyGun.EnemyGunDiactivate();
    }

    void Hide()
    {
        IsStoped = false;
        CurrentDirection = Direction.ToHide;
    }
}
