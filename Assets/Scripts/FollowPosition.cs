using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [Tooltip("Specify an offset to apply to the position")]
    [SerializeField]
    private Vector3   _offset;

    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public Vector3 Offset
    {
        get { return _offset; }
        set { _offset = value; }
    }

    private void Update()
    {
        transform.position = _target.position + _offset;
    }

}
