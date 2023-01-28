using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour
    {
        bool isPlayed = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                if(isPlayed == false)
                {
                    GetComponent<PlayableDirector>().Play();
                }
                isPlayed = true;
            }
        }
    }
}
