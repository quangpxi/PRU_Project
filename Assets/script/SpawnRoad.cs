using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    public GameObject[] roads;
    public GameObject[] background;
    GameObject road;
    GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < roads.Length; i++)
        {
            createBackground(i);
            createRoad(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void createRoad(int i)
    {
        road = Instantiate(roads[i], roads[i].transform.localPosition, Quaternion.identity);
        road.GetComponent<RoadMove>().background = bg;
    }

    void createBackground(int i)
    {
        bg = Instantiate(background[i], roads[i].transform.localPosition, Quaternion.identity);
        if (roads[i].tag == "highway")
        {
            bg.transform.localPosition += new Vector3(0, 2, 0);
            Debug.Log(bg.transform.localPosition);
        }
    }
}
