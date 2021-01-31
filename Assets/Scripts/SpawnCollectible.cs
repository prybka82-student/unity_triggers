using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    private Terrain board; //plansza (teren), na ktorej maja sie pojawiac collectibles
    private Vector3 boardSize;

    public Transform red; //czerwona kostka
    public Transform blue; //niebieska kostka
    public Transform green; //zielona kostka
    public Transform white; //biala kostka

    public int howManyReds = 10;
    public int howManyBlues = 10;
    public int howManyGreens = 10;
    public int howManyWhites = 10;


    // Start is called before the first frame update
    void Start()
    {
        //znajdz teren
        board = Terrain.FindObjectOfType<Terrain>();

        //pobierz rozmiar planszy    
        boardSize = board.terrainData.size;

        //generuje collectibles
        SpawnGameObject(red.gameObject,     howManyReds,    boardSize, transform, "RedCollectible_#");     
        SpawnGameObject(green.gameObject,   howManyGreens,  boardSize, transform, "GreenCollectible_#");     
        SpawnGameObject(blue.gameObject,    howManyBlues,   boardSize, transform, "BlueCollectible_#");     
        SpawnGameObject(white.gameObject,   howManyWhites,  boardSize, transform, "WhiteCollectible_#");     
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnGameObject(GameObject model, int howMany, Vector3 maxPosition, Transform parent, string namePattern = "", string namePatternNumberPlaceholder = "#")
    {
        for (int i = 0; i < howMany; i++)
        {
            var newPosition = GetRandomPosition(maxPosition);

            var newObject = Instantiate(model, newPosition, Quaternion.identity, parent);

            if (namePattern != "")
                newObject.name = namePattern.Replace(namePatternNumberPlaceholder, (i+1).ToString());
        }
    }

    Vector3 GetRandomPosition(Vector3 maxPosition) => GetRandomPosition(maxPosition, Vector3.zero);

    Vector3 GetRandomPosition(Vector3 maxPosition, Vector3 minPosition)
    {
        var x = Random.Range(minPosition.x, maxPosition.x);
        var y = 0.5f;
        var z = Random.Range(minPosition.z, maxPosition.z);

        return new Vector3(x, y, z);
    }
}
