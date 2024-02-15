using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _stateText;
    [Space]
    [SerializeField] private GameObject _battleCanvas;
    [SerializeField] private GameObject _winCanvas;

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
}
