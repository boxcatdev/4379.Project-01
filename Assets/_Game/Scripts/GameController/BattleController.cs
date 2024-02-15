using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private GameFSM gameFSM;

    [field:SerializeField]
    public AttackMove enemyMove {  get; private set; }
    [field:SerializeField]
    public AttackMove playerMove { get; private set; }

    private void Awake()
    {
        //gameFSM = GetComponentInParent<GameFSM>();
    }
    #region Moves
    public void PlayerMoveRock()
    {
        if (gameFSM.CurrentState == gameFSM.BattleState)
        {
            StorePlayerMove(AttackMove.Rock);

            gameFSM.BattleState.DoBattleStuff();
        }
    }
    public void PlayerMovePaper()
    {
        if (gameFSM.CurrentState == gameFSM.BattleState)
        {
            StorePlayerMove(AttackMove.Paper);

            gameFSM.BattleState.DoBattleStuff();
        }
    }
    public void PlayerMoveScissors()
    {
        if (gameFSM.CurrentState == gameFSM.BattleState)
        {
            StorePlayerMove(AttackMove.Scissors);

            gameFSM.BattleState.DoBattleStuff();
        }

    }
    #endregion

    #region Battle
    public void StorePlayerMove(AttackMove move)
    {
        playerMove = move;
    }
    public void StoreEnemyMove()
    {
        if (gameFSM.CurrentState == gameFSM.PlaceCityState)
            enemyMove = (AttackMove)Random.Range(0, 3);

        Debug.Log("StoreEnemyMove: " + enemyMove.ToString());
    }
    public AttackResult TryPlayerBattle()
    {
        return RockPaperScissors.CheckIfPlayerWins(playerMove, enemyMove);
    }
    #endregion
}
