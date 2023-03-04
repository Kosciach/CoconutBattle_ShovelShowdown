using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPositioner : MonoBehaviour
{
    [SerializeField] Transform _source;
    [SerializeField] Transform _target;



    private void Update()
    {
        Vector3 position = (_source.position + _target.position) / 2;
        transform.position = position;
    }
}
