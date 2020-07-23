using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Sprites : MonoBehaviour
{
    public Sprite Sprite;
    public Sprite[] SpriteList;
    public int count;

    // Update is called once per frame
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = SpriteList[count];
    }
    public void Next()
    {
        count++;
        if (count >= SpriteList.Length)
        {
            count = 0;
        }
        gameObject.GetComponent<Image>().sprite = SpriteList[count];
    }
    public void Previous()
    {
        count--;
        if (count < 0)
        {
            count = SpriteList.Length-1;
        }
        gameObject.GetComponent<Image>().sprite = SpriteList[count];
    }
}
