using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiggerImage : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = transform.parent.GetChild(0).GetComponent<Image>().sprite;
    }
}
