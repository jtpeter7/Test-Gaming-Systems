using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AllItemImages : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();
    public GameObject Inventory;

    public void Start()
    {
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader("Assets/InventoryTest/Items.txt");

        while ((line = file.ReadLine()) != null)
        {
            string[] words = line.Split('\t');
            Item squid = new Item();
            squid.ID = Convert.ToInt16(words[0]);
            squid.SubID = Convert.ToInt16(words[1]);
            squid.ItemName = words[2];
            squid.maxStack = Convert.ToInt16(words[3]);
            squid.TextureName = words[4];
            squid.Description = words[5];
            squid.Image = Resources.Load<Texture2D>(squid.TextureName);
           /* try
            {
                var tempImage = Resources.Load<Sprite>(squid.TextureName);
                Texture2D cropped = new Texture2D((int)tempImage.rect.width,
                    (int)tempImage.rect.height);
                var pixels = tempImage.texture.GetPixels((int)tempImage.textureRect.x,
                                         (int)tempImage.textureRect.y,
                                         (int)tempImage.textureRect.width,
                                         (int)tempImage.textureRect.height);
                cropped.SetPixels(pixels);
                cropped.Apply();
                squid.Image = cropped;
                //Debug.Log("help" + squid.ID + ":" + squid.SubID);
            }
            catch { }*/
            squid.width = Convert.ToDouble(words[6]);
            //squid.PrintName();
            ItemList.Add(squid);
        }
    }

    public void UpdateInventory()
    {

    }
}
