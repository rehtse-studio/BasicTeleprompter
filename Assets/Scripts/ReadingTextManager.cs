using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RehtseStudio.Teleprompter.Scrips
{
    public class ReadingTextManager : MonoBehaviour
    {
        private UIManager _uiManager;
       
        private void Awake()
        {
            _uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        }
        
        public void ReadText(string document)
        {
            _uiManager.TeleprompterContent(document);
        }
    }
}

