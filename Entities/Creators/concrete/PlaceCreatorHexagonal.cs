using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    internal class PlaceCreatorHexagonal : PlaceCreator
    {
        internal PlaceCreatorHexagonal(DirectionCalculator directionCalculator, CellsTypesRate cellsContainer)
            : base(directionCalculator, cellsContainer) {
        }

        internal override PlaceInfoCallback CreatePlace(Vector3 centerPos, int radius) {
            _placeInfoCallback = new PlaceInfoCallback();

            var centerRaw = CreateCenterHorisontalRaw(centerPos, radius);
            CreateOtherRaws(radius, centerRaw);

            return _placeInfoCallback;
        }

        protected virtual void CreateOtherRaws(int radius, (Vector3 startPoint, int rawLength) centerRaw) {
            for (int rawCounter = 1, lenght = centerRaw.rawLength - 1; rawCounter <= radius; rawCounter++, lenght--) {
                var topRaw = centerRaw.startPoint + _directions[DirectionsOfGrid.DownRight] * rawCounter;
                var bottomRaw = centerRaw.startPoint + _directions[DirectionsOfGrid.UpRight] * rawCounter;
                CreateHorizontalRaw(topRaw, lenght);
                CreateHorizontalRaw(bottomRaw, lenght);
            }
        }

        protected virtual (Vector3 startPoint, int rawLength) CreateCenterHorisontalRaw(Vector3 centerPos, int radius) {
            var startPoint = centerPos + _directions[DirectionsOfGrid.Left] * radius;
            var centerRawLenght = radius * 2 + 1;
            CreateHorizontalRaw(startPoint, centerRawLenght);
            return (startPoint, centerRawLenght);
        }
    }
}