using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private Tile[] chunks;
    private int[] dx = { 1, 1, 0, -1, -1, -1, 0, 1 };
    private int[] dy = { 0, -1, -1, -1, 0, 1, 1, 1 };
    private List<Vector3Int> checkListPos = new List<Vector3Int>();
    private Vector3Int lastChunkPos;

    public void Initialize(Vector3 playerPos)
    {
        Vector3Int cellPos = map.WorldToCell(playerPos);

        map.SetTile(cellPos, GetRandomChunk());
        checkListPos.Add(cellPos);
        for (int i = 0; i < 8; i++)
        {
            Vector3Int loadPos = new Vector3Int(cellPos.x + dx[i], cellPos.y + dy[i], 0);
            map.SetTile(loadPos, GetRandomChunk());
            checkListPos.Add(loadPos);
        }

        lastChunkPos = cellPos;
    }

    public void CheckPlayerPosition(Vector3 playerPos)
    {
        Vector3Int cellPos = map.WorldToCell(playerPos);
        if (lastChunkPos != cellPos)
        {
            LoadChunk(cellPos);
        }
    }

    private void LoadChunk(Vector3Int pos)
    {
        List<Vector3Int> tmpList = new List<Vector3Int>(checkListPos);
        checkListPos.Clear();

        if (!tmpList.Contains(pos))
        {
            map.SetTile(pos, GetRandomChunk());
        }
        checkListPos.Add(pos);
        for (int i = 0; i < 8; i++)
        {
            Vector3Int loadPos = new Vector3Int(pos.x + dx[i], pos.y + dy[i], 0);
            if (!tmpList.Contains(loadPos))
            {
                map.SetTile(loadPos, GetRandomChunk());
            }
            checkListPos.Add(loadPos);
        }

        EraseChunk(lastChunkPos);

        lastChunkPos = pos;
    }

    private void EraseChunk(Vector3Int pos)
    {
        if (!checkListPos.Contains(pos))
        {
            map.SetTile(pos, null);
        }
        for (int i = 0; i < 8; i++)
        {
            Vector3Int erasePos = new Vector3Int(pos.x + dx[i], pos.y + dy[i], 0);
            if (!checkListPos.Contains(erasePos))
            {
                map.SetTile(erasePos, null);
            }
        }
    }

    private Tile GetRandomChunk()
    {
        return chunks[Random.Range(0, chunks.Length)];
    }

    public Vector3Int GetLastChunk()
    {
        return lastChunkPos;
    }
}
