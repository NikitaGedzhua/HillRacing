using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ObstacleChunkPool : MonoBehaviour
{
    [SerializeField] private CarLogic carLogic;
    [SerializeField] private GameObject[] chunkPrefabs;

    private readonly List<GameObject> _chunks = new();
    
    private int _currentChunkIndex;
    private int _previousChunkIndex;
    private float _chunkSizeX;
    private float _chunkHalfSizeX;
    private float _offsetX = 1;
    
    private void Start()
    {
         _chunkSizeX = chunkPrefabs[0].GetComponent<SpriteShapeRenderer>().bounds.size.x;
         _chunkHalfSizeX = _chunkSizeX / 2f;
         
        for (int i = 0; i < chunkPrefabs.Length; i++)
        {
            GameObject chunk = Instantiate(chunkPrefabs[i], transform.position + new Vector3(i * _chunkSizeX, 0f, 0f), Quaternion.identity, transform);
            chunk.SetActive(false);
            _chunks.Add(chunk);
        }

        _currentChunkIndex = 0;
        _chunks[_currentChunkIndex].SetActive(true);
    }

    private void Update()
    {
        if (carLogic.transform.position.x >= _chunks[_currentChunkIndex].transform.position.x + _chunkHalfSizeX)
        {
            _previousChunkIndex = _currentChunkIndex;
            _currentChunkIndex = (_currentChunkIndex + 1) % chunkPrefabs.Length;
            _chunks[_currentChunkIndex].transform.position = _chunks[_previousChunkIndex].transform.position + new Vector3(_chunkSizeX - _offsetX, 0f, 0f);
            _chunks[_currentChunkIndex].SetActive(true);
        }
    }
}
