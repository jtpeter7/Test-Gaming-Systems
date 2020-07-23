using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousSprite : MonoBehaviour
{
    GameObject Sprite;
    private void Start()
    {
        Sprite = transform.parent.gameObject;

    }
    public void PREVIOUS()
    {
        Sprite.GetComponent<Sprites>().Previous();
    }
}
