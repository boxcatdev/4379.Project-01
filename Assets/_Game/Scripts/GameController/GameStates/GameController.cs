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
    [Space]
    [SerializeField] private ChooseManager _chooseManager;
    [SerializeField] private PlayerTurnController _playerTurn;
    [SerializeField] private EnemyTurnController _enemyTurn;
    [SerializeField] private PopupText _popupText;

    private AudioManagerMusic _audioMusic;
    public AudioManagerSFX _audioSFX;

    public GridModify GridModify => _gridModify;
    public UIManager UIManager => _uiManager;
    public BattleController BattleController => _battleController;
    public AudioManagerMusic AudioMusic => _audioMusic;
    public AudioManagerSFX AudioSFX => _audioSFX;

    //updated references
    public ChooseManager ChooseManager => _chooseManager;
    public PlayerTurnController PlayerTurn => _playerTurn;
    public EnemyTurnController EnemyTurn => _enemyTurn;
    public PopupText PopupText => _popupText;

    private void Start()
    {
        _audioMusic = FindObjectOfType<AudioManagerMusic>();
        _audioSFX = FindObjectOfType<AudioManagerSFX>();
    }
    public void TestUpdate()
    {
        BattleController.StorePlayerMove(AttackMove.Paper);
    }
}
