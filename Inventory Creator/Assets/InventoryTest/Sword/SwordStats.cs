using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStats : MonoBehaviour
{
    public List<SwordParts> SwordBlades = new List<SwordParts>();
    public List<SwordParts> SwordHandles = new List<SwordParts>();
    public List<SwordParts> SwordHilts = new List<SwordParts>();

    public Texture2D[] Blades;
    public Texture2D[] Handles;
    public Texture2D[] Hilts;


    void Start () {
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader("SwordPartStats.txt");
        int blades = 0;
        int handles = 0;
        int hilts = 0;

        while ((line =file.ReadLine()) != null)
        {
            string[] words = line.Split(',');
            if (words[0] == "1")
            {
                SwordBlades.Add(new SwordParts(words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7], words[8], words[9], words[10], words[11], words[12], words[13], words[14], words[15]));
                Debug.Log((SwordBlades[blades].PartName));
                blades++;
            }
            if (words[0] == "2")
            {
                SwordHandles.Add(new SwordParts(words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7], words[8], words[9], words[10], words[11], words[12], words[13], words[14], words[15]));
                Debug.Log((SwordHandles[handles].PartName));
                handles++;
            }
            if (words[0] == "3")
            {
                SwordHilts.Add(new SwordParts(words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7], words[8], words[9], words[10], words[11], words[12], words[13], words[14], words[15]));
                Debug.Log((SwordHilts[hilts].PartName));
                hilts++;
            }
        }

    }
}
