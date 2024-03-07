using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    // state variables here
    public GamePlaceCityState PlaceCityState { get; private set; }
    public GameBattleState BattleState { get; private set; }

    //updated state variables
    public GameSetupState SetupState { get; private set; }
    public GameChooseState ChooseState { get; private set; }
    public GamePlayerTurnState PlayerTurnState { get; private set; }
    public GameEnemyTurnState EnemyTurnState { get; private set; }
    public GameWinState WinState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();

        // state instantiation here
        PlaceCityState = new GamePlaceCityState(this, _controller);
        BattleState = new GameBattleState(this, _controller);

        //updated state variables
        SetupState = new GameSetupState(this, _controller);
        ChooseState = new GameChooseState(this, _controller);
        PlayerTurnState = new GamePlayerTurnState(this, _controller);
        EnemyTurnState = new GameEnemyTurnState(this, _controller);
        WinState = new GameWinState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
