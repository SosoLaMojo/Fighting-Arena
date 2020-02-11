using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ChoicesStates {P1TURN, P2TURN}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private ChoicesStates state;
    
    [SerializeField] private GameObject Adventurer;
    [SerializeField] private GameObject Gladiator;

    private bool hasChosen = false;
    private bool P1ChoseAdventurer;
    private bool P2ChoseAdventurer;


    private void Update()
    {
        switch (state)
        {
            case ChoicesStates.P1TURN:
            {
                if (hasChosen)
                {
                    state = ChoicesStates.P2TURN;

                    hasChosen = false;
                }
                break;
            }
            case ChoicesStates.P2TURN:
            {
                if (hasChosen)
                {
                    LoadScene("SceneVincent");
                }
                break;
            }
        }
    }


    public void LoadScene(string sceneName)
    {
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
}