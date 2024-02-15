using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridModify : MonoBehaviour
{
    private TouchInput _input;
    private Camera _camera;

    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Sprite _tileSprite;
    [SerializeField] private Vector2Int _horizontalGridBounds;
    [SerializeField] private Vector2Int _verticalGridBounds;

    private void Awake()
    {
        _input = FindObjectOfType<TouchInput>();
        _camera = Camera.main;
    }
    private void Start()
    {
        ChangeAllTiles();
    }
    private void OnEnable()
    {
        TouchInput.OnClicked += Clicked;
    }

    private void Clicked()
    {
        if(_tilemap == null) return;

        Vector3 worldPosition = _camera.ScreenToWorldPoint(_input.TouchScreenPosition);
        worldPosition.z = 0;
        Vector3Int cellInt = _tilemap.WorldToCell(worldPosition);
        TileBase tile = _tilemap.GetTile(cellInt);

        Tile moddTile = new Tile();
        moddTile.sprite = _tileSprite;
        moddTile.color = Color.red;

        _tilemap.SetTile(cellInt, moddTile);

        _tilemap.RefreshTile(cellInt);

        Debug.Log(cellInt.ToString());
    }
    private void ChangeAllTiles()
    {
        for (int x = _horizontalGridBounds.x; x < _horizontalGridBounds.y + 1; x++)
        {
            for (int y = _verticalGridBounds.x; y < _verticalGridBounds.y + 1; y++)
            {
                Vector3Int pos = new Vector3Int(x, y);

                TileBase checkTile = _tilemap.GetTile(pos);
                if (checkTile != null)
                {
                    ScriptableObject tileSO = ScriptableObject.CreateInstance("Tile");

                    Tile startTile = new Tile();
                    startTile.sprite = _tileSprite;
                    startTile.color = Color.green;

                    //_tilemap.SetColor(pos, Color.green);
                    _tilemap.SetTile(pos, startTile);
                }
                
            }
        }

        _tilemap.RefreshAllTiles();
    }
}
