using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridTouch : MonoBehaviour
{
    [SerializeField] private Tilemap _hexMap;
    [Space]
    [SerializeField] private SpriteRenderer _playerCity;
    [SerializeField] private SpriteRenderer _enemyCity;
    [Space]
    [SerializeField] private Color _playerColor;
    [SerializeField] private Color _enemyColor;

    [Header("Turn stuff")]
    [SerializeField] private bool _playerTurn = true;

    [Header("Testing RPS")]
    [SerializeField] private AttackMove _playerMove;
    [SerializeField] private AttackMove _enemyMove;

    private TouchInput _input;
    private Camera _camera;

    private Vector3Int _savedTileCoords;

    private void Awake()
    {
        _input = FindObjectOfType<TouchInput>();
        _camera = Camera.main;
    }
    private void OnEnable()
    {
        TouchInput.OnClicked += Clicked;
    }

    public Dictionary<Vector3Int, TileInfo> TileDictionary = new Dictionary<Vector3Int, TileInfo>();

    private void Clicked()
    {
        if(_hexMap != null)
        {
            //get tile info
            Vector3 worldPosition = _camera.ScreenToWorldPoint(_input.TouchScreenPosition);
            worldPosition.z = 0;
            Vector3Int cellInt = _hexMap.WorldToCell(worldPosition);
            TileBase tile = _hexMap.GetTile(cellInt);

            //check if tile exists
            if(tile != null)
            {
                Debug.Log("Tile: " + _hexMap.GetColor(cellInt));

                if (_playerTurn)
                {
                    if(!_playerCity.gameObject.activeInHierarchy) _playerCity.gameObject.SetActive(true);
                    _playerCity.transform.position = _hexMap.CellToWorld(cellInt);

                    //add to dictionary
                }
                else
                {
                    if (!_enemyCity.gameObject.activeInHierarchy) _enemyCity.gameObject.SetActive(true);
                    _enemyCity.transform.position = _hexMap.CellToWorld(cellInt);
                }
            }
            else
            {
                Debug.Log(tile);
            }

            //_savedTile = tile;
            _savedTileCoords = cellInt;

            _hexMap.RefreshAllTiles();
        }

        //test rock paper scissors
        Debug.LogWarning(RockPaperScissors.CheckIfPlayerWins(_playerMove, _enemyMove));
    }
}
