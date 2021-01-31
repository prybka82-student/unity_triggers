using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSmoothingFactor = 1;

    public float lookUpMax = 60;
    public float lookUpMin = -60;

    private Quaternion _camRotation;
    
    private float _mouseY;
    private float _mouseX;

    // Start is called before the first frame update
    void Start()
    {
        _camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _camRotation.x += _mouseY * cameraSmoothingFactor * -1;
        _camRotation.y += _mouseX * cameraSmoothingFactor;

        _camRotation.x = Mathf.Clamp(_camRotation.x, lookUpMin, lookUpMax);

        transform.localRotation = Quaternion.Euler(_camRotation.x, _camRotation.y, _camRotation.z);
    }
}
