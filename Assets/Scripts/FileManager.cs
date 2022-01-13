using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

//Plug-In
using SmartDLL;
using SimpleFileBrowser;

namespace RehtseStudio.Teleprompter.Scrips
{
    public class FileManager : MonoBehaviour
    {
        private ReadingTextManager _readintTextManager;

        private SmartFileExplorer _fileExplorer = new SmartFileExplorer();
        private bool _readyToReadText = false;

        private void Awake()
        {
            _readintTextManager = GameObject.Find("ReadingTextManager").GetComponent<ReadingTextManager>();

            FileBrowser.SetFilters(true, new FileBrowser.Filter("Text Files", ".txt"));
            FileBrowser.SetDefaultFilter(".txt");
            FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
            FileBrowser.AddQuickLink("Users", "C:\\Users", null);
        }

        #region WindowFileExplorer
        public void GetTextFileWindow()
        {
            StartCoroutine(ShowLoadDialogCoroutine());
        }

        IEnumerator ShowLoadDialogCoroutine()
        {
            yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");

            Debug.Log(FileBrowser.Success);

            if (FileBrowser.Success)
            {
                for (int i = 0; i < FileBrowser.Result.Length; i++)
                {
                    Debug.Log(FileBrowser.Result[i]);
                    _readintTextManager.ReadText(File.ReadAllText(FileBrowser.Result[i].ToString()));
                }

                byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);

                string destinationPath = Path.Combine(Application.persistentDataPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
                FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);
            }
        }
        #endregion

        #region Android And iOS File Explorer
        public void GetTextFileAndroid()
        {
            //Under Contruction :)
        }
        #endregion

        #region Paste Method
        public void PasteText()
        {
            TextEditor textEditor = new TextEditor();
            textEditor.multiline = true;
            textEditor.Paste();

            _readintTextManager.ReadText(textEditor.text);
        }
        #endregion
    }
}

