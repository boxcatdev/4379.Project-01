using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    [SerializeField] private Transform _attackPanel;

    public bool PlayerHasAttacked {  get; private set; } = false;

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

    public void ResetPlayerHasAttacked()
    {
        PlayerHasAttacked = false;
    }

    public void UseAttackOnCity(int attackInt)
    {
        if(GridSelection.SelectedTile != null)
        {
            //TODO

            //result of the fight
            AttackResult aResult = RockPaperScissors.CheckIfPlayerWins((AttackMove)attackInt, GridSelection.SelectedTile.DefendMove);

            PopupText.OnPopup?.Invoke(aResult.ToString());

            if (aResult == AttackResult.Win)
            {
                //take over enemy city
                GridSelection.SelectedTile.SetTeamOnCapture(GameTeam.Player);

                Debug.LogWarning("City Captured");

                //update score
                ScoreManager.OnScoreChanged?.Invoke();
            }
            else
            {
                //nothing happens
            }
        }

        //deselect tile
        GridSelection.ResetSelectedTile();

        //TODO check for winners
        ScoreManager.CheckIfGameOver();

        PlayerHasAttacked = true;
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
