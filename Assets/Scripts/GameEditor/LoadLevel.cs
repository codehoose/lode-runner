using JetBrains.Annotations;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    private string[] _filenames;

    [SerializeField]
    private LevelSerializer _serializer;

    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private GameObject _parentPanel;

    private void Start()
    {
        _serializer = FindObjectOfType<LevelSerializer>();
    }

    private void OnEnable()
    {
        _filenames = Directory.GetFiles(SaveLevel.SaveFolder, "*.json")
                              .Select(file => Path.GetFileNameWithoutExtension(file))
                              .ToArray();

        int childCount = _panel.transform.childCount;
        for (int i = 1; i < childCount; i++)
        {
            Destroy(_panel.transform.GetChild(i).gameObject);
        }

        GameObject template = _panel.transform.GetChild(0).gameObject;

        foreach (string filename in _filenames)
        {
            GameObject copy = Instantiate(template, _panel.transform);
            copy.GetComponentInChildren<TMPro.TMP_Text>().text = filename;
            copy.SetActive(true);

            copy.GetComponent<Button>().onClick.AddListener(() =>
            {
                string fullPath = Path.Combine(SaveLevel.SaveFolder, $"{filename}.json");
                _serializer.ReadFile(fullPath);
                _parentPanel.SetActive(false);
            });
        }
    }
}
