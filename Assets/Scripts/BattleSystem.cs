using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {START, P1TURN, P2TURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private BattleState state;

    [SerializeField] private GameObject P1;
    [SerializeField] private GameObject P2;
    [SerializeField] private Transform P1BattleStation;
    [SerializeField] private Transform P2BattleStation;

    private Unit P1Unit;
    private Unit P2Unit;
    
    void Start()
    {
        state = BattleState.START;
        
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject P1GO = Instantiate(P1, P1BattleStation);
        P1Unit = P1GO.GetComponent<Unit>();
        
        GameObject P2GO = Instantiate(P2, P2BattleStation);
        P2Unit = P2GO.GetComponent<Unit>();
        
    }

}
