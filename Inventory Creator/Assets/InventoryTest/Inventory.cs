using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public int PI_ID = 0;
    public bool UI = false;
    public GameObject UIInventory,Shader;
    public static List<UIItem> UIItems = new List<UIItem>() {
    null,null,null,null,null,null,null,null,null,
        null,null,null,null,null,null,null,null,null,
        null,null,null,null,null,null,null,null,null,
        null,null,null,null,null,null,null,null,null
    };
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UI = !UI;
            if (UI)
            {
                UpdateInventory();
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            pickUpItem(collision);
            UpdateInventory();
        }
    }

    void pickUpItem(Collider collision)
    {
        int tempcount = collision.gameObject.GetComponent<Item>().count;
        int tempMax = collision.gameObject.GetComponent<Item>().maxStack;
        bool found = true;
        for (int z = 0; z < 36; z++)
        {
            if (UIInventory.transform.GetChild(z).GetComponent<UIItem>().ItemName == collision.gameObject.name && 
                UIInventory.transform.GetChild(z).GetComponent<UIItem>().count != UIInventory.transform.GetChild(z).GetComponent<UIItem>().maxStack)
            {
                if (UIInventory.transform.GetChild(z).GetComponent<UIItem>().count + tempcount
                    <= tempMax)
                {
                    //case for if it should stack into inventory without taking up a new spot.
                    UIInventory.transform.GetChild(z).GetComponent<UIItem>().count += tempcount;
                    Destroy(collision.gameObject);
                    //Debug.Log("1");
                    found = false;
                    break;
                }
                else
                {
                    //Debug.Log("2");
                    int temp = UIInventory.transform.GetChild(z).GetComponent<UIItem>().count;
                    UIInventory.transform.GetChild(z).GetComponent<UIItem>().count = tempMax;
                    collision.gameObject.GetComponent<Item>().count =
                          tempcount
                        + temp
                        - tempMax;
                    break;
                }
            }
        }
        if (found)//case for if that item does not exist in a noncomplete stack in the inventory;
        {
            //Debug.Log("3");
            for (int z = 0; z < 36; z++)
            {
                if (UIInventory.transform.GetChild(z).GetComponent<UIItem>().ItemName == "")
                {
                    UIItems[z] = collision.GetComponent<Item>().toUIItem();
                    UIInventory.transform.GetChild(z).GetComponent<UIItem>().castToSelf(UIItems[z]);
                    Destroy(collision.gameObject);
                    break;
                }
            }
        }
    }
    void printInventory()
    {
        Debug.ClearDeveloperConsole();
        string output="";
        for(int x = 3; x >= 0; x--)
        {
            for(int z = 0; z < 9; z++)
            {
                //output += invSlot[(x * 9) + z] + "(" + invCount[(x*9)+z] + ")" + "\t";
                output += UIItems[(x * 9) + z].name + "(" + UIItems[(x * 9) + z].count + ")" + "\t";
            }
            //output += "\n";
            Debug.Log(output);
            output = "";
        }
    }

    void UpdateInventory()
    {
        for(int x = 0; x < 36; x++)
        {

            UIInventory.transform.GetChild(x).GetComponent<UIItem>().InventDraw();
            /*//UIInventory.transform.GetChild(x).GetComponent<RawImage>().texture = invImages[x];
            if (invSlot[x] != "")
            {
                UIInventory.transform.GetChild(x).GetChild(0).GetComponent<Text>().text = invCount[x].ToString();
            }
            else
            {
                UIInventory.transform.GetChild(x).transform.GetChild(0).GetComponent<Text>().text = "";
            }*/
        }
    }

}
