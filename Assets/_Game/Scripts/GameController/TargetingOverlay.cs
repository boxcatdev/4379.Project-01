using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetingOverlay : MonoBehaviour
{
    private EnemyTurnController _enemyController;

    [SerializeField] private Image _overlay;
    [SerializeField] private float _spinSpeed = 5f;

    public bool isVisible = false;

    private void Awake()
    {
        _enemyController = FindObjectOfType<EnemyTurnController>();
    }
    private void Start()
    {
        Selection(null);
    }
    private void OnEnable()
    {
        GridSelection.OnGridTileSelected += Selection;
    }
    private void OnDisable()
    {
        GridSelection.OnGridTileSelected -= Selection;
    }
    private void Update()
    {
        if (isVisible)
        {
            _overlay.transform.Rotate(Vector3.forward * _spinSpeed * Time.deltaTime);
        }
        else
        {
            if(_overlay.gameObject.activeInHierarchy) _overlay.gameObject.SetActive(false);
        }
    }

    public void Selection(HexTile tile)
    {
        if (!_enemyController.gameObject.activeInHierarchy) return;

        if(tile != null)
        {
            isVisible = true;

            //enable
            _overlay.gameObject.SetActive(true);

            //move to location
            _overlay.transform.position = Camera.main.WorldToScreenPoint(tile.transform.position);
        }
        else
        {
            isVisible = false;

            //disable
            _overlay.gameObject.SetActive(false);
        }
    }
}
