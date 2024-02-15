using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //[Header("Game Data")]
    //[SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    [SerializeField] private GridModify _gridModify;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private BattleController _battleController;

    public GridModify GridModify => _gridModify;
    public UIManager UIManager => _uiManager;
    public BattleController BattleController => _battleController;
}
