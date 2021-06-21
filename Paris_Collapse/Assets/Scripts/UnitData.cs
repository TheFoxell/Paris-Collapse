using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    public int level;

    public int health;
    public int shield;

    public int damage;
    public int pen;
    public int pre;
    public int cri;

    public int maxHealth;
    public int maxShield;

    public UnitData(Unit unit)
    {
        level = unit.unitLevel;

        health = unit.currentHP;
        shield = unit.currentShield;

        damage = unit.damage;
        pen = unit.pen;
        pre = unit.pre;
        cri = unit.cri;

        maxHealth = unit.maxHP;
        maxShield = unit.maxShield;
    }
}
