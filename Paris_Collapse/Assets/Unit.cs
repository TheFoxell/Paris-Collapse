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


	void Start()
	{
		if (player != null)
		{
			unitName = player.name;
			unitLevel = player.level;
			currentHP = player.health;
		}
	}

	void Update()
	{
		player.health = currentHP;
	}

	public bool TakeDamage(int dmg)
	{
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
