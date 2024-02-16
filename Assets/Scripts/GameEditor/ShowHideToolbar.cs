using UnityEngine;

public class ShowHideToolbar : MonoBehaviour
{
    /// <summary>
    /// Toolbar
    /// </summary>
    [SerializeField]
    private GameObject _toolbar;

    public bool IsShowing => _toolbar.activeInHierarchy;

    public void Hide()
    {
        _toolbar.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightBracket))
        {
            _toolbar.SetActive(!_toolbar.activeInHierarchy);
        }
    }
}
