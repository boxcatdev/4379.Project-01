using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _stateText;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _enemyMoveText;
    [SerializeField] private Image _nextStateFill;
    [Space]
    [SerializeField] private GameObject _battleCanvas;
    [SerializeField] private GameObject _winCanvas;


    [Header("Turn Instruction")]
    [SerializeField] private GameObject _instructionCanvas;
    [SerializeField] private TextMeshProUGUI _instructionText;


    private void Start()
    {
        _battleCanvas?.SetActive(false);
        _winCanvas?.SetActive(false);
    }

    #region Updates
    public void RefreshStateText(string text)
    {
        if(_stateText != null)
        {
            _stateText.text = text;
        }
        else
        {
            Debug.LogError("Missing State Text UI Object");
        }
    }
    public void UpdateWinText(AttackResult attackResult)
    {
        if(_winText != null)
        {
            _winText.text = "Result: " + attackResult.ToString();
        }
        else
        {
            Debug.LogError("Missing Win Text");
        }
    }
    public void UpdateEnemyMoveText(AttackMove enemyMove)
    {
        if(_enemyMoveText != null)
        {
            _enemyMoveText.text = "Enemy Move: " + enemyMove.ToString();
        }
        else
        {
            Debug.LogError("Missing Enemy Move Text");
        }
    }
    public void UpdateFillAmount(float amount, float limit)
    {
        if(_nextStateFill != null)
        {
            _nextStateFill.fillAmount = amount / limit;
        }
        else
        {
            Debug.Log("Missing Next State Fill");
        }
    }
    #endregion

    #region Enable Canvases
    public void EnableBattleCanvas(bool isEnabled)
    {
        if(_battleCanvas != null) _battleCanvas.SetActive(isEnabled);
    }
    public void EnableWinCanvas(bool isEnabled)
    {
        if(_winCanvas != null) _winCanvas.SetActive(isEnabled);
    }
    public void EnableInstructionCanvas(bool isEnabled)
    {
        if(_instructionCanvas != null) _instructionCanvas.SetActive(isEnabled);
    }
    #endregion

    #region Instruction Canvas
    public void UpdateInstructionText(StatesUIEnum state)
    {
        switch(state)
        {
            case StatesUIEnum.Setup:
                //
                break;
            case StatesUIEnum.Choose:
                //give instruction for choosing defend move
                _instructionText.text = "The enemy has chosen their defense moves (rock/paper/scissors). " +
                    "Click on your remaining cities and choose a defense move (rock/paper/scissors) to protect it if attacked by the enemy.";
                break;
            case StatesUIEnum.Player:
                //give instructions for attacking the enemy cities
                _instructionText.text = "click on one of the enemy's remaining cities to attack them. " +
                    "If your attack move (rock/paper/scissors) beats their defense move (rock/paper/scissors) you will claim their city for yourself.";
                break;
            case StatesUIEnum.EnemyFirst:
                //explain what the enemy will do
                _instructionText.text = "The enemy has selected a city to attack...";
                break;
            case StatesUIEnum.EnemySecond:
                //
                _instructionText.text = "The enemy has attacked one of your cities. It will be your turn next.";
                break;
            case StatesUIEnum.GameOver:
                //
                if (ScoreManager.GetHasPlayerWon())
                    _instructionText.text = "You have defeated the enemy. Return to the main menu to play again.";
                else
                    _instructionText.text = "The enemy has defeated you. Return to the main menu to try again.";
                break;
        }
    }
    #endregion
}

public enum StatesUIEnum { Setup, Choose, Player, EnemyFirst, EnemySecond, GameOver}
