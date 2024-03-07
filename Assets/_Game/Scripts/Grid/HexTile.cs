using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class HexTile : MonoBehaviour
{
    [SerializeField] private Vector2Int _tileCoords;
    [SerializeField] private GameTeam _team;
    [SerializeField] private TileType _type;

    public Vector2Int TileCoords => _tileCoords;
    public GameTeam Team => _team;
    public TileType TileType => _type;

}
public enum GameTeam { None, Player, Enemy};
public enum TileType { Wilds, City}
