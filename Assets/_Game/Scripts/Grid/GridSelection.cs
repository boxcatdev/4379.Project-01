using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSelection : MonoBehaviour
{
    private GameController _controller;

    private TouchInput _input;

    public static bool CanSelect = true;

    public static HexTile SelectedTile { get; private set; }

    public static Action<HexTile> OnGridTileSelected = delegate { };

    public static List<HexTile> CityTiles;

    private void Awake()
    {
        _controller = FindObjectOfType<GameController>();
        _input = FindObjectOfType<TouchInput>();

        CityTiles = new List<HexTile>();
        HexTile[] tiles = FindObjectsOfType<HexTile>();
        foreach (HexTile tile in tiles)
        {
            if(tile.TileType == TileType.City) CityTiles.Add(tile);
        }

        if (CityTiles.Count > 0)
            Debug.LogFormat("CitiesFound: {0}", CityTiles.Count);
        else
            Debug.LogError("No Cities found");
    }
    private void OnEnable()
    {
        TouchInput.OnClicked += SelectGridTile;
    }
    private void OnDisable()
    {
        TouchInput.OnClicked -= SelectGridTile;
    }

    public static HexTile GetRandomPlayerCity()
    {
        List<HexTile> playerCityList = new List<HexTile>();
        int playerCitiesCount = 0;

        //get player cities
        foreach (HexTile city in CityTiles)
        {
            if(city.Team == GameTeam.Player)
            {
                playerCitiesCount++;
                playerCityList.Add(city);
            }
        }

        //return random city
        if(playerCityList.Count > 1)
        {
            return playerCityList[UnityEngine.Random.Range(0, playerCityList.Count - 1)];
        }
        else
        {
            return playerCityList[0];
        }
    }
    public void SelectGridTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(_input.TouchScreenPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            //Debug.LogFormat("Hit Result: {0}", hit);

            HexTile tile = hit.collider.GetComponent<HexTile>();
            if (tile != null)
            {
                Debug.LogFormat("Found tile: {0}", tile.TileType);

                if (tile == SelectedTile)
                {
                    SelectedTile = null;
                    //OnGridTileSelected?.Invoke(null);
                }
                else
                {
                    if (CanSelect)
                    {
                        SelectedTile = tile;
                        //OnGridTileSelected?.Invoke(tile);
                    }
                }
            }
            else
            {
                SelectedTile = null;
                //OnGridTileSelected?.Invoke(null);
            }
        }
        else
        {
            Debug.LogFormat("No hit");
            SelectedTile = null;
            //OnGridTileSelected?.Invoke(null);
        }

        //tile selected event
        OnGridTileSelected?.Invoke(SelectedTile);

        //sfx
        if(SelectedTile != null)
        {
            //play state change SFX
            _controller.AudioSFX.PlaySoundEffect(SFXType.Select);
        }
        else
        {
            //play state change SFX
            _controller.AudioSFX.PlaySoundEffect(SFXType.Deselect);
        }
    }

    public static void ResetSelectedTile()
    {
        SelectedTile = null;
        OnGridTileSelected?.Invoke(SelectedTile);
    }
}
