using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefabricate;
    [SerializeField] private Transform _cam;
    private int compteur=1;

    private void Start()
    {
        generateGrid();
    }
    private void generateGrid() 
    {
        for(int x = 0; x < _width; x++) 
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefabricate, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {compteur}";

                var isOffset =(x % 2 == 0 && y % 2 != 0)|| (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                compteur++;
            }
        }
    _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2-0.5f, -10);
    }
}
