using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStacks : MonoBehaviour
{
    private GameObject theparent;
    private void Start()
    {
        theparent = transform.parent.gameObject;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Item" && collision.gameObject.GetComponentInParent<Item>().PI_ID < gameObject.GetComponentInParent<Item>().PI_ID)
        {
            //Debug.Log("1");
            if (collision.gameObject.name == transform.parent.gameObject.name)
            {
                //Debug.Log("2");
                if ((transform.parent.gameObject.GetComponent<Item>().count == transform.parent.gameObject.GetComponent<Item>().maxStack) ||
                    (collision.gameObject.GetComponent<Item>().count == collision.gameObject.GetComponent<Item>().maxStack))
                {
                    //Debug.Log("3");
                }
                else
                {

                    collision.gameObject.GetComponent<Item>().count += theparent.GetComponent<Item>().count;
                    if (collision.gameObject.GetComponent<Item>().count <= collision.gameObject.GetComponent<Item>().maxStack)
                    {
                        //Debug.Log("4");
                        Destroy(theparent);
                    }
                    else
                    {
                        //Debug.Log("5");

                        theparent.GetComponent<Item>().count = collision.gameObject.GetComponent<Item>().count - collision.gameObject.GetComponent<Item>().maxStack;
                        collision.gameObject.GetComponent<Item>().count = collision.gameObject.GetComponent<Item>().maxStack;

                    }
                }

            }
        }
    }
}
