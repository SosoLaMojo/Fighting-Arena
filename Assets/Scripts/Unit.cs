using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   [SerializeField] private int damage;
   [SerializeField] private int maxHP;
   [SerializeField] private int currentHP;

   public int MaxHp
   {
      get => maxHP;
      set => maxHP = value;
   }

   public int CurrentHp
   {
      get => currentHP;
      set => currentHP = value;
   }
   
   public int Damage
   {
      get => damage;
      set => damage = value;
   }

   public bool TakeDamage(int damage)
   {
      currentHP -= damage;
      
      

      if (currentHP <= 0)
      {
         return true;
      }
      else
      {
         return false;
      }
   }

   public void Heal(int amount)
   {
      currentHP += amount;

      if (currentHP > maxHP)
      {
         currentHP = maxHP;
      }
   }
}
