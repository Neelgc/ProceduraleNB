using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VTools.Grid;
using VTools.ScriptableObjectDatabase;

namespace Components.ProceduralGeneration.SimpleRoomPlacement
{
    [CreateAssetMenu(menuName = "Procedural Generation Method/Simple Room Placement")]
    public class SimpleRoomPlacement : ProceduralGenerationMethod
    {
        [Header("Room Parameters")]
        [SerializeField] private int _maxRooms = 10;
        [SerializeField] private Vector2Int _roomSizeMin = new Vector2Int(3, 3);
        [SerializeField] private Vector2Int _roomSizeMax = new Vector2Int(7, 7);

        protected override async UniTask ApplyGeneration(CancellationToken cancellationToken)
        {
            // Declare variables here
            int roomCount = 0;

            for (int i = 0; i < _maxSteps; i++)
            {
                // Check for cancellation
                cancellationToken.ThrowIfCancellationRequested();

                if (roomCount >= _maxRooms)
                    break;

                int roomWidth = RandomService.Range(_roomSizeMin.x, _roomSizeMax.x + 1);
                int roomLength = RandomService.Range(_roomSizeMin.y, _roomSizeMax.y + 1);

                if (roomWidth > Grid.Width || roomLength > Grid.Lenght)
                {
                    await UniTask.Delay(GridGenerator.StepDelay, cancellationToken: cancellationToken);
                    continue;
                }

                int posX = RandomService.Range(0, Grid.Width - roomWidth);
                int posZ = RandomService.Range(0, Grid.Lenght - roomLength);

                var roomRect = new RectInt(posX, posZ, roomWidth, roomLength);

                const int spacing = 1;
                if (!CanPlaceRoom(roomRect, spacing))
                {
                    await UniTask.Delay(GridGenerator.StepDelay, cancellationToken: cancellationToken);
                    continue;
                }

                for (int x = roomRect.xMin; x < roomRect.xMax; x++)
                {
                    for (int z = roomRect.yMin; z < roomRect.yMax; z++)
                    {
                        if (!Grid.TryGetCellByCoordinates(x, z, out var chosenCell))
                        {
                            Debug.LogError($"Unable to get cell on coordinates : ({x}, {z})");
                            continue;
                        }

                        AddTileToCell(chosenCell, "Room", true);
                    }
                }

                roomCount++;
                // Waiting between steps to see the result.
                await UniTask.Delay(GridGenerator.StepDelay, cancellationToken: cancellationToken);
            }

            // Final ground building.
            BuildGround();
        }

        private void BuildGround()
        {
            var groundTemplate = ScriptableObjectDatabase.GetScriptableObject<GridObjectTemplate>("Grass");

            // Instantiate ground blocks
            for (int x = 0; x < Grid.Width; x++)
            {
                for (int z = 0; z < Grid.Lenght; z++)
                {
                    if (!Grid.TryGetCellByCoordinates(x, z, out var chosenCell))
                    {
                        Debug.LogError($"Unable to get cell on coordinates : ({x}, {z})");
                        continue;
                    }

                    GridGenerator.AddGridObjectToCell(chosenCell, groundTemplate, false);
                }
            }
        }
        private void PlaceRoom(RectInt room)
        {
            for (int ix = room.xMin; ix < room.xMax; ix++)
            {
                for (int iy = room.yMin; iy < room.yMax; iy++)
                {
                    if (!Grid.TryGetCellByCoordinates(ix, iy, out var cell))
                        continue;

                    AddTileToCell(cell, ROCK_TILE_NAME, true);
                }
            }
        }
    }
}



