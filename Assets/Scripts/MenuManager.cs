using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenuStartGame;
    [SerializeField] private GameObject panelSelectionP1;
    [SerializeField] private GameObject panelSelectionP2;

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

    public void ActivatePanelSelectionP1()
    {
        panelSelectionP1.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivatePanelSelectionP1()
    {
        panelSelectionP1.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void ActivatePanelSelectionP2()
    {
        panelSelectionP2.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivatePanelSelectionP2()
    {
        panelSelectionP2.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
