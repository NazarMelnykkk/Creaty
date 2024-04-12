using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectsControlller : MonoBehaviour
{

    [SerializeField] private InteractableObject _interactableObjectPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private KeyCounterView _keyCounterView;

    private List<InteractableObject> _objects = new();

    private int _minSpawnCount = 2;
    private int _objectsToSpawn;
    private int _currentCount = 0;

    private void Start()
    {
        _objectsToSpawn = Random.Range(_minSpawnCount, _spawnPoints.Count);
        SpawnObjects(_objectsToSpawn);
        _keyCounterView.SetKeyCount(0 , _objectsToSpawn);
    }

    private void SpawnObjects(int objectsToSpawn)
    {
        List<Transform> availableSpawnPoints = new List<Transform>(_spawnPoints); 

        for (int i = 0; i < objectsToSpawn; i++)
        {
            if (availableSpawnPoints.Count == 0)
            {
                Debug.LogWarning("Not enough spawn points available for desired object count.");
                break;
            }

            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform spawnPoint = availableSpawnPoints[randomIndex];
            availableSpawnPoints.RemoveAt(randomIndex);

            InteractableObject newObject = Instantiate(_interactableObjectPrefab, spawnPoint.position, Quaternion.identity);
            newObject.Init(this);
            _objects.Add(newObject);
        }
    }

    public void ObjectInteract(InteractableObject interactableObject)
    {
        if (_objects.Contains(interactableObject))
        {
            _objects.Remove(interactableObject);
            Destroy(interactableObject.gameObject);
            _currentCount++;
        }

        RemoveEmptySpots(_objects);

        _keyCounterView.SetKeyCount(_currentCount, _objectsToSpawn);

        if (_objects.Count <= 0)
        {
            GameEventHandler.Instance.MiscEvents.AllCollectKeysComplete();
        }
    }
    private void RemoveEmptySpots<T>(List<T> list)
    {
        list.RemoveAll(item => item == null);
    }
}
