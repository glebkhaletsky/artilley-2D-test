using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera Camera;
    public PlayerMove PlayerMove;
    public AimPoint AimPoint;

    public GameObject AimPointer;
    public float _timer = 1f;

    public GameObject Gun;
    private bool _isShot;

    public bool ShotDone;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnPressPlayer();
        }
        else
        {
            _timer = 1f;
        }


        if (_timer <= 0)
        {
            AimPointer.SetActive(true);
            PlayerMove.enabled = false;
            Gun.SetActive(true);
            _isShot = true;

        }
        else
        {
            if (Input.GetMouseButtonUp(0) && _isShot)
            {
                ShotDone = true;
                Gun.gameObject.GetComponentInChildren<Gun>().Shot();
                Invoke("AfterShot", 0.5f);
            }
        }
    }
    public void OnPressPlayer()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 5f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Player")
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    void AfterShot()
    {
        ShotDone = false;
        _isShot = false;
        Gun.SetActive(false);
        PlayerMove.enabled = true;
        AimPointer.SetActive(false);
    }
}
