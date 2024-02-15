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

    private AudioManagerMusic _audioMusic;
    public AudioManagerSFX _audioSFX;

    public GridModify GridModify => _gridModify;
    public UIManager UIManager => _uiManager;
    public BattleController BattleController => _battleController;
    public AudioManagerMusic AudioMusic => _audioMusic;
    public AudioManagerSFX AudioSFX => _audioSFX;


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
