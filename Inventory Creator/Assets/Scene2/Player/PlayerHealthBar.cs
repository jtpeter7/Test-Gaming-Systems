using UnityEngine;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour
{

    //public int Penetration, PartType, Damage, CritDamage, Durability, SelfDamage;
    public int BleedTime, FireRes, IceSlowRes, DarkRes, LightHealRes;
    public float armor;
    public float CurrentHealth, TotalHealth;
    public float barWidth, barSize, barX,barY, barZ;
    public Material HealthColor, HealthMissingColor;
    public Transform padre;
    public Transform Healthcube;
    private int BleedTimer;

    private Transform Health, HealthMissing;
    

    void Start()
    {
        barWidth = 1;
        barSize = .1f;
        padre = this.gameObject.transform;
        Health = Instantiate(Healthcube, new Vector3(0, 0, 0), Quaternion.identity);
        Health.transform.parent = padre;
        Health.transform.localPosition = new Vector3(barX, barY, barZ);
        Health.transform.localScale = new Vector3(barWidth, barSize, barSize);
        Health.GetComponent<Renderer>().material = HealthColor;

        HealthMissing = Instantiate(Healthcube, new Vector3(0, 0, 0), Quaternion.identity);
        HealthMissing.transform.parent = padre;
        HealthMissing.transform.localPosition = new Vector3(barX, barY, barZ);
        HealthMissing.transform.localScale = new Vector3(barWidth - .01f, barSize/2, barSize/2);
        HealthMissing.GetComponent<Renderer>().material = HealthMissingColor;

    }

    void Update()
    {
        if (BleedTime > 0)
        {
            if (BleedTimer == 0)
            {
                CurrentHealth -= 1;
                BleedTime--;
                BleedTimer = 5;
            }
            BleedTimer--;
        }
        try
        {
            Health.transform.localScale = new Vector3(barWidth - (((TotalHealth - CurrentHealth)*barWidth)/ (100 * barWidth)), barSize, barSize);
        }
        catch { }
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

    public void GetHitOn(int Penetration, int Damage, int CritDamage, int Durability, int SelfDamage, int Bleed, int Fire, int IceSlow, int Dark, int LightHeal)
    {
        BleedTime += Bleed;
        float ratio = (Penetration / armor);
        float FireAspect = Fire / FireRes;
        float IceAspect = IceSlow / IceSlowRes;
        float DarkAspect = Dark / DarkRes;
        float LightAspect = LightHeal / LightHealRes;
        CurrentHealth -= (Damage * ratio)+FireAspect+IceAspect+DarkAspect+LightAspect;

    }

    
}