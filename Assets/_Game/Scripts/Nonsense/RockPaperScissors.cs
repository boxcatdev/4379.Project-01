using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RockPaperScissors
{
    public static AttackResult CheckIfPlayerWins(AttackMove playerMove, AttackMove enemyMove)
    {
        
        if(playerMove == AttackMove.Rock && enemyMove == AttackMove.Paper)
        {
            return AttackResult.Lose;
        }
        else if(playerMove == AttackMove.Rock && enemyMove == AttackMove.Scissors)
        {
            return AttackResult.Win;
        }
        else if(playerMove == AttackMove.Paper && enemyMove == AttackMove.Rock)
        {
            return AttackResult.Win;
        }
        else if(playerMove == AttackMove.Paper && enemyMove == AttackMove.Scissors)
        {
            return AttackResult.Lose;
        }
        else if(playerMove == AttackMove.Scissors && enemyMove == AttackMove.Rock)
        {
            return AttackResult.Lose;
        }
        else if(playerMove == AttackMove.Scissors && enemyMove == AttackMove.Paper)
        {
            return AttackResult.Win;
        }
        else
        {
            return AttackResult.Draw;
        }
    }
}

public enum AttackMove { Rock, Paper, Scissors }
public enum AttackResult { Win, Lose, Draw}

