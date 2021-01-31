using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private static string collectiblesLayerName = "Collectibles";
    private LayerMask collectiblesLayer;
    private Color defaultColor;

    //swiatlo w scenie
    public GameObject Light;

    // Start is called before the first frame update
    void Start()
    {
        collectiblesLayer = LayerMask.NameToLayer(collectiblesLayerName);
        defaultColor = Light.GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        //zmiana koloru swiatla
        if (other.gameObject.layer == collectiblesLayer)
            ChangeLight(other);

        //usuniecie doknietego obiektu
        Destroy(other.gameObject);

        //dodanie punktu
        PointController.AddPoint();        
    }

    private void ChangeLight(Collider collider)
    {
        Debug.LogWarning("Collectible found!");

        if (CheckColliderTag(collider, "red"))
            ChangeLightToRed();
        else if (CheckColliderTag(collider, "green"))
            ChangeLightToGreen();
        else if (CheckColliderTag(collider, "blue"))
            ChangeLightToBlue();
        else if (CheckColliderTag(collider, "white"))
            ChangeLightToDefault();
    }

    private bool CheckColliderTag(Collider collider, string tag) => collider.GetComponent<Collider>().CompareTag(tag);

    private void ChangeLightToRed() => Light.GetComponent<Light>().color = Color.red;
    private void ChangeLightToGreen() => Light.GetComponent<Light>().color = Color.green;
    private void ChangeLightToBlue() => Light.GetComponent<Light>().color = Color.blue;
    private void ChangeLightToDefault() => Light.GetComponent<Light>().color = defaultColor;
}
