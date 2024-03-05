using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class HexTile : MonoBehaviour
{
    [SerializeField] private Vector2Int _tileCoords;
    [SerializeField] private GameTeam _team;

    public Vector2Int TileCoords => _tileCoords;
    public GameTeam Team => _team;

}
public enum GameTeam { None, Player, Enemy};
