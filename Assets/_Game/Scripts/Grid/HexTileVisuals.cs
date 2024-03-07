using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class HexTileVisuals : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HexTile _tile;
    [SerializeField] private SpriteRenderer _tileSprite;
    [SerializeField] private SpriteRenderer _defendParent;
    [SerializeField] private SpriteRenderer _defendIcon;

    [Header("Colors")]
    //[SerializeField] private Color _playerColor;
    //[SerializeField] private Color _enemyColor;
    //[SerializeField] private Color _forestColor;

    [Header("Sprites")]
    [SerializeField] private Sprite _playerCitySprite;
    [SerializeField] private Sprite _enemyCitySprite;
    [SerializeField] private Sprite _wildsSprite;

    [Header("Defend Sprites")]
    [SerializeField] private Sprite _defendMystery;
    [SerializeField] private Sprite _defendRock;
    [SerializeField] private Sprite _defendPaper;
    [SerializeField] private Sprite _defendScissors;


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
            //if(_tile.Team == GameTeam.Player && _tileSprite.color !=  _playerColor) _tileSprite.color = _playerColor;
            //else if(_tile.Team == GameTeam.Enemy &&  _tileSprite.color != _enemyColor) _tileSprite.color = _enemyColor;
            //else if(_tile.Team == GameTeam.None && _tileSprite.color != _forestColor) _tileSprite.color = _forestColor;

            //sprite
            if(_tile.TileType == TileType.Wilds)
            {
                if(_tileSprite.sprite != _wildsSprite) _tileSprite.sprite = _wildsSprite;
            }
            else
            {
                if(_tile.Team == GameTeam.Player)
                {
                    if (_tileSprite.sprite != _playerCitySprite) _tileSprite.sprite = _playerCitySprite;
                }
                else
                {
                    if (_tileSprite.sprite != _enemyCitySprite) _tileSprite.sprite= _enemyCitySprite;
                }
            }

            //defend move

            //show parent
            if (_tile.HasDefend == false && _defendParent.gameObject.activeInHierarchy == true)
                _defendParent.gameObject.SetActive(false);
            if (_tile.HasDefend == true && _defendParent.gameObject.activeInHierarchy == false)
                _defendParent.gameObject.SetActive(true);

            if (_tile.TileType == TileType.City)
            {
                if(_tile.Team == GameTeam.Player)
                {
                    //change icon
                    if (_tile.DefendMove == AttackMove.Rock && _defendIcon.sprite != _defendRock)
                        _defendIcon.sprite = _defendRock;
                    if (_tile.DefendMove == AttackMove.Paper && _defendIcon.sprite != _defendPaper)
                        _defendIcon.sprite = _defendPaper;
                    if (_tile.DefendMove == AttackMove.Scissors && _defendIcon.sprite != _defendScissors)
                        _defendIcon.sprite = _defendScissors;
                }
                else
                {
                    if(_defendIcon.sprite != _defendMystery) _defendIcon.sprite = _defendMystery;
                }
            }
        }
    }
}
