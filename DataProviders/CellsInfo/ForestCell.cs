#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = nameof(ForestCell), menuName = DirectoryNames.GRID_CELLS_PATH + nameof(ForestCell))]
#endif
    public class ForestCell : GridCellData
    {
    }
}