using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class PlayerInput : MonoBehaviour
{
    private Character _character;
    private float _horizontalInput;
    private float _verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); //klawisze a, d
        _verticalInput = Input.GetAxis("Vertical"); //klawisze w, s

        _character
            .AddMovementInput(_verticalInput);

        _character
            .AddRotationInput(_horizontalInput);
    }
}
