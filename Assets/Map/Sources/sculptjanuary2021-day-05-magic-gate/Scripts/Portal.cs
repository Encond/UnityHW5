using Map.Scripts;
using Map.Sources.the_kraken.Scripts;
using Map.Sources.wip_ship.Scripts;
using UnityEngine;
using UnityStandardAssets.Water;
using RenderSettings = UnityEngine.RenderSettings;

namespace Map.Sources.sculptjanuary2021_day_05_magic_gate.Scripts
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Water _water;
        [SerializeField] private Ship[] _ships;
        [SerializeField] private Material[] _skyboxes;
        [SerializeField] private Kraken _kraken;
        [SerializeField] private Spawner _spawner;

        private void OnTriggerEnter(Collider collider)
        {
            if (!collider.TryGetComponent(out Airplane.Scripts.Airplane airplane)) return;
            ChangeEnvironment();
        }

        private void ChangeEnvironment()
        {
            RenderSettings.skybox = RenderSettings.skybox == _skyboxes[0] ? _skyboxes[1] : _skyboxes[0];

            _water.gameObject.SetActive(!_water.isActiveAndEnabled);
            _kraken.gameObject.SetActive(!_kraken.isActiveAndEnabled);

            foreach (var ship in _ships)
                ship.gameObject.SetActive(!ship.isActiveAndEnabled);

            if (_spawner.ShipsCapacity <= 0)
                _spawner.CreateObjects();
            else
                _spawner.DestroyShips();
        }
    }
}