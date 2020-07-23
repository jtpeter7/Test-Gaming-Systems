using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHotbar : MonoBehaviour
{
    public GameObject Inventory;
    

    // Update is called once per frame
    void Update()
    {
        for(int x = 0; x < 9; x++)
        {
            transform.GetChild(x).GetComponent<UIItem>().castToSelf(Inventory.transform.GetChild(x).GetComponent<UIItem>());
            transform.GetChild(x).GetComponent<UIItem>().InventDraw();
        }
    }
}
