using System;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    [Serializable]
    internal struct SceneSettings
    {
        [field: SerializeField] internal GridBuilder GridBuilder { readonly get; private set; }
        [field: SerializeField] internal Grid Grid { readonly get; private set; }
        [field: SerializeField] internal Vector3 StartPosition { readonly get; private set; }
        [field: SerializeField] internal Transform Parent { readonly get; private set; }
    }
}