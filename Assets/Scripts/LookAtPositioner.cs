using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPositioner : MonoBehaviour
{
    [SerializeField] Transform _source;
    [SerializeField] Transform _target;



    private void Update()
    {
        float distance = Vector3.Distance(_source.position, _target.position);
        transform.position = _source.position - _source.forward * (distance / 2);
    }
}
