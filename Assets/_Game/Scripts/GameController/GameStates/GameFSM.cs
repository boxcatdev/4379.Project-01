using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    // state variables here
    public GameSetupState SetupState { get; private set; }
    public GamePlaceCityState PlaceCityState { get; private set; }
    public GameBattleState BattleState { get; private set; }
    public GameWinState WinState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        
        // state instantiation here
        SetupState = new GameSetupState(this, _controller);
        PlaceCityState = new GamePlaceCityState(this, _controller);
        BattleState = new GameBattleState(this, _controller);
        WinState = new GameWinState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
