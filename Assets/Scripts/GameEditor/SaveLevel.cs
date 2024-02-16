using System;
using System.IO;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    private LevelSerializer _levelSerializer;

    [SerializeField]
    private ShowHideEditor _showHideEditor;

    [SerializeField]
    private TMPro.TMP_InputField _filename;

    [SerializeField]
    public GameObject _savePanel;

    public static string SaveFolder
    {
        get
        {
            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folder = Path.Combine(myDocs, "loderunner");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return folder;
        }

    }

    private void Start()
    {
        _levelSerializer = FindObjectOfType<LevelSerializer>();
    }

    public void SaveFile()
    {
        _savePanel.SetActive(false);
        if (!string.IsNullOrEmpty(_filename.text))
        {
            string filePath = Path.Combine(SaveFolder, _filename.text);
            _levelSerializer.WriteFile(filePath);
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.S) && !_showHideEditor.IsPanelShowing)
        {
            _savePanel.SetActive(true);
        }
    }
}
