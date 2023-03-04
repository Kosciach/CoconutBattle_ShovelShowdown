using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraFollowPointMover : MonoBehaviour
{
    [SerializeField] Vector3 _moveTarget;
    [Range(0,2)]
    [SerializeField] float _moveSpeed;
    [SerializeField] AnimationCurve _moveCurve;

    private void MoveCameraHolder()
    {
        transform.LeanMoveLocal(_moveTarget, _moveCurve.Evaluate(_moveSpeed));
    }

    private void OnEnable()
    {
        CanvasController.StartGame += MoveCameraHolder;
    }
    private void OnDisable()
    {
        CanvasController.StartGame -= MoveCameraHolder;
    }
}
