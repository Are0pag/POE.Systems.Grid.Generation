namespace Scripts.Systems.GridGeneration
{
    internal class RandomizerContext : Randomizer
    {
        protected readonly ContextGridGenerationSettings _contextSettings;

        internal RandomizerContext(DirectionCalculator directionCalculator, GenerationSettings settings, ContextGridGenerationSettings contextSettings)
            : base(directionCalculator, settings) 
        {
            _contextSettings = contextSettings;
        }

        internal override int GetRadiusRand() {
            if (_settings.DefaultRadius == _contextSettings.DefaultRadius && _settings.RadiusVariability == _contextSettings.RadiusVariability)
                return base.GetRadiusRand();

            return _contextSettings.DefaultRadius +
                   _random.Next(-_contextSettings.RadiusVariability, _contextSettings.RadiusVariability);
        }

        internal override int GetLocationLengthRand() {
            if (_settings.DefaultLocationLenght == _contextSettings.DefaultLocationLenght && _settings.LocationLengthVariability == _contextSettings.LocationLengthVariability)
                return base.GetLocationLengthRand();
            
            return _contextSettings.DefaultLocationLenght + 
                   _random.Next(-_contextSettings.LocationLengthVariability, _contextSettings.LocationLengthVariability);
        }
    }
}