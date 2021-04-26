using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

    void Update()
    {
	    if (state == BattleState.LOST || state == BattleState.WON)
	    {
		    SceneManager.LoadScene("GameScene");
	    }
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
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
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

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

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
			
			if (enemyUnit.unitName == "Zorg")
			{
				playerUnit.player.coin += 100;
			}
		
			if (enemyUnit.unitName == "T-800")
			{
				playerUnit.player.coin += 250;
			}
		
			if (enemyUnit.unitName == "T-1000")
			{
				playerUnit.player.coin += 500;
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
		SceneManager.LoadScene("GameScene");

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
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
