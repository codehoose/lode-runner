using UnityEngine;

public class ShowHideEditor : MonoBehaviour
{
    [SerializeField]
    private GameObject _editor;

    [SerializeField]
    private GameObject _savePanel;

    [SerializeField]
    private GameObject _toolBoxPanel;

    [SerializeField]
    private GameObject _loadPanel;

    public bool IsPanelShowing => _savePanel.activeInHierarchy ||
                                  _toolBoxPanel.activeInHierarchy ||
                                  _loadPanel.activeInHierarchy;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _editor.SetActive(!_editor.activeInHierarchy);
        }
    }
}
