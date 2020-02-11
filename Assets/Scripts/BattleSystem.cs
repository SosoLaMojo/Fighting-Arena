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

    [SerializeField] private GameObject P1;
    [SerializeField] private GameObject P2;
    
    [SerializeField] private Transform P1BattleStation;
    [SerializeField] private Transform P2BattleStation;

    [SerializeField] private BattleHUD P1HUD;
    [SerializeField] private BattleHUD P2HUD;

    [SerializeField] private TextMeshProUGUI dialogText;

    private Unit P1Unit;
    private Unit P2Unit;

    private bool hasPlayed = false;
    private bool P1Dead;
    private bool P2Dead;

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
                GameObject P1GO = Instantiate(P1, P1BattleStation);
                P1Unit = P1GO.GetComponent<Unit>();
        
                GameObject P2GO = Instantiate(P2, P2BattleStation);
                P2Unit = P2GO.GetComponent<Unit>();

                P1HUD.SetHUD(P1Unit);
                P2HUD.SetHUD(P2Unit);

                dialogText.text = "The battle begins!";
                
                state = BattleState.P1TURN;

                break;
            }
            case BattleState.P1TURN:
            {
                dialogText.text = P1Unit.UnitName + ", choose an action:";

                if (hasPlayed && !P2Dead)
                {
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
                dialogText.text = P2Unit.UnitName + ", choose an action:";
                
                if (hasPlayed && !P1Dead)
                {
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
        P2Dead = P2Unit.TakeDamage(P1Unit.Damage);
        
        P2HUD.SetHP(P2Unit.CurrentHp);
        
        //set coroutine
        dialogText.text = P1Unit.UnitName + "dealt" + P1Unit.Damage + "to" + P2Unit.UnitName;
        hasPlayed = true;
    }
    
    public void P2Attack()
    {
        P1Dead = P1Unit.TakeDamage(P2Unit.Damage);
        
        P1HUD.SetHP(P1Unit.CurrentHp);
        
        //set coroutine
        dialogText.text = P2Unit.UnitName + "dealt" + P2Unit.Damage + "to" + P1Unit.UnitName;
        hasPlayed = true;
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

    void EndBattle()
    {
        if (state == BattleState.P1WON)
        {
            dialogText.text = "Congratulations, " + P1Unit.UnitName + ", you have won the battle!";
        }
        else if (state == BattleState.P2WON)
        {
            dialogText.text = "Congratulations, " + P2Unit.UnitName + ", you have won the battle!";
        }
    }
}
