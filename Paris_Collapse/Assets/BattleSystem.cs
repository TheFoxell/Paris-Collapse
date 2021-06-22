﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	public Unit playerUnit;
	public Unit enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;
	
	public AudioSource audioSource;
	public AudioClip audioHeal = null;
	public AudioClip audioDamagePlayer = null;
	public AudioClip audioDamageUnit = null;
	public AudioClip audioVictory = null;

	// Start is called before the first frame update
    void Start()
    {
	    audioSource = GetComponent<AudioSource>();
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

    void Update()
    {
	    if (state == BattleState.WON && dialogueText.text != "Vous avez gagné le combat! ")
	    {
		    dialogueText.text = "Vous avez gagné le combat! ";
		    audioSource.PlayOneShot(audioVictory);
		    StartCoroutine(WaitAndWin());
	    }
	    if (state == BattleState.LOST)
	    {
		    SceneManager.LoadScene("Lose");
	    }
    }

    IEnumerator WaitAndWin()
    {
	    yield return new WaitForSeconds(6f);
	    if (SceneManager.GetActiveScene().name == "CombatBoss")
		    SceneManager.LoadScene("End");
	    SceneManager.LoadScene("Chargement");
    }

    IEnumerator SetupBattle()
	{

		dialogueText.text = "Vous allez affronter " + enemyUnit.unitName;

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		audioSource.PlayOneShot(audioDamagePlayer);
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		enemyHUD.SetShield(enemyUnit.currentShield);
		dialogueText.text = "L'attaque a marché";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attaque!";
		audioSource.PlayOneShot(audioDamageUnit);

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);
		playerHUD.SetShield(playerUnit.currentShield);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "Vous avez gagné le combat!";
			
			if (enemyUnit.unitLevel == 1)
			{
				playerUnit.player.coin += 100;
				playerUnit.player.exp += 30;
			}
		
			if (enemyUnit.unitLevel == 25)
			{
				playerUnit.player.coin += 250;
				playerUnit.player.exp += 75;
			}
		
			if (enemyUnit.unitLevel == 50)
			{
				playerUnit.player.coin += 500;
				playerUnit.player.exp += 130;
			}
			
			if (enemyUnit.unitLevel == 75)
			{
				playerUnit.player.coin += 650;
				playerUnit.player.exp += 175;
			}

		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "Vous avez perdu le combat!";
			
			playerUnit.player.coin -= 150;
			playerUnit.player.health = 15;
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choisis une action:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "Tu regagnes de la vie";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}
	
	public void OnFuiteButton()
	{
		SceneManager.LoadScene("Chargement");
	}
	
	public void OnInventaireButton()
	{
		if (enemyUnit.unitName == "Zorg")
		{
			SceneManager.LoadScene("InventaireCombat1");
		}
		
		if (enemyUnit.unitName == "T-800")
		{
			SceneManager.LoadScene("InventaireCombat2");
		}
		
		if (enemyUnit.unitName == "T-1000")
		{
			SceneManager.LoadScene("InventaireCombat3");
		}
		
		if (enemyUnit.unitName == "Vyktor")
		{
			SceneManager.LoadScene("InventaireCombatPlayer");
		}
	}

	public void OnHealButton()
	{
		audioSource.PlayOneShot(audioHeal);
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}
	
}
