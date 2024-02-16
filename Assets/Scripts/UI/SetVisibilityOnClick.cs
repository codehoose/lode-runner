using UnityEngine;
using UnityEngine.UI;

public class SetVisibilityOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private bool _targetVisibility;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                _target.SetActive(_targetVisibility);
            });
        }
    }
}
