using System;
using System.Linq;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    internal class GenerationBehaviour
    {
        protected readonly GenerationInfoCallback _callback;
        protected readonly CreationController _creationController;
        protected readonly Randomizer _rand;

        /// <summary>
        ///     Include sum of all Places Length
        /// </summary>
        protected float _currentLengthOfLocation;
        protected PlaceInfoCallback _previousResultsOfCreation;

        public GenerationBehaviour(CreationController creationController, DirectionCalculator directionCalculator, Randomizer rand) {
            _callback = new GenerationInfoCallback {
                Directions = directionCalculator.GetGridDirections()
            };
            _creationController = creationController;
            _rand = rand;
        }

        public virtual GenerationInfoCallback SetLocationRecursive() {
            var desiredLength = _rand.GetLocationLengthRand();
            try {
                SetMainBranch(desiredLength);
            }
            catch (StackOverflowException) {
#if UNITY_EDITOR
                Debug.Log($"catch {nameof(StackOverflowException)} from {nameof(GenerationBehaviour)}");
#endif
            }

            return _callback;
        }

        protected virtual void SetMainBranch(int desiredLength) {
            SetPlace();
            if (_currentLengthOfLocation < desiredLength) 
                SetMainBranch(desiredLength);
        }

        protected virtual void SetPlace() {
            var actualResults = _creationController.Generate(_previousResultsOfCreation);
            _previousResultsOfCreation = actualResults;
            FixateProgress();
        }


        protected virtual void FixateProgress() {
            var rigthCornerOfGeneratedPlaceX = _previousResultsOfCreation.Edged.First().x;
            _currentLengthOfLocation += rigthCornerOfGeneratedPlaceX;

            foreach (var newCell in _previousResultsOfCreation.PositionsOfCells) 
                _callback.MapInfo.TryAdd(newCell.Key, newCell.Value);
        }
    }
}