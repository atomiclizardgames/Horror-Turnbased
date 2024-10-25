using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int attackPower = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Attack(CharacterStats target)
    {
        target.TakeDamage(attackPower);
    }

    private void Die()
    {
        gameObject.SetActive(false); // or add a death animation
    }
}
