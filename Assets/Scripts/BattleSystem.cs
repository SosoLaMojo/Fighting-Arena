using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {START, P1TURN, P2TURN, P1WON, P2WON}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private BattleState state;

    [SerializeField] private GameObject Adventurer;
    [SerializeField] private GameObject Gladiator;
    
    [SerializeField] private Transform P1BattleStation;
    [SerializeField] private Transform P2BattleStation;

    [SerializeField] private BattleHUD P1HUD;
    [SerializeField] private BattleHUD P2HUD;

    [SerializeField] private GameObject P1Actions;
    [SerializeField] private GameObject P2Actions;

    [SerializeField] private TextMeshProUGUI dialogText;

    private GameObject P1;
    private GameObject P2;

    private Unit P1Unit;
    private Unit P2Unit;

    private bool hasPlayed = false;
    private bool P1Dead;
    private bool P2Dead;
    private bool P1IsDefending = false;
    private bool P2IsDefending = false;

    private int healAmount = 4;
    
    void Start()
    {
        state = BattleState.START;
    }

    private void Update()
    {
        switch (state)
        {
            case BattleState.START:
            {
                
                if (GameManager.instance.P1ChoseAdventurer1)
                {
                    P1 = Adventurer;
                }
                else if (!GameManager.instance.P1ChoseAdventurer1)
                {
                    P1 = Gladiator;
                    
                    P1BattleStation.transform.Rotate(0f, 180.0f, 0f);
                }

                if (GameManager.instance.P2ChoseAdventurer1)
                {
                    P2 = Adventurer;
                    
                    P2BattleStation.transform.Rotate(0f, 180.0f, 0f);
                }
                else if (!GameManager.instance.P2ChoseAdventurer1)
                {
                    P2 = Gladiator;
                }
                
                GameObject P1GO = Instantiate(P1, P1BattleStation);
                P1Unit = P1GO.GetComponent<Unit>();
        
                GameObject P2GO = Instantiate(P2, P2BattleStation);
                P2Unit = P2GO.GetComponent<Unit>();

                P1HUD.SetHUD(P1Unit);
                P2HUD.SetHUD(P2Unit);

                StartCoroutine(StartBattle());
                
                state = BattleState.P1TURN;

                if (state == BattleState.P1TURN)
                {
                    dialogText.text = "Player 1, choose an action:";
                }

                break;
            }
            case BattleState.P1TURN:
            {
                P1Actions.SetActive(true);
                P2Actions.SetActive(false);
                
                

                if (hasPlayed && !P2Dead)
                {
                    dialogText.text = "Player 2, choose an action:";
                    state = BattleState.P2TURN;
                    hasPlayed = false;
                }
                else if (hasPlayed && P2Dead)
                {
                    state = BattleState.P1WON;
                }
                    
                break;
            }
            case BattleState.P2TURN:
            {
                P2Actions.SetActive(true);
                P1Actions.SetActive(false);

                if (hasPlayed && !P1Dead)
                {
                    dialogText.text = "Player 1, choose an action:";
                    state = BattleState.P1TURN;
                    hasPlayed = false;
                }
                else if (hasPlayed && P1Dead)
                {
                    state = BattleState.P2WON;
                }
                
                break;
            }
            case BattleState.P1WON:
            {
                EndBattle();
                
                break;
            }
            case BattleState.P2WON:
            {
                EndBattle();
                
                break;
            }

        }
    }

    public void P1Attack()
    {
        if (P2IsDefending)
        {
            StartCoroutine(PlayerDefend());
            P2IsDefending = false;
        }
        else
        {
            P2Dead = P2Unit.TakeDamage(P1Unit.Damage);
        
            P2HUD.SetHP(P2Unit.CurrentHp);

            StartCoroutine(PlayerAttack());
        }
        
    }
    
    public void P2Attack()
    {
        if (P1IsDefending)
        {
            StartCoroutine(PlayerDefend());
            P2IsDefending = false;
        }
        else
        {
            P1Dead = P1Unit.TakeDamage(P2Unit.Damage);
        
            P1HUD.SetHP(P1Unit.CurrentHp);
            
            StartCoroutine(PlayerAttack());
        }
        
        
    }

    public void P1Heal()
    {
        P1Unit.Heal(healAmount);
        
        P1HUD.SetHP(P1Unit.CurrentHp);

        hasPlayed = true;
    }
    
    public void P2Heal()
    {
        P2Unit.Heal(healAmount);
        
        P2HUD.SetHP(P2Unit.CurrentHp);

        hasPlayed = true;
    }

    public void Defend()
    {
        if (state == BattleState.P1TURN)
        {
            P1IsDefending = true;
        }
        else if (state == BattleState.P2TURN)
        {
            P2IsDefending = true;
        }

        hasPlayed = true;
    }

    void EndBattle()
    {
        if (state == BattleState.P1WON)
        {
            dialogText.text = "Congratulations, Player 1, you have won the battle!";
        }
        else if (state == BattleState.P2WON)
        {
            dialogText.text = "Congratulations, Player 2, you have won the battle!";
        }
    }

    IEnumerator PlayerDefend()
    {
        dialogText.text = "Your attack failed, because your enemy was defending";

        yield return new WaitForSeconds(2f);
        
        hasPlayed = true;
    }

    IEnumerator PlayerAttack()
    {
        if (state == BattleState.P1TURN)
        {
            dialogText.text = " Player 1 dealt " + P1Unit.Damage + " to Player 2";
        }
        else if (state == BattleState.P2TURN)
        {
            dialogText.text = "Player 2 dealt " + P2Unit.Damage + " to Player 1";
        }
        
        yield return new WaitForSeconds(2f);
        
        hasPlayed = true;
    }

    IEnumerator StartBattle()
    {
        dialogText.text = "The battle begins!";
        
        yield return new WaitForSeconds(2f);
    }
}
