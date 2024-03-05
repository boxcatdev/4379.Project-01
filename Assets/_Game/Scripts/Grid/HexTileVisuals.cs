using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class HexTileVisuals : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HexTile _tile;
    [SerializeField] private SpriteRenderer _tileSprite;

    [Header("Colors")]
    [SerializeField] private Color _playerColor;
    [SerializeField] private Color _enemyColor;
    [SerializeField] private Color _forestColor;

    [Header("Sprites")]
    [SerializeField] private Sprite _citySprite;

    private void Awake()
    {
        if(_tile == null) _tile = GetComponent<HexTile>();
        if(_tileSprite == null) _tileSprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if(_tile != null)
        {
            //color
            if(_tile.Team == GameTeam.Player && _tileSprite.color !=  _playerColor)
                _tileSprite.color = _playerColor;
            else if(_tile.Team == GameTeam.Enemy &&  _tileSprite.color != _enemyColor)
                _tileSprite.color = _enemyColor;
            else if(_tile.Team == GameTeam.None && _tileSprite.color != _forestColor)
                _tileSprite.color = _forestColor;
        }
    }
}
