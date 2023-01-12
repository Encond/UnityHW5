using System.Collections.Generic;
using System.Linq;
using Map.Sources.wip_ship.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [Header("Target options")] [SerializeField]
        private Ship _target;

        [SerializeField] private int _count = 20;

        [Header("Spawn ranges")] [SerializeField]
        private int _xRangeStart = -10500;

        [SerializeField] private int _xRangeEnd = 1000;
        [SerializeField] private int _zRangeStart = 1000;
        [SerializeField] private int _zRangeEnd = 1500;

        [Header("Positions")] [SerializeField] private Transform _parentPosition;

        private List<Ship> _ships;
        public int ShipsCapacity => _ships.Count;

        private void Start() => _ships = new List<Ship>();

        public void CreateObjects()
        {
            for (int i = 0; i < _count; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(_xRangeStart, _xRangeEnd), 10f,
                    Random.Range(_zRangeStart, _zRangeEnd));

                _ships.Add(Instantiate(_target, randomPosition, Quaternion.identity, _parentPosition));
                _ships.Last().gameObject.SetActive(true);
            }
        }

        public void DestroyShips()
        {
            foreach (var ship in _ships)
                Destroy(ship.gameObject);

            _ships.Clear();
        }
    }
}