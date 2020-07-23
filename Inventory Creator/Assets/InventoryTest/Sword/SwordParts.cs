using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordParts : MonoBehaviour {

    public string PartName;
    public int Penetration, PartType, Damage, CritDamage, Durability, Bleed, Fire, IceSlow, SelfDamage, Dark, LightHeal, KnockBack;
    public float SwingSpeed, CritChance;

	
	public SwordParts(string a, string b, string c, string d, string q, string e, string f, string g, string h, string i, string j, string k, string l, string m, string n, string o)
    {
        PartType = Convert.ToInt16(a);
        PartName = b;
        Damage = Convert.ToInt16(c);
        SwingSpeed = float.Parse(d);
        Penetration = Convert.ToInt16(q);
        CritChance = float.Parse(e);
        CritDamage = Convert.ToInt16(f);
        Durability = Convert.ToInt16(g);
        Bleed = Convert.ToInt16(h);
        Fire = Convert.ToInt16(i);
        IceSlow = Convert.ToInt16(j);
        SelfDamage = Convert.ToInt16(k);
        Dark = Convert.ToInt16(l);
        LightHeal = Convert.ToInt16(m);
        KnockBack = Convert.ToInt16(n);
    }
}
