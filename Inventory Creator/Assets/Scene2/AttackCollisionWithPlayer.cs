using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionWithPlayer : MonoBehaviour
{
    public int Penetration, Damage, CritDamage, Durability, SelfDamage;
    public int Bleed, Fire, IceSlow, Dark, LightHeal;
    public int PID;

   

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerID>().PlayerIDINT != PID)
        {
            try
            {
                collision.gameObject.GetComponent<PlayerHealthBar>().GetHitOn(Penetration, Damage, CritDamage, Durability, SelfDamage, Bleed, Fire, IceSlow, Dark, LightHeal);
                Destroy(gameObject);
            }
            catch { }
        }
    }

}
