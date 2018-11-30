using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Spell{

    [SerializeField]
    private String name;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float castTime;

    [SerializeField]
    private GameObject spellPrefab;

    [SerializeField]
    private Color barColor;

    public string Name
    {
        get
        {
            return name;
        }

    }

    public int Damage
    {
        get
        {
            return damage;
        }

    }

    public float Speed
    {
        get
        {
            return speed;
        }

    }

    public float CastTime
    {
        get
        {
            return castTime;
        }

    }

    public GameObject SpellPrefab
    {
        get
        {
            return spellPrefab;
        }

    }

    public Color BarColor
    {
        get
        {
            return barColor;
        }
    }
}
