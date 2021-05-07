using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;
    public float MaxSpeed;

    public Transform Capsule;
    public Camera Camera;

    private float _defaultMoveSpeed;

    private float _clicked = 0;
    private float _clicktime = 0;
    private float _clickdelay = 0.5f;

    private void Start()
    {
        _defaultMoveSpeed = MoveSpeed;
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        float speedMultiplier = 1f;
        RaycastHit hit;

        if (!Grounded)
        {
            speedMultiplier = 0.3f;
            if (Rigidbody.velocity.x > MaxSpeed && Input.GetMouseButton(0))
            {
                speedMultiplier = 0f;

            }
            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetMouseButton(0))
            {
                speedMultiplier = 0f;
            }
        }


        if (Grounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0f, 0f, ForceMode.VelocityChange);
        }
        if(Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Player")
                {
                    MoveSpeed = 0f;
                }
            }
            else
            {
               MoveSpeed = _defaultMoveSpeed;
            }
            if(Input.mousePosition.x < Screen.width / 2f)
            {
                Rigidbody.AddForce(-1f * MoveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
            }
            if (Input.mousePosition.x > Screen.width / 2f)
            {
                Rigidbody.AddForce(1f * MoveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
            }

        }

    }
    private void Update()
    {
        if (DoubleClick())
        {
            if (Grounded)
            {
                Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
            {
                Grounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }

    bool DoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clicked++;
            if (_clicked == 1) _clicktime = Time.time;
        }
        if (_clicked > 1 && Time.time - _clicktime < _clickdelay)
        {
            _clicked = 0;
            _clicktime = 0;
            return true;
        }
        else if (_clicked > 2 || Time.time - _clicktime > 1) _clicked = 0;
        return false;
    }
}
