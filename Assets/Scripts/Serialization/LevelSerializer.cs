using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelSerializer : MonoBehaviour
{
    public static readonly int SCREEN_WIDTH_BLOCKS = 32;
    public static readonly int SCREEN_HEIGHT_BLOCKS = 18;

    private GameLevelData _data;

    [SerializeField]
    private Tilemap _tilemap;

    [SerializeField]
    private Tile[] _tiles;

    private void Start()
    {
        _data ??= CreateDefault();
    }

    public void WriteFile(string filePath)
    {
        string json = JsonUtility.ToJson(_data);
        File.WriteAllText(filePath, json);
    }

    internal void ReadFile(string fullPath)
    {
        string json = File.ReadAllText(fullPath);
        _data = JsonUtility.FromJson<GameLevelData>(json);
        RenderLevel();
    }

    public Vector3Int WorldToCell(Vector3 pos)
    {
        return _tilemap.WorldToCell(pos);
    }

    public void SetTile(Vector3Int pos, int blockIndex)
    {
        int x = pos.x;
        int y = -pos.y;

        _data.blocks[y * SCREEN_WIDTH_BLOCKS + x] = blockIndex;
        _tilemap.SetTile(pos, blockIndex == 0 ? null : Instantiate(_tiles[blockIndex - 1]));
    }

    public void ClearBlocks()
    {
        _tilemap.ClearAllTiles();
        _data.blocks = new int[SCREEN_WIDTH_BLOCKS * SCREEN_HEIGHT_BLOCKS];
    }

    private void RenderLevel()
    {
        for (int y = 0; y < SCREEN_HEIGHT_BLOCKS; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH_BLOCKS; x++)
            {
                int index = _data.blocks[y * SCREEN_WIDTH_BLOCKS + x];
                Vector3Int pos = new Vector3Int(x, -y);
                _tilemap.SetTile(pos, index == 0 ? null : Instantiate(_tiles[index - 1]));
            }
        }
    }

    private GameLevelData CreateDefault()
    {
        GameLevelData data = new GameLevelData();
        data.blocks = new int[SCREEN_WIDTH_BLOCKS * SCREEN_HEIGHT_BLOCKS];
        return data;
    }
}
