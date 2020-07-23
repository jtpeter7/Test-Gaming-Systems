using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform Door;
    public bool North, East, South, West;
    public int roomNumber;
    void Start()
    {
        if (North)
        {
            Transform cube = Instantiate(Door, new Vector3(0, 0, 0), Quaternion.identity);
            cube.transform.parent = transform;
            cube.transform.rotation = transform.rotation;
            cube.transform.localPosition = new Vector3(0,.5f,.5f);
        }
        if (East)
        {
            Transform cube = Instantiate(Door, new Vector3(0, 0, 0), Quaternion.identity);
            cube.transform.parent = transform;
            cube.transform.rotation = transform.rotation;
            cube.transform.localPosition = new Vector3(.5f, .5f, 0);
        }
        if (South)
        {
            Transform cube = Instantiate(Door, new Vector3(0, 0, 0), Quaternion.identity);
            cube.transform.parent = transform;
            cube.transform.rotation = transform.rotation;
            cube.transform.localPosition = new Vector3(0, .5f, -.5f);
        }
        if (West)
        {
            Transform cube = Instantiate(Door, new Vector3(0, 0, 0), Quaternion.identity);
            cube.transform.parent = transform;
            cube.transform.rotation = transform.rotation;
            cube.transform.localPosition = new Vector3(-.5f, .5f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
