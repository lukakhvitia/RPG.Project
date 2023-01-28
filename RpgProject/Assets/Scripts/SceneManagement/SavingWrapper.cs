using RPG.Saving;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSavingFile = "save";
        [SerializeField] float fadeInTime = 0.2f;
 
        IEnumerator Start()
        {
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeOutImediately();
            yield return GetComponent<SavingSystem>().LoadLastScene(defaultSavingFile);
            yield return fader.FadeIn(fadeInTime);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSavingFile);    
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSavingFile);   
        }
    }
}
