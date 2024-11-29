using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    public sealed class DirectionCalculator
    {
        private readonly Dictionary<DirectionsOfGrid, Vector3> _directions;
        private readonly Grid _grid;
        private readonly Vector3Int _virtualPos = new(0, 0, 0);
        private readonly Vector3 _virtualPositionInWorld;

        internal DirectionCalculator(Grid grid) {
            _grid = grid;
            _virtualPositionInWorld = _grid.GetCellCenterWorld(_virtualPos);
            _directions = CreateGridDirections();
        }

        public Dictionary<DirectionsOfGrid, Vector3> GetGridDirections() {
            return _directions;
        }

        private Dictionary<DirectionsOfGrid, Vector3> CreateGridDirections() {
            var directions = new Dictionary<DirectionsOfGrid, Vector3> {
                { DirectionsOfGrid.Right, GetDirection(1, 0) },
                { DirectionsOfGrid.Left, GetDirection(-1, 0) },
                { DirectionsOfGrid.UpRight, GetDirection(0, 1) },
                { DirectionsOfGrid.UpLeft, GetDirection(-1, 1) },
                { DirectionsOfGrid.DownLeft, GetDirection(-1, -1) },
                { DirectionsOfGrid.DownRight, GetDirection(0, -1) }
            };
            return directions;
        }

        private Vector3 GetDirection(int offsetX, int offsetY) {
            var stepToRight =
                _grid.GetCellCenterWorld(
                    new Vector3Int(_virtualPos.x + offsetX, _virtualPos.y + offsetY, _virtualPos.z));
            var direction = stepToRight - _virtualPositionInWorld;
            return direction;
        }

#if UNITY_EDITOR
        public void Print() {
            foreach (var direction in _directions) Debug.Log(direction.Key + " - " + direction.Value);
        }
#endif
    }
}