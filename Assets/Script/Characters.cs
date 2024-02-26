using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CharacterState
{
    public float maxHP;
    public float currentHP;
    public float MaxMP;
    public float currentMP;
    public float str;
    public float def;
    public float cp;
    public float cd;

}

public class Characters : MonoBehaviour
{
    [SerializeField] protected CharacterState state;
    Animator _anim = null;

    protected Animator myAnim
    {
        get
        {
            if (_anim == null)
            {
                _anim = GetComponent<Animator>();
                if (_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();
                }
            }
            return _anim;
        }
    }
}
