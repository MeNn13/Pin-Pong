using UnityEngine;

namespace Assets.Code.Scripts.Models
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _ballSpawnPoint;
        [SerializeField] private Transform _racketFirstSpawnPoint;
        [SerializeField] private Transform _racketSecondSpawnPoint;

        public void Spawn()
        {
            DestroyObjectFromAllSpawnPoints();

            InstantiateObjectInSpawnPoint("Ball", _ballSpawnPoint);
            InstantiateObjectInSpawnPoint("Racket", _racketFirstSpawnPoint);
            InstantiateObjectInSpawnPoint("Racket", _racketSecondSpawnPoint);
        }

        private void DestroyObjectFromAllSpawnPoints()
        {
            Transform[] transforms = GetComponentsInChildren<Transform>();

            for (int i = 1; i < transforms.Length; i++)
                if (transforms[i].childCount > 0)
                    Destroy(transforms[i].GetChild(0).gameObject);
        }

        private void InstantiateObjectInSpawnPoint(string name, Transform transform)
        {
            GameObject obj = Resources.Load<GameObject>(name);
            Instantiate(obj, transform);
        }
    }
}
