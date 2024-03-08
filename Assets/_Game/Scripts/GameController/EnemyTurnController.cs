using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController : MonoBehaviour
{
    private HexTile _tileToAttack;

    public void ChooseCityToAttack()
    {
        _tileToAttack = GridSelection.GetRandomPlayerCity();
    }
    public void ResetCityToAttack()
    {
        _tileToAttack = null;
    }
    public void UseAttackOnCity(int attackInt)
    {
        //result of the fight
        AttackResult aResult = RockPaperScissors.CheckIfPlayerWins((AttackMove)attackInt, _tileToAttack.DefendMove);

        PopupText.OnPopup?.Invoke(aResult.ToString());

        if (aResult == AttackResult.Win)
        {
            //take over enemy city
            _tileToAttack.SetTeamOnCapture(GameTeam.Enemy);

            //update score
            ScoreManager.OnScoreChanged?.Invoke();
        }
        else
        {
            //nothing happens
        }
    }
}
