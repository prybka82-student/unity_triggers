using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformation : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        //ustawiam wyjsciowy offset na pozycje w relacji do pozycji gracza
        offset = transform.position - player.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        //przesuwam kamere względem gracza
        transform.position = player.transform.position + offset;
    }
}
