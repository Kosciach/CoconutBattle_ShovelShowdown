using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarBackgroundPositioner : MonoBehaviour
{
    [SerializeField] Transform _target;


    private void FixedUpdate()
    {
        transform.position = _target.position;
    }
}
