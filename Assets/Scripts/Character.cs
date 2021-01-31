using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    const string walkPropertyName = "_walkForward";
    private const string walkBackwardPropertyName = "_walkBackward";

    private float _forwardInput;
    private float _rightInput;

    private Vector3 _velocity;
    private Vector3 _rotation;

    public bool Walk = false;

    public float MovementSpeed = 0.125f;
    public float RotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_velocity);
        transform.Rotate(_rotation);
    }

    public void AddMovementInput(float forward)
    {
        _forwardInput = forward;

        var translation = new Vector3(0, 0, forward * MovementSpeed);

        if (translation.magnitude > 0)
        {
            _velocity = translation;
            Walk = true;

            if (forward > 0)
                startWalking();
            else
                startWalkingBackwards();
        }
        else
        {
            _velocity = Vector3.zero;
            Walk = false;

            stopWalking();
            stopWalkingBackwards();
        }
    }

    public void AddRotationInput(float right)
    {
        _rightInput = right;

        var translation = new Vector3(0, right * RotationSpeed, 0);

        if (translation.magnitude > 0)
            _rotation = translation;
        else
            _rotation = Vector3.zero;
    }

    void enableAnimationProperty(string propertyName) => transform.GetComponent<Animator>().SetBool(propertyName, true);
    void disableAnimationProperty(string propertyName) => transform.GetComponent<Animator>().SetBool(propertyName, false);

    void startWalking() => enableAnimationProperty(walkPropertyName);
    void stopWalking() => disableAnimationProperty(walkPropertyName);

    void startWalkingBackwards() => enableAnimationProperty(walkBackwardPropertyName);
    void stopWalkingBackwards() => disableAnimationProperty(walkBackwardPropertyName);
}
