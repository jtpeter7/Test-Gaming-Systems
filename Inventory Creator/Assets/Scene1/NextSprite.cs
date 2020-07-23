using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class NextSprite : MonoBehaviour
{
    GameObject Sprite;
    private void Start()
    {
        Sprite = transform.parent.gameObject;

    }
    public void NEXT()
    {
        Sprite.GetComponent<Sprites>().Next();
    }
}
