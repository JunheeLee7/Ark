using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Skills : ScriptableObject
{
    public float baseDamage;

    public float calculateDamage(float t)
    {
        return baseDamage + t;
    }

    public float cooltime;

    public float buffTime;
    public float buffSt;

    public string animName;

    public Sprite icon;
}
