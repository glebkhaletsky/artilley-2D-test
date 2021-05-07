using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private float _defaultValue;
    private float _zoomValue;
    private bool _zoom;

    private void Start()
    {
        _defaultValue = transform.position.z;
        _zoomValue = _defaultValue - 10f;
    }
    public void ZoomMap()
    {
        _zoom = !_zoom;
    }

    private void Update()
    {
        if (_zoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, _zoomValue),Time.deltaTime * 10f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, _defaultValue), Time.deltaTime * 10f);
        }
    }
}
