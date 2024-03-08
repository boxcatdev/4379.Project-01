using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController : MonoBehaviour
{
    private GameController _controller;

    [SerializeField] private TargetingOverlay _targetingOverlay;
    private HexTile _tileToAttack;

    private void Awake()
    {
        _controller = GetComponentInParent<GameController>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ChooseCityToAttack()
    {
        _tileToAttack = GridSelection.GetRandomPlayerCity();
        _targetingOverlay.Selection(_tileToAttack);
    }
    public void ResetCityToAttack()
    {
        _tileToAttack = null;
        _targetingOverlay.Selection(null);
    }
    public void UseAttackOnCity(int attackInt)
    {
        //result of the fight
        AttackResult aResult = RockPaperScissors.CheckIfPlayerWins((AttackMove)attackInt, _tileToAttack.DefendMove);

        //popup
        PopupText.OnPopup?.Invoke("Enemy: " + (AttackMove)attackInt + "\n" + aResult.ToString());
        //sfx
        _controller.AudioSFX.PlaySoundEffect(ResultToSFX(aResult));

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
    private SFXType ResultToSFX(AttackResult attackResult)
    {
        switch (attackResult)
        {
            case AttackResult.Win:
                return SFXType.Lose;
            case AttackResult.Lose:
                return SFXType.Win;
            case AttackResult.Draw:
                return SFXType.Draw;
            default:
                return SFXType.Draw;
        }
    }
}
