using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridTouch : MonoBehaviour
{
    [SerializeField] private Tilemap _hexMap;
    [SerializeField] private Color _selectedColor;

    private TouchInput _input;
    private Camera _camera;

    //private TileBase _savedTile;
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

    private void Clicked()
    {
        if(_hexMap != null)
        {
            Vector3 worldPosition = _camera.ScreenToWorldPoint(_input.TouchScreenPosition);
            worldPosition.z = 0;

            Vector3Int cellInt = _hexMap.WorldToCell(worldPosition);

            //Debug.Log(cellInt);

            TileBase tile = _hexMap.GetTile(cellInt);

            if(tile != null)
            {
                _hexMap.SetTileFlags(cellInt, TileFlags.None);
                _hexMap.SetColor(cellInt, _selectedColor);

                Debug.Log("Tile: " + _hexMap.GetColor(cellInt));

            }
            else
            {
                Debug.Log(tile);
            }

            //_hexMap.SetTileFlags(_savedTileCoords, TileFlags.None);
            //_hexMap.SetColor(_savedTileCoords, Color.white);

            //_savedTile = tile;
            _savedTileCoords = cellInt;

            _hexMap.RefreshAllTiles();
        }
    }
}
