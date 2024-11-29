using Scripts.Tools.CustomEdit;
using UnityEngine;

namespace Scripts.Systems.GridGeneration
{
    [CreateAssetMenu(fileName = nameof(Config), menuName = DirectoryNames.GRID_SYSTEM_DATA_PATH + nameof(GridGeneration) + "/" + nameof(Config))]
    public class Config : ScriptableObject
    {
        [SerializeField] public GenerationSettings GenerationSettings;
        [SerializeField] public CellsTypesRate CellsTypesRate;
    }
}