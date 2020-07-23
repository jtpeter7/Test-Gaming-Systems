using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateLevel : MonoBehaviour
{
    Color White = new Color(0, 0, 0);
    Color red = new Color(255, 0, 0);
    Color Light_Blue = new Color(0, 255, 255);
    Color Orange = new Color(255, 106, 0);
    Color Lime = new Color(0,255, 33);
    Color Pink = new Color(255,127,182);
    Color Gray = new Color(64,64,64);
    Color Light_Gray = new Color(128, 128, 128);
    Color Purple = new Color(125,0,183);
    Color Brown = new Color(127,51,0);
    struct Doors
    {
        public bool North, East, South, West, corner, wall;
        public int RoomType, numOfDoors;
    }
    public Transform Test;
    public int size;
    Doors[,] array;
    void Start()
    {
        System.Random r = new System.Random();
        //Random.InitState(255);
        array = new Doors[size, size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                //Debug.Log("Count");
                if ((x == 0 || x == size - 1) && (y == 0 || y == size - 1))
                {
                    array[x, y].corner = true;
                }
                else
                {
                    array[x, y].corner = false;
                }
                if ((x == 0 || x == size - 1 || y == 0 || y == size - 1) && !array[x, y].corner)
                {
                    array[x, y].wall = true;
                }
                else
                {
                    array[x, y].wall = false;
                }
                genDoors(x, y);


                array[x, y].RoomType = r.Next(0, 16);
            }
        }
        array[(size - 1) / 2, (size - 1) / 2].RoomType = 0;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                remove_doors(x, y);
                //Debug.Log("Write");
                if (array[x, y].numOfDoors != 0)
                {
                    Transform cube = Instantiate(Test, new Vector3(0, 0, 0), Quaternion.identity);
                    cube.transform.parent = transform;
                    cube.transform.rotation = transform.rotation;
                    cube.transform.localPosition = new Vector3(x, 0, -y);
                    cube.GetComponent<Room>().North = array[x, y].North;
                    cube.GetComponent<Room>().East = array[x, y].East;
                    cube.GetComponent<Room>().South = array[x, y].South;
                    cube.GetComponent<Room>().West = array[x, y].West;
                    cube.GetComponent<Room>().roomNumber = array[x, y].RoomType;
                    switch (array[x, y].RoomType)
                    {
                        case 0: cube.GetComponent<Renderer>().material.SetColor("_Color", red); break;
                        case 1: cube.GetComponent<Renderer>().material.SetColor("_Color", Color.green); break;
                        case 2: cube.GetComponent<Renderer>().material.SetColor("_Color", Color.blue); break;
                        case 3: cube.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); break;
                        case 4: cube.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan); break;
                        case 5: cube.GetComponent<Renderer>().material.SetColor("_Color", Color.black); break;
                        case 6: cube.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta); break;
                        case 7: cube.GetComponent<Renderer>().material.SetColor("_Color", White); break;
                        case 8: cube.GetComponent<Renderer>().material.SetColor("_Color", Light_Blue); break;
                        case 9: cube.GetComponent<Renderer>().material.SetColor("_Color", Orange); break;
                        case 10: cube.GetComponent<Renderer>().material.SetColor("_Color", Lime); break;
                        case 11: cube.GetComponent<Renderer>().material.SetColor("_Color", Pink); break;
                        case 12: cube.GetComponent<Renderer>().material.SetColor("_Color", Gray); break;
                        case 13: cube.GetComponent<Renderer>().material.SetColor("_Color", Light_Gray); break;
                        case 14: cube.GetComponent<Renderer>().material.SetColor("_Color", Purple); break;
                        case 15: cube.GetComponent<Renderer>().material.SetColor("_Color", Brown); break;
                        default: break;
                    }
                }
            }
        }
    }

    void genDoors(int x, int y)
    {
        int chance = 4;
        //Debug.Log("Door");
        int t1, t2, t3, t4;
        t1 = UnityEngine.Random.Range(0, chance);
        if (t1 == 1 && y != 0)
        {
            array[x, y].North = true;
            array[x, y].numOfDoors++;
            try
            {
                array[x, y - 1].South = true;
                array[x, y - 1].numOfDoors++;
            }
            catch { }
        }
        t2 = UnityEngine.Random.Range(0, chance);
        if (t2 == 1 && x != size - 1)
        {
            array[x, y].East = true;
            array[x, y].numOfDoors++;
            try
            {
                array[x + 1, y].West = true;
                array[x + 1, y].numOfDoors++;
            }
            catch { }
        }
        t3 = UnityEngine.Random.Range(0, chance);
        if (t3 == 1 && y != size - 1)
        {
            array[x, y].South = true;
            array[x, y].numOfDoors++;
            try
            {
                array[x, y + 1].North = true;
                array[x, y + 1].numOfDoors++;
            }
            catch { }
        }
        t4 = UnityEngine.Random.Range(0, chance);
        if (t4 == 1 && x != 0)
        {
            array[x, y].West = true;
            array[x, y].numOfDoors++;
            try
            {
                array[x - 1, y].East = true;
                array[x - 1, y].numOfDoors++;
            }
            catch { }
        }
        if (x == 0)
        {
            array[x, y].West = false;
        }
        if (x == size - 1)
        {
            array[x, y].East = false;
        }
        if (y == 0)
        {
            array[x, y].North = false;
        }
        if (y == size - 1)
        {
            array[x, y].South = false;
        }
        if (array[x, y].numOfDoors <= 1)
        {
            //Debug.Log("Again");
            genDoors(x, y);
        }
        
    }
    void remove_doors(int x,int y)
    {
        int t5;
        if (array[x, y].numOfDoors == 4)
        {
            t5 = UnityEngine.Random.Range(0, 5);
            
            switch (t5)
            {
                case 0:
                    array[x, y].North = false; array[x, y].numOfDoors--;try { array[x, y - 1].South = false; array[x, y - 1].numOfDoors--; } catch { }
                    break;
                case 1:
                    array[x, y].East = false; array[x, y].numOfDoors--; try
                    {
                        array[x, y - 1].West = false; array[x + 1, y].numOfDoors--;
                    }
                    catch { }
                    break;
                case 2:
                    array[x, y].South = false; array[x, y].numOfDoors--; try
                    {
                        array[x, y - 1].North = false; array[x, y + 1].numOfDoors--;
                    }
                    catch { }
                    break;
                case 3:
                    array[x, y].West = false; array[x, y].numOfDoors--; try
                    {
                        array[x, y - 1].East = false; array[x - 1, y - 1].numOfDoors--;
                    }
                    catch { }
                    break;
                default:
                    break;
            }
        }
    }
}
