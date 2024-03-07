using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class HexTile : MonoBehaviour
{
    [SerializeField] private Vector2Int _tileCoords;
    [SerializeField] private GameTeam _team;
    [SerializeField] private TileType _type;
    [SerializeField] private bool _hasDefendMove = false;
    [SerializeField] private AttackMove _defendMove;

    public Vector2Int TileCoords => _tileCoords;
    public GameTeam Team => _team;
    public TileType TileType => _type;
    public bool HasDefend => _hasDefendMove;
    public AttackMove DefendMove => _defendMove;

    public void SetDefendMove(AttackMove defendMove)
    {
        _defendMove = defendMove;
        _hasDefendMove = true;
        ChooseManager.ChosenCitiesCount++;

        Debug.LogWarning("SetDefendMove()");
    }
    public void ResetDefendMove()
    {
        _hasDefendMove = false;
    }

}
public enum GameTeam { None, Player, Enemy};
public enum TileType { Wilds, City}
