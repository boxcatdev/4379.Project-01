using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private GameFSM gameFSM;

    private AttackMove _enemyMove;
    private AttackMove _playerMove;

    private void Awake()
    {
        //gameFSM = GetComponentInParent<GameFSM>();
    }
    #region Moves
    public void PlayerMoveRock()
    {
        if (gameFSM.CurrentState == gameFSM.BattleState)
        {
            _playerMove = (AttackMove)0;
            gameFSM.BattleState.DoBattleStuff();
        }
    }
    public void PlayerMovePaper()
    {
        if (gameFSM.CurrentState == gameFSM.BattleState)
        {
            _playerMove = (AttackMove)1;
            gameFSM.BattleState.DoBattleStuff();
        }
    }
    public void PlayerMoveScissors()
    {
        _playerMove = AttackMove.Scissors;
        gameFSM.BattleState.DoBattleStuff();

        if (gameFSM.CurrentState == gameFSM.BattleState)
        {
            
        }

    }
    #endregion

    #region Battle
    public void StoreEnemyMove()
    {
        if (gameFSM.CurrentState == gameFSM.PlaceCityState)
            _enemyMove = (AttackMove)Random.Range(0, 3);

        Debug.Log("StoreEnemyMove: " + _enemyMove.ToString());
    }
    public AttackResult TryPlayerBattle()
    {
        return RockPaperScissors.CheckIfPlayerWins(_playerMove, _enemyMove);
    }
    #endregion
}
