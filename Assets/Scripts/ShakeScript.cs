using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    public static ShakeScript Instance;
    [SerializeField] CinemachineVirtualCamera _cmCamera;
    [SerializeField] CinemachineBasicMultiChannelPerlin _noise;

    [Range(0, 10)]
    [SerializeField] float _resetSpeed;
    private float _resetSpeedMultiplier;

    private void Awake()
    {
        _noise = _cmCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        Instance = this;
    }

    private void Update()
    {
        _noise.m_AmplitudeGain = Mathf.Lerp(_noise.m_AmplitudeGain, 0f, _resetSpeed / _resetSpeedMultiplier);
    }


    public void Shake(float amplitude, float time)
    {
        _noise.m_AmplitudeGain = amplitude;
        _resetSpeedMultiplier = time;
    }
}
