using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenuStartGame;
    [SerializeField] private GameObject panelSelection;

    public void ActivatePanelMenuStartGame()
    {
        panelMenuStartGame.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivatePanelMenuStartGame()
    {
        panelMenuStartGame.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivatePanelSelection()
    {
        panelSelection.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivatePanelSelection()
    {
        panelSelection.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
