using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge : MonoBehaviour
{
    public GameObject top, mid, bot, Sizer, forger, play;
    Vector3 temp, holder;
    bool forge = false;
    bool size = false;
    int count = 0;
    // Update is called once per frame
    private void Start()
    {
        holder = Sizer.transform.position;
    }
    void Update()
    {
        if (forge)
        {
            top.transform.position = new Vector3(top.transform.position.x, top.transform.position.y - .5f, top.transform.position.z);
            bot.transform.position = new Vector3(bot.transform.position.x, bot.transform.position.y + .5f, bot.transform.position.z);
            if(top.transform.position.y - mid.transform.position.y < 2)
            {
                top.transform.position = new Vector3(top.transform.position.x, mid.transform.position.y, top.transform.position.z);
                bot.transform.position = new Vector3(bot.transform.position.x, mid.transform.position.y, bot.transform.position.z);
                forge = false;
                size = true;
            }
        }
        if (size)
        {
            top.transform.parent = Sizer.transform;
            mid.transform.parent = Sizer.transform;
            bot.transform.parent = Sizer.transform;
            Sizer.transform.localScale += new Vector3(.02f,.02f,.02f);
            count++;
            if (count == 75)
            {
                size = false;
                Sizer.transform.localScale = new Vector3(2.5f,2.5f,2.5f);
                temp = forger.transform.position;
                forger.transform.position = play.transform.position;
                play.transform.position = temp;
                Sizer.transform.parent = play.transform;
                Sizer.transform.position = holder;
            }
        }
    }

    public void FORGE()
    {
        forge = true;
        top.transform.DetachChildren();
        mid.transform.DetachChildren();
        bot.transform.DetachChildren();
    }
}
