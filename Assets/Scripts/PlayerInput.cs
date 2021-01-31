using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class PlayerInput : MonoBehaviour
{
    //referencja do skryptu postaci (klasy Character)
    private Character _character;
    //zmienne określające stopień wciśnięcia klawiszy (do podglądu w trybie Debug)
    private float _horizontalInput;
    private float _verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        //inicjalizacja referencji do obiektu klasy Character
        _character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        //pobranie stopnia wcisniecia klawiszy
        _horizontalInput = Input.GetAxis("Horizontal"); //klawisze a, d
        _verticalInput = Input.GetAxis("Vertical"); //klawisze w, s

        //przeniesienie ruchu
        _character
            .AddMovementInput(_verticalInput);

        //przeniesienie obrotu
        _character
            .AddRotationInput(_horizontalInput);
    }
}
