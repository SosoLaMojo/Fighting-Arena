using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public enum ChoicesStates {P1TURN, P2TURN, ENDCHOICE}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private ChoicesStates state;
    
    private bool hasChosen = false;
    private bool P1ChoseAdventurer;
    private bool P2ChoseAdventurer;
    
    private int P1ArenaChoice;
    private int P2ArenaChoice;
    private int arenaChoice;

    public int ArenaChoice
    {
        get => arenaChoice;
        set => arenaChoice = value;
    }

    public bool P1ChoseAdventurer1
    {
        get => P1ChoseAdventurer;
        set => P1ChoseAdventurer = value;
    }

    public bool P2ChoseAdventurer1
    {
        get => P2ChoseAdventurer;
        set => P2ChoseAdventurer = value;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        switch (state)
        {
            case ChoicesStates.P1TURN:
            {
                if (hasChosen)
                {
                    state = ChoicesStates.P2TURN;
                }
                break;
            }
            case ChoicesStates.P2TURN:
            {
                break;
            }
        }
    }

    public void EndChoiceP1()
    {
        hasChosen = true;
    }
    
    public void LoadScene(string sceneName)
    {
        if (P1ArenaChoice == P2ArenaChoice)
        {
            arenaChoice = P1ArenaChoice;
        }
        else if (P1ArenaChoice != P2ArenaChoice)
        {
            float randomNumber = UnityEngine.Random.Range(0.0f, 1.0f);

            if (randomNumber >= 0.5f)
            {
                arenaChoice = P1ArenaChoice;
            }
            else if (randomNumber < 0.5f)
            {
                arenaChoice = P2ArenaChoice;
            }
        }
        
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
    

    public void GladiatorChoice()
    {
        if (state == ChoicesStates.P1TURN)
        {
            P1ChoseAdventurer = false;
        }
        else if (state == ChoicesStates.P2TURN)
        {
            P2ChoseAdventurer = false;
        }
    }

    public void AdventurerChoice()
    {
        if (state == ChoicesStates.P1TURN)
        {
            P1ChoseAdventurer = true;
        }
        else if (state == ChoicesStates.P2TURN)
        {
            P2ChoseAdventurer = true;
        }
    }

    public void DesertChoice()
    {
        if (state == ChoicesStates.P1TURN)
        {
            P1ArenaChoice = 1;
        }
        else if (state == ChoicesStates.P2TURN)
        {
            P2ArenaChoice = 1;
        }
    }

    public void DesertNightChoice()
    {
        if (state == ChoicesStates.P1TURN)
        {
            P1ArenaChoice = 2;
        }
        else if (state == ChoicesStates.P2TURN)
        {
            P2ArenaChoice = 2;
        }
    }

    public void ScorchLandChoice()
    {
        if (state == ChoicesStates.P1TURN)
        {
            P1ArenaChoice = 3;
        }
        else if (state == ChoicesStates.P2TURN)
        {
            P2ArenaChoice = 3;
        }
    }

    public void AcidSwampChoice()
    {
        if (state == ChoicesStates.P1TURN)
        {
            P1ArenaChoice = 4;
        }
        else if (state == ChoicesStates.P2TURN)
        {
            P2ArenaChoice = 4;
        }
    }
}