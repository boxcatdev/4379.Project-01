using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSelection : MonoBehaviour
{
    private TouchInput _input;

    public static bool CanSelect = true;

    public static HexTile SelectedTile { get; private set; }

    public static Action<HexTile> OnGridTileSelected = delegate { };

    public List<HexTile> CityTiles;

    private void Awake()
    {
        _input = FindObjectOfType<TouchInput>();
    }
    private void OnEnable()
    {
        TouchInput.OnClicked += SelectGridTile;
    }
    private void OnDisable()
    {
        TouchInput.OnClicked -= SelectGridTile;
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
                    OnGridTileSelected?.Invoke(null);
                }
                else
                {
                    if (CanSelect)
                    {
                        SelectedTile = tile;
                        OnGridTileSelected?.Invoke(tile);
                    }
                }
            }
            else
            {
                SelectedTile = null;
                OnGridTileSelected?.Invoke(null);
            }
        }
        else
        {
            Debug.LogFormat("No hit");
            SelectedTile = null;
            OnGridTileSelected?.Invoke(null);
        }

    }
}
