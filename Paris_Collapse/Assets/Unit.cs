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
	
	public bool saving = true;



	void Start()
	{
		if (player != null)
		{
			unitName = player.name;
			unitLevel = player.level;
			currentHP = player.health;
			maxHP = player.maxHealth;
			currentShield = player.shield;
			maxShield = player.maxShield;
			damage = player.damage;
			pen = player.pen;
			pre = player.pre;
			cri = player.cri;
		}
		else
		{
			LoadUnit();
		}
	}

	void Update()
	{
		if (player != null)
		{
			player.health = currentHP;
			player.shield = currentShield;
		}
		else
		{
			if (currentHP <= 0)
			{
				switch (unitLevel)
				{
					case 1 :
						unitLevel += 24;
						UpLevel();
						break;
					case 25 :
						unitLevel += 25;
						UpLevel();
						break;
					case 50 :
						unitLevel += 25;
						UpLevel();
						break;
					case 75:
						currentHP = maxHP;
						currentShield = maxShield;
						break;
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.P))
			StopSaving();

		if(saving)
			SaveUnit();
	}
	
	public void StopSaving()
	{
		saving = !saving;
		SaveSystem.Delete("zorg");
		SaveSystem.Delete("t800");
		SaveSystem.Delete("t1000");
	}
	
	public void LoadUnit()
	{
		UnitData data = SaveSystem.LoadZorg();
		if (unitName == "Zorg")
			data = SaveSystem.LoadZorg();
		if (unitName == "T-800")
			data = SaveSystem.LoadT800();
		if (unitName == "T-1000")
			data = SaveSystem.LoadT1000();
		
		unitLevel = data.level;
		currentHP = data.health;
		maxHP = data.maxHealth;
		currentShield = data.shield;
		maxShield = data.maxShield;
		damage = data.damage;
		pen = data.pen;
		pre = data.pre;
		cri = data.cri;
	}
	
	public void SaveUnit()
	{
		if(unitName == "Zorg")
			SaveSystem.SaveZorg(this);
		if(unitName == "T-800")
			SaveSystem.SaveT800(this);
		if(unitName == "T-1000")
			SaveSystem.SaveT1000(this);
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

	public void UpLevel()
	{
		currentHP = maxHP;
		currentShield = maxShield;
		
		
		maxHP += maxHP;
		currentHP += currentHP;
		
		maxShield += maxShield;
		currentShield += currentShield;
		damage += damage;
		pen += pen;
		pre += pre;
		cri += cri;
	}
	
}
