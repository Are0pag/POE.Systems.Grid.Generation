namespace Scripts.Systems.GridGeneration
{
    public class ContextGridGenerationSettings
    {
        private int _defaultLocationLenght;
        public int DefaultLocationLenght {
            get => _defaultLocationLenght;
            private set => _defaultLocationLenght = value;
        }
        
        private int _locationLengthVariability;
        public int LocationLengthVariability {
            get => _locationLengthVariability;
            private set => _locationLengthVariability = value;
        }
        
        private int _defaultRadius;
        public int DefaultRadius {
            get => _defaultRadius;
            private set => _defaultRadius = value;
        }
        
        private int _radiusVariability;
        public int RadiusVariability {
            get => _radiusVariability;
            private set => _radiusVariability = value;
        }
    }
}