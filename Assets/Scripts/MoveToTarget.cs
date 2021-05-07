using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        if (Target != null)
        {
            transform.position = Target.position;
        }
        
        
    }
}
