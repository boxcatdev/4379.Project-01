using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _winnerText;
    [SerializeField] private TextMeshProUGUI _playerText;
    [SerializeField] private TextMeshProUGUI _enemyText;
    [SerializeField] private TextMeshProUGUI _roundText;

    //stored moves
    private AttackMove _playerMove;
    private AttackMove _enemyMove;

    private int _roundCounter = 0;

    private void Start()
    {
        UpdateRoundText();
    }

    #region UI Functions
    public void ResetUI()
    {
        _playerText.text = "Player Move:\n" + "?";
        _enemyText.text = "Enemy Move:\n" + "?";
        _winnerText.text = "Winner:\n" + "?";
    }
    public void UpdatePlayerText(AttackMove move)
    {
        _playerText.text = "Player Move:\n" + move.ToString();
    }
    public void UpdateEnemyText(AttackMove move)
    {
        _enemyText.text = "Enemy Move:\n" + move.ToString();
    }
    public void UpdateWinnerText(string winnerText)
    {
        _winnerText.text = "Winner:\n" + winnerText;
    }
    public void UpdateRoundText()
    {
        _roundText.text = "Round: " + _roundCounter.ToString();
    }
    #endregion
    #region Button functions
    public void SelectRock()
    {
        _playerMove = AttackMove.Rock;
        UpdatePlayerText(_playerMove);
    }
    public void SelectPaper()
    {
        _playerMove = AttackMove.Paper;
        UpdatePlayerText(_playerMove);
    }
    public void SelectScissors()
    {
        _playerMove = AttackMove.Scissors;
        UpdatePlayerText(_playerMove);
    }
    public void StartBattle()
    {
        //set enemy move
        SetEnemyMove();

        //try if player wins
        AttackResult matchResult = RockPaperScissors.CheckIfPlayerWins(_playerMove, _enemyMove);

        //update UI to match
        UpdateWinnerText(matchResult.ToString());

        //update round counter
        _roundCounter++;
        UpdateRoundText();
    }
    public void ResetBattle()
    {
        //reset UI
        ResetUI();
    }
    #endregion

    private void SetEnemyMove()
    {
        _enemyMove = (AttackMove)Random.Range(0, 3);
        UpdateEnemyText(_enemyMove);
    }
}
