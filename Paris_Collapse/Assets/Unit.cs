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

	public int pen;
	public int pre;
	public int cri;



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
			pen = player.pen;
			pre = player.pre;
			cri = player.cri;
		}
	}

	void Update()
	{
		player.health = currentHP;
		player.shield = currentShield;
	}

	public bool TakeDamage(int dmg)
	{
		float rdm = Random.Range(0f, 100f);
		if (rdm < cri)
			dmg += dmg;



		if (currentShield != 0 && currentShield < dmg+(pen/4))
		{
			currentShield = 0;
			dmg -= currentShield;
			currentHP -= dmg;
		}
		if (currentShield != 0 && currentShield >= dmg+(pen/4))
			currentShield -= dmg+(pen/4);
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
