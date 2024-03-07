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


    #region Enable Canvases
    public void EnableBattleCanvas(bool isEnabled)
    {
        if(_battleCanvas != null) _battleCanvas.SetActive(isEnabled);
    }
    public void EnableWinCanvas(bool isEnabled)
    {
        if(_winCanvas != null) _winCanvas.SetActive(isEnabled);
    }
    public void EnableDescriptionCanvas(bool isEnabled)
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
        }
    }
    #endregion
}

public enum StatesUIEnum { Setup, Choose, Player, Enemy, Win, Lose}
