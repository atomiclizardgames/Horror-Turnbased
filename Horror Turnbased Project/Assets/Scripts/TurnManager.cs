using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<CharacterMovement> playerUnits;
    public List<CharacterMovement> enemyUnits;
    private int currentTurnIndex = 0;
    private bool isPlayerTurn = true;
    
    void Start()
    {
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        isPlayerTurn = true;
        currentTurnIndex = 0;
        ActivateUnit(playerUnits[currentTurnIndex]);
    }

    private void ActivateUnit(CharacterMovement unit)
    {
        unit.enabled = true; // Enable movement for the activate unit
    }

    private void DeactivateUnit(CharacterMovement unit)
    {
        unit.enabled = false; // Disable movment for non-activate units
    }

    public void EndTurn()
    {
        DeactivateUnit(playerUnits[currentTurnIndex]);

        // Move to the next player's trn or switch to enemies
        currentTurnIndex++;

        if (isPlayerTurn && currentTurnIndex < playerUnits.Count)
        {
            ActivateUnit(playerUnits[currentTurnIndex]);
        }
        else if (isPlayerTurn && currentTurnIndex >= playerUnits.Count)
        {
            StartEnemyTurn();
        }
        else if (!isPlayerTurn && currentTurnIndex >= playerUnits.Count)
        {
            StartPlayerTurn();
        }
        else
        {
            ActivateUnit(enemyUnits[currentTurnIndex]);
        }
    }

    private void StartEnemyTurn()
    {
        isPlayerTurn = false;
        currentTurnIndex = 0;
        ActivateUnit(enemyUnits[currentTurnIndex]);
    }
}
