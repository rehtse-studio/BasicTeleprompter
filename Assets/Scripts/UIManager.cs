using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace RehtseStudio.Teleprompter.Scrips
{
    public class UIManager : MonoBehaviour
    {
        [Header("Reference to Scrollbar and Reading Content")]
        [SerializeField] Scrollbar _verticalScrollbar;
        [SerializeField] float _verticalScrollSpeed;
        [SerializeField] private Text _readingContent;
        [SerializeField] private GameObject _soonTextGameObject;

        private FileManager _fileManager;

        private int _scrollbarIndex;

        private void Awake()
        {
            _fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
#if UNITY_STANDALONE
            _soonTextGameObject.SetActive(false);
#endif

#if UNITY_ANDROID
            _soonTextGameObject.SetActive(true);
#endif
        }

        private void Update()
        {
            if(_scrollbarIndex == 1)
            {
                _verticalScrollbar.value= _verticalScrollbar.value - (Time.deltaTime * _verticalScrollSpeed);
            }else if (_scrollbarIndex == -1)
            {
                _verticalScrollbar.value = _verticalScrollbar.value + (Time.deltaTime * _verticalScrollSpeed);
            }
        }

        public void ScrollbarIndex(int index)
        {
            _scrollbarIndex = index;
        }       

        public void OpenFileExplorer()
        {
#if UNITY_STANDALONE
            _fileManager.GetTextFileWindow();
#endif

#if UNITY_ANDROID
            _fileManager.GetTextFileAndroid();
#endif
        }

        public void PasteTextInformation()
        {
            _fileManager.PasteText();
        }

        public void TeleprompterContent(string content)
        {
            _readingContent.text = content.ToString();
        }

        public void CloseApplication()
        {
            Application.Quit();
        }
    }
}

