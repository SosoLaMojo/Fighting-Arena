using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   [SerializeField] private string name;

   [SerializeField] private int damage;
   [SerializeField] private int maxHP;
   [SerializeField] private int currentHP;
}
