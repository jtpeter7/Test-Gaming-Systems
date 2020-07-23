using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Find("Inventory").gameObject.SetActive(false);
        gameObject.transform.Find("Shader").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Inventory>().UI)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            gameObject.transform.Find("Inventory").gameObject.SetActive(true);
            gameObject.transform.Find("Shader").gameObject.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.transform.Find("Inventory").gameObject.SetActive(false);
            gameObject.transform.Find("Shader").gameObject.SetActive(false);
        }

    }
}
