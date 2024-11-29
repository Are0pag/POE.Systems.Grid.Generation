﻿using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    public class GenerationInfoCallback
    {
        public readonly Dictionary<Vector3, IGridCellData> MapInfo = new();
        public Dictionary<DirectionsOfGrid, Vector3> Directions;
    }
}