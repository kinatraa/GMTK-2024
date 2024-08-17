using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private Tile chunk;
    private int[] dx = { 1, 1, 0, -1, -1, -1, 0, 1 };
    private int[] dy = { 0, -1, -1, -1, 0, 1, 1, 1 };
    private List<Vector3Int> checkListPos = new List<Vector3Int>();
    private Vector3Int lastChunkPos;

    public void Initialize(Vector3 playerPos)
    {
        Vector3Int cellPos = map.WorldToCell(playerPos);

        map.SetTile(cellPos, chunk);
        checkListPos.Add(cellPos);
        for (int i = 0; i < 8; i++)
        {
            Vector3Int loadPos = new Vector3Int(cellPos.x + dx[i], cellPos.y + dy[i], 0);
            map.SetTile(loadPos, chunk);
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
        checkListPos.Clear();

        map.SetTile(pos, chunk);
        checkListPos.Add(pos);
        for (int i = 0; i < 8; i++)
        {
            Vector3Int loadPos = new Vector3Int(pos.x + dx[i], pos.y + dy[i], 0);
            map.SetTile(loadPos, chunk);
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

    public Vector3Int GetLastChunk()
    {
        return lastChunkPos;
    }
}
