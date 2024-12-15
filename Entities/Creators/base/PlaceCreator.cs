using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    internal abstract class PlaceCreator
    {
        protected readonly CellsTypesRate _cellsContainer;
        protected readonly Dictionary<DirectionsOfGrid, Vector3> _directions;
        protected PlaceInfoCallback _placeInfoCallback;

        internal PlaceCreator(DirectionCalculator directionsCalculator, CellsTypesRate cellsContainer) {
            _directions = directionsCalculator.GetGridDirections();
            _cellsContainer = cellsContainer;
        }

        internal abstract PlaceInfoCallback CreatePlace(Vector3 centerPos, int radius);

        protected virtual void CreateHorizontalRaw(Vector3 startPoint, int lenght) {
            for (var i = 0; i < lenght; i++) {
                var step = startPoint + _directions[DirectionsOfGrid.Right] * i;
                RegisterCell(ref lenght, ref i, ref step);
            }
        }

        protected virtual void RegisterCell(ref int lenght, ref int i, ref Vector3 step) {
            var cellType = _cellsContainer.GetCellType();
            _placeInfoCallback.PositionsOfCells.Add(step, cellType);
            if (i == lenght - 1) 
                _placeInfoCallback.Edged.Add(step);
        }
    }
}