using UnityEngine;
using UnityEngine.UI;

public class BlockSelection : MonoBehaviour
{
    private int _currentBlock = 1; // Default is crumbling block
    private LevelSerializer _serializer;

    [SerializeField]
    private Sprite[] _tilePictures;

    [SerializeField]
    private ShowHideToolbar _showHideToolbar;

    [SerializeField]
    private Image _currentBlockVisual;

    [SerializeField]
    private ShowHideEditor _editorController;

    private void Awake()
    {
        _serializer = FindObjectOfType<LevelSerializer>();
    }

    public void SetCurrent(int block)
    {
        _currentBlock = block;
        _currentBlockVisual.sprite = _tilePictures[block];
        _showHideToolbar.Hide();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_editorController.IsPanelShowing)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldCoords = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3Int tilePos = _serializer.WorldToCell(worldCoords);
            if (tilePos.y != -18) // IGNORE BOTTOM ROW!
            {
                int index = _currentBlock - 1;
                _serializer.SetTile(tilePos, _currentBlock);
            }
        }
    }
}
