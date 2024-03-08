using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseManager : MonoBehaviour
{
    //private GridSelection _gridSelection;

    [SerializeField] private Transform _choosePanel;

    public static int ChosenCitiesCount = 0;

    private void Awake()
    {
        //_gridSelection = FindObjectOfType<GridSelection>();
    }
    private void Start()
    {
        _choosePanel.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GridSelection.OnGridTileSelected += ToggleChoosePanel;
    }
    private void OnDisable()
    {
        GridSelection.OnGridTileSelected -= ToggleChoosePanel;
    }

    public void SetSelectedDefendMove(int defendInt)
    {
        if(GridSelection.SelectedTile != null)
        {
            GridSelection.SelectedTile.SetDefendMove((AttackMove)defendInt);
            Debug.Log(GridSelection.SelectedTile.gameObject.name);
        }
        else
        {
            Debug.Log("SelectedTile == null");
        }

        //ToggleChoosePanel(null);
        //deselect tile
        GridSelection.ResetSelectedTile();
    }
    public void ResetPlayerCities()
    {
        foreach (HexTile cityTile in GridSelection.CityTiles)
        {
            if(cityTile.Team == GameTeam.Player)
            {
                cityTile.ResetDefendMove();
            }
        }
    }
    public void SetupEnemyDefendMoves()
    {
        foreach (HexTile cityTile in GridSelection.CityTiles)
        {
            if(cityTile.Team == GameTeam.Enemy)
            {
                cityTile.SetDefendMove((AttackMove)Random.Range(0, 3));
            }
        }
    }

    public void ToggleChoosePanel(HexTile tile)
    {
        if(tile != null)
        {
            if (tile.TileType == TileType.City && tile.Team == GameTeam.Player)
            {
                //enable panel
                //move panel to tile location
                _choosePanel.gameObject.SetActive(true);

                Vector3 uiPosition = Camera.main.WorldToScreenPoint(tile.transform.position);
                _choosePanel.transform.position = uiPosition;

                //disable selection
                GridSelection.CanSelect = false;
            }
        }
        else
        {
            //disable panel
            _choosePanel.gameObject.SetActive(false);

            //enable selection
            GridSelection.CanSelect = true;
        }
    }
}
