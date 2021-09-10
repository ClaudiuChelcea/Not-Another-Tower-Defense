using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
        private AudioSource audiosource;
        public AudioClip audioclip;
        
        // Start is called before the first frame update
        void Start()
        {
                audiosource = GetComponent<AudioSource>();
        }

        public void buttonHover()
        {
                audiosource.PlayOneShot(audioclip);
        }
}
