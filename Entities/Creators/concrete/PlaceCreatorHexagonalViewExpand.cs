using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    internal class PlaceCreatorHexagonalViewExpand : PlaceCreatorHexagonal
    {
        internal PlaceCreatorHexagonalViewExpand(DirectionCalculator directionCalculator, CellsTypesRate cellsContainer) 
            : base(directionCalculator, cellsContainer) {
        }

        internal override PlaceInfoCallback CreatePlace(Vector3 centerPos, int radius) {
            var callback = base.CreatePlace(centerPos, radius);
            callback.PlaceCenter = centerPos;
            return callback;
        }
    }
}