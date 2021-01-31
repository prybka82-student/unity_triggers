using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private const string walkPropertyName = "_walkForward";
    private const string walkBackwardPropertyName = "_walkBackward";

    public bool Walk = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveForward = Input.GetAxis("GoForward");
        float moveBack = Input.GetAxis("GoBack");

        if (moveForward > 0.5f)
        {
            startWalking();
            Walk = true;
        }
        else
        {
            stopWalking();
            Walk = false;
        }

    }

    void enableAnimationProperty(string propertyName) => transform.GetComponent<Animator>().SetBool(propertyName, true);
    void disableAnimationProperty(string propertyName) => transform.GetComponent<Animator>().SetBool(propertyName, false);

    void startWalking() => enableAnimationProperty(walkPropertyName);
    void stopWalking() => disableAnimationProperty(walkPropertyName);

    void startWalkingBackwards() => enableAnimationProperty(walkBackwardPropertyName);
    void stopWalkingBackwards() => disableAnimationProperty(walkBackwardPropertyName);
}
