using System;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    [Serializable]
    public struct GenerationSettings
    {
        [field: SerializeField]
        [field: Range(0, 3000)]
        public int DefaultLocationLenght { get; private set; }
        
        [field: SerializeField]
        [field: Range(0, 300)]
        public int LocationLengthVariability { get; private set; }
        
        [field: SerializeField]
        [field: Range(0, 15)]
        public int DefaultRadius { get; private set; }
        
        [field: SerializeField]
        [field: Range(0, 20)]
        public int RaduisVariability { get; private set; }
    }
}