using UnityEngine;

public class ShowLoadLevel : MonoBehaviour
{
    [SerializeField]
    private ShowHideEditor _showHideEditor;

    [SerializeField]
    private GameObject _loadLevel;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L) && !_showHideEditor.IsPanelShowing)
        {
            _loadLevel.SetActive(true);
        }
    }
}
