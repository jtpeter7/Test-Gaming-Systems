using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    public int PlayerIDINT;
    void Start()
    {
        GameObject.Find("PID").GetComponent<GeneratePID>().PID++;
        PlayerIDINT = GameObject.Find("PID").GetComponent<GeneratePID>().PID;
    }

}
