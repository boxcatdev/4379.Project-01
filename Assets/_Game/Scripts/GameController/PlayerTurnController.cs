using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    [SerializeField] private Transform _attackPanel;

    private void Start()
    {
        _attackPanel.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GridSelection.OnGridTileSelected += ToggleAttackPanel;
    }
    private void OnDisable()
    {
        GridSelection.OnGridTileSelected -= ToggleAttackPanel;
    }

    public void UseAttackOnCity(int attackInt)
    {
        if(GridSelection.SelectedTile != null)
        {
            //TODO

            //result of the fight
            AttackResult aResult = RockPaperScissors.CheckIfPlayerWins((AttackMove)attackInt, GridSelection.SelectedTile.DefendMove);

            if(aResult == AttackResult.Win)
            {
                //take over enemy city
                GridSelection.SelectedTile.SetTeamOnCapture(GameTeam.Player);

                Debug.LogWarning("City Captured");

                //TODO Setup enemy attack state
            }
            else
            {
                //nothing happens
            }
        }
    }

    public void ToggleAttackPanel(HexTile tile)
    {
        if (tile != null)
        {
            if (tile.TileType == TileType.City && tile.Team == GameTeam.Enemy)
            {
                //enable panel
                //move panel to tile location
                _attackPanel.gameObject.SetActive(true);

                Vector3 uiPosition = Camera.main.WorldToScreenPoint(tile.transform.position);
                _attackPanel.transform.position = uiPosition;

                //disable selection
                GridSelection.CanSelect = false;
            }
        }
        else
        {
            //disable panel
            _attackPanel.gameObject.SetActive(false);

            //enable selection
            GridSelection.CanSelect = true;
        }
    }
}
