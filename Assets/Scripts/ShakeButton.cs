using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeButton : MonoBehaviour
{
    
    void Start()
    {
        transform.DOShakeRotation(3, 20, 10, 20, true).SetLoops(Mathf.RoundToInt(Mathf.Infinity), LoopType.Restart );
    }


}
