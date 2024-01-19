using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spreads : MonoBehaviour
{
    //sizeX and sizeY are the amount of cells 
    [SerializeField]
    int sizeX;
    [SerializeField]
    int sizeY;

    [SerializeField]
    Vector2 bottomLeftCorner;

    //The number of subdivisions of each unity unit in the grid
    [SerializeField]
    int resolution;

    private bool[,] points;
    private int[,] cells;

    Tilemap tilemap;
    Grid grid;

    void Awake()
    {
        //Creates an array of points that hold whether or not they've been buttered
        points = new bool[sizeX*resolution + 1,sizeY*resolution + 1];
        cells = new int[sizeX * resolution, sizeY * resolution];

        tilemap = GetComponent<Tilemap>();
        grid = GetComponent<Grid>();
        grid.cellSize = new Vector3(sizeX * resolution, sizeY * resolution, 1);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddSpread(Vector2 position, float radius)
    {
        //Converts position so bottom left corner is origin
        position -= bottomLeftCorner;

        // TODO: Optimize this to only check nearby points, somehow.
        for (int i = 0; i < points.GetLength(0); i++)
        {
            for (int j = 0; j < points.GetLength(1); j++)
            {
                if (Vector2.Distance(new Vector2(i * resolution, j * resolution), position) <= radius)
                {
                    points[i, j] = true;
                }
            }
        }

        UpdateSpread();
    }

    
    private void UpdateSpread()
    {
        //evil marching squares bit level hacking
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                int cellValue = 0;
                //Bottom left
                if (points[i, j])
                {
                    cellValue += 1;
                }

                //Bottom Right
                if (points[i+1, j])
                {
                    cellValue += 2;
                }

                //Top Right
                if (points[i + 1, j + 1])
                {
                    cellValue += 4;
                }

                //Top Left
                if (points[i, j + 1])
                {
                    cellValue += 8;
                }
            }
        }
    }

    /// <summary>
    /// Takes a position and returns the indices of the cell at that position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private Vector2 CellFromPosition(Vector2 position)
    {
        //Converts position so bottom left corner is origin
        position -= bottomLeftCorner;
        
        int xCell = (int)(position.x * resolution);    
        int yCell = (int)(position.y * resolution);

        return new Vector2(xCell, yCell);
    }
    
    public bool OnButter(Vector2 position)
    {
        Vector2 cell = CellFromPosition(position);
        if (cells[(int)cell.x, (int)cell.y] > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
