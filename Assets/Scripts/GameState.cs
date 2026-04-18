using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState
{
    public Vector3 playerPosition;
    public int playerHP;
    public int playerAttack;

    public List<Vector3> enemyPositions = new List<Vector3>();

    public GameState Clone()
    {
        return new GameState
        {
            playerPosition = this.playerPosition,
            playerHP = this.playerHP,
            playerAttack = this.playerAttack,
            enemyPositions = new List<Vector3>(this.enemyPositions)
        };
    }
}