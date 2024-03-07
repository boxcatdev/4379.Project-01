using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    [SerializeField] private Transform _turnPanel;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleAttackPanel(HexTile tile)
    {
        if (tile != null)
        {
            if (tile.TileType == TileType.City && tile.Team == GameTeam.Player)
            {
                //enable panel
                //move panel to tile location
                _turnPanel.gameObject.SetActive(true);

                Vector3 uiPosition = Camera.main.WorldToScreenPoint(tile.transform.position);
                _turnPanel.transform.position = uiPosition;

                //disable selection
                GridSelection.CanSelect = false;
            }
        }
        else
        {
            //disable panel
            _turnPanel.gameObject.SetActive(false);

            //enable selection
            GridSelection.CanSelect = true;
        }
    }
}
