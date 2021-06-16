using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
	public Player player;

	public string unitName;
	public int unitLevel;

	public int damage;

	public int maxHP;
	public int currentHP;
	public int maxShield;
	public int currentShield;


	void Start()
	{
		if (player != null)
		{
			unitName = player.name;
			unitLevel = player.level;
			currentHP = player.health;
			currentShield = player.shield;
			maxShield = player.maxShield;
			damage = player.damage;
		}
	}

	void Update()
	{
		player.health = currentHP;
		player.shield = currentShield;
	}

	public bool TakeDamage(int dmg)
	{
		if (currentShield != 0 && currentShield < dmg)
		{
			currentShield = 0;
			dmg -= currentShield;
			currentHP -= dmg;
		}
		if (currentShield != 0 && currentShield >= dmg)
			currentShield -= dmg;
		else
			currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}
	
}
