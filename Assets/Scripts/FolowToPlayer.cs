using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowToPlayer : MonoBehaviour
{
    public Transform Player;
    public float SpeedLerp;

    bool _map;
    private void Update()
    {
        if (_map)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), Time.deltaTime * SpeedLerp);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Player.position, Time.deltaTime * SpeedLerp);
        }
        
    }

    public void Map()
    {
        _map = !_map;
    }
}
