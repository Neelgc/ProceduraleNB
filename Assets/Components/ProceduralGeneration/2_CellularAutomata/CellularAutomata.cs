using Components.ProceduralGeneration;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using VTools.Grid;

[CreateAssetMenu(fileName = "CellularAutomata", menuName = "Scriptable Objects/CellularAutomata")]
public class CellularAutomata : ProceduralGenerationMethod
{
    [SerializeField] private int _noiseDensity = 50;
    [SerializeField] private int _grassBirthThreshold = 5;  
    [SerializeField] private int _grassSurvivalThreshold = 4;  
    [SerializeField] private bool _considerBordersAsWater = true;

    private bool[,] _currentState; 
    protected override async UniTask ApplyGeneration(CancellationToken cancellationToken)
    {
        _currentState = new bool[Grid.Width, Grid.Lenght];

        InitializeRandomGrid();
        await UniTask.Delay(GridGenerator.StepDelay, cancellationToken: cancellationToken);

        for (int step = 0; step < _maxSteps; step++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ApplyCellularAutomataStep();

            await UniTask.Delay(GridGenerator.StepDelay, cancellationToken: cancellationToken);
        }
    }

    private void InitializeRandomGrid()
    {
        for (int x = 0; x < Grid.Width; x++)
        {
            for (int y = 0; y < Grid.Lenght; y++)
            {
                if (Grid.TryGetCellByCoordinates(x, y, out Cell cell))
                {
                    int randomValue = RandomService.Range(0, 100);
                    bool isGrass = randomValue < _noiseDensity;

                    _currentState[x, y] = isGrass;

                    string tileName = isGrass ? GRASS_TILE_NAME : WATER_TILE_NAME;
                    AddTileToCell(cell, tileName, true);
                }
            }
        }
    }

    private void ApplyCellularAutomataStep()
    {
        bool[,] nextState = new bool[Grid.Width, Grid.Lenght];

        for (int x = 0; x < Grid.Width; x++)
        {
            for (int y = 0; y < Grid.Lenght; y++)
            {
                int grassNeighbors = CountGrassNeighbors(x, y);
                bool isCurrentlyGrass = _currentState[x, y];

                if (isCurrentlyGrass)
                {
                    nextState[x, y] = grassNeighbors >= _grassSurvivalThreshold;
                }
                else
                {
                    nextState[x, y] = grassNeighbors >= _grassBirthThreshold;
                }
            }
        }

        _currentState = nextState;

        ApplyStateToGrid();
    }

    private int CountGrassNeighbors(int x, int y)
    {
        int count = 0;

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0)
                    continue;

                int neighborX = x + dx;
                int neighborY = y + dy;

                if (neighborX < 0 || neighborX >= Grid.Width ||
                    neighborY < 0 || neighborY >= Grid.Lenght)
                {
                    if (_considerBordersAsWater)
                        continue;
                    else
                        count++; 

                    continue;
                }

                if (_currentState[neighborX, neighborY])
                {
                    count++;
                }
            }
        }

        return count;
    }

    private void ApplyStateToGrid()
    {
        for (int x = 0; x < Grid.Width; x++)
        {
            for (int y = 0; y < Grid.Lenght; y++)
            {
                if (Grid.TryGetCellByCoordinates(x, y, out Cell cell))
                {
                    string tileName = _currentState[x, y] ? GRASS_TILE_NAME : WATER_TILE_NAME;
                    AddTileToCell(cell, tileName, true);
                }
            }
        }
    }
}