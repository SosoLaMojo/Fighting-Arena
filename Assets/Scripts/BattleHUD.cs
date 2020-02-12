using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private Slider HPSlider;

    public void SetHUD(Unit unit)
    {
        HPSlider.maxValue = unit.MaxHp;
        HPSlider.value = unit.CurrentHp;

    }

    public void SetHP(int hp)
    {
        HPSlider.value = hp;
    }
}
