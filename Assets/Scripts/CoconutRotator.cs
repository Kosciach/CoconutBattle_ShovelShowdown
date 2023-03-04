using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutRotator : MonoBehaviour
{
    [SerializeField] Transform _target;




    private void Update()
    {
        RotateToTarget();
    }
    public void RotateToTarget()
    {
        transform.LookAt(2 * transform.position - _target.position);
    }
}
