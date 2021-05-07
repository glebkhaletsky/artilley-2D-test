using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointScript : MonoBehaviour
{
    public Transform PlayerPosition;
    public Transform ShelderPosition;

    private void Update()
    {
        if (PlayerPosition.position.x < ShelderPosition.position.x)
        {
            transform.position = new Vector3(PlayerPosition.position.x + 5f, 0f, 0f);
        }
        if (PlayerPosition.position.x > ShelderPosition.position.x)
        {
            transform.position = new Vector3(PlayerPosition.position.x - 5f, 0f, 0f);
        }

    }
}
