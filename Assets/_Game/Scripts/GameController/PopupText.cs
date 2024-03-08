using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PopupText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _popupText;
    [SerializeField] private float _popupDuration = 2.0f;
    [SerializeField] private float _popupSpeed = 5.0f;
    [SerializeField] private float _popupDist = 100f;

    private Vector3 _startingPosition;
    private Vector3 _endingPosition;

    private float _visibilityProgress;
    private float _durationProgress;

    //private bool _isVisible = false;
    public static Action<string> OnPopup = delegate { };

    private void OnEnable()
    {
        OnPopup += ShowPopupText;
    }
    private void OnDisable()
    {
        OnPopup -= ShowPopupText;
    }
    private void Start()
    {
        _startingPosition = _popupText.transform.position;
        _endingPosition = _startingPosition + new Vector3(0, _popupDist, 0);
    }
    private void Update()
    {
        if (_popupText.gameObject.activeInHierarchy)
        {
            _durationProgress -= Time.deltaTime;
            _visibilityProgress -= Time.deltaTime;

            MovePopup();
            FadeAway();

            if(_durationProgress <= 0)
            {
                HidePopupText();
            }
        }
    }

    #region Manipulate Popup
    private void MovePopup()
    {
        if(_popupText != null)
        {
            _popupText.transform.position = Vector3.Lerp(_popupText.transform.position, _endingPosition, _popupSpeed * Time.deltaTime);
        }
    }
    private void FadeAway()
    {
        if(_popupText != null)
        {
            Color adjustedColor = new Color(_popupText.color.r, _popupText.color.g, _popupText.color.b, _durationProgress / _popupDuration);

            _popupText.color = adjustedColor;
        }
    }
    #endregion

    #region Popup Settings
    public void ShowPopupText(string text)
    {
        if (_popupText != null)
        {
            //enable text
            _popupText.gameObject.SetActive(true);

            //update text
            _popupText.text = text;

            ResetPopupState();
        }
    }
    public void HidePopupText()
    {
        if (_popupText != null)
        {
            //disable text
            _popupText.gameObject.SetActive(false);
        }
    }
    private void ResetPopupState()
    {
        if (_popupText != null)
        {
            //reset visibility
            Color adjustedColor = new Color(_popupText.color.r, _popupText.color.g, _popupText.color.b, 1.0f);
            _popupText.color = adjustedColor;

            //reset position
            _popupText.transform.position = _startingPosition;

            //start timer
            _durationProgress = _popupDuration;

            //start visibility progress
            _visibilityProgress = 1f;
        }
    }
    #endregion
}
