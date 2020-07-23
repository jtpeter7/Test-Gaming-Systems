using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int PI_ID;

    public int ID;
    public int SubID;
    public string ItemName;
    public int maxStack;
    public string TextureName;
    public string Description;
    public Texture2D Image;
    public double width;

    public int count;

    public GameObject Database;
    public Transform ItemPiece;
    private int counter = 1;
    private int scale = 16;
    private void Start()
    {
        Database = GameObject.Find("PlayerCollider");
        PI_ID = Database.GetComponent<Inventory>().PI_ID;
        Database.GetComponent<Inventory>().PI_ID++;
    }
    void DOIT()
    {
        for (int x = 0; x < Database.GetComponent<AllItemImages>().ItemList.Count;x++)
        {
            Item temp = Database.GetComponent<AllItemImages>().ItemList[x];
            if (gameObject.name == temp.ItemName)
            {
                ID = temp.ID;
                SubID = temp.SubID;
                ItemName = temp.ItemName;
                maxStack = temp.maxStack;
                TextureName = temp.TextureName;
                Description = temp.Description;
                Image = temp.Image;
                width = temp.width;
                break;
            }
        }
        transform.GetChild(1).GetComponent<Gen3DItem>().Generate(Image, scale);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0)
        {
            counter--;
        }else if (counter == 0)
        {
            DOIT();
            counter = -1;
        }
        if(count <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PrintName()
    {
        print(ItemName);
    }

    public UIItem toUIItem()
    {
        UIItem newUI = new UIItem();
        newUI.ID = ID;
        newUI.SubID = SubID;
        newUI.ItemName = ItemName;
        newUI.maxStack = maxStack;
        newUI.TextureName = TextureName;
        newUI.Description = Description;
        newUI.Image = Image;
        newUI.width = width;
        newUI.count = count;
        return newUI;
    }
}
