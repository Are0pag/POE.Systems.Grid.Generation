#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = nameof(GrassCell), menuName = DirectoryNames.GRID_CELLS_PATH + nameof(GrassCell))]
#endif
    public class GrassCell : GridCellData
    {
    }
}