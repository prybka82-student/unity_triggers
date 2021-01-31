using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    //zdobyte punkty
    private static int _pointsEarned;   

    // Start is called before the first frame update
    void Start()
    {
        _pointsEarned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //kontrolka wyswietlajaca punkty
        GameObject.Find("PointsCounter").GetComponent<Text>().text = _pointsEarned.ToString();
    }

    public static void AddPoint() => AddPoints(1);

    public static void AddPoints(int points) => _pointsEarned += points;
}
