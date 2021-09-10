using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolume : MonoBehaviour
{
        private AudioSource get_music;

        // Start is called before the first frame update
        void Start()
        {
                get_music = GetComponent<AudioSource>();
        }

        // Music
        public void UpdateVolumeBgMusic(float value)
        {
                get_music.volume = value;
        }
}
