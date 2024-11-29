using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Scripts.Systems.GridGeneration
{
    public abstract class GridCellData : ScriptableObject, IGridCellData
    {
        [SerializeField] protected GameObject[] _prefabsVariants;
        [SerializeField] private bool isMovable;
        [FormerlySerializedAs("_passability")] [SerializeField] [Range(0f, 1f)]
        private float _moveAbility;

        public GameObject Prefab {
            get {
                var ind = new Random().Next(0, _prefabsVariants.Length);
                return _prefabsVariants[ind];
            }
        }
        public bool IsMovable => isMovable;
        public float MoveAbility => _moveAbility;
    }
}