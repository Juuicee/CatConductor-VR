using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSoundOffWhenHit : MonoBehaviour
{
    private AudioSource trainAudioSource;
    public AudioSource hitAudioSource;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        trainAudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "HitBox")
        {
            CancelInvoke(nameof(RestartSound));

            if (trainAudioSource.isPlaying)
            {
                trainAudioSource.Stop();
            }

            hitAudioSource.PlayOneShot(hitSound);

            Invoke(nameof(RestartSound), .5f);
        }
    }

    void RestartSound()
    {
        if (!trainAudioSource.isPlaying)
        {
            trainAudioSource.Play();
            Debug.Log("Sound Resume.");
        }
    }
}
