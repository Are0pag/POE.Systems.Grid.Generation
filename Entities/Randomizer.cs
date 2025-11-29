using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Scripts.Systems.GridGeneration
{
    internal class Randomizer
    {
        protected readonly Dictionary<DirectionsOfGrid, Vector3> _directions;
        protected readonly GenerationSettings _settings;

        protected readonly Random _random = new Random();

        internal Randomizer(DirectionCalculator directionCalculator, GenerationSettings settings) {
            _directions = directionCalculator.GetGridDirections();
            _settings = settings;
        }

        internal virtual int GetRadiusRand() {
            return _settings.DefaultRadius +
                   _random.Next(-_settings.RadiusVariability, _settings.RadiusVariability);
        }

        internal virtual int GetLocationLengthRand() {
            return _settings.DefaultLocationLenght +
                   _random.Next(-_settings.LocationLengthVariability, _settings.LocationLengthVariability);
        }

        internal virtual Vector3 GetDirectionRand() {
            var rand = _random.Next(0, 2);

            return rand switch {
                0 => _directions[DirectionsOfGrid.UpRight],
                _ => _directions[DirectionsOfGrid.DownRight]
            };
        }
    }
}