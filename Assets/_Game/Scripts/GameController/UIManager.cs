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
    [SerializeField] private Image _nextStateFill;
    [Space]
    [SerializeField] private GameObject _battleCanvas;
    [SerializeField] private GameObject _winCanvas;


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
            _winText.text = attackResult.ToString();
        }
        else
        {
            Debug.LogError("Missing Win Text");
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

    public void EnableBattleCanvas(bool isEnabled)
    {
        _battleCanvas.SetActive(isEnabled);
    }
    public void EnableWinCanvas(bool isEnabled)
    {
        _winCanvas.SetActive(isEnabled);
    }
}
