using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioMixer backgroundmusic;
    public AudioMixer soundEffects;
    public AudioSource backGroundAudioSource;
    public AudioClip[] backGroundTracks;
    int index;
    public Rigidbody golfBallRigidBody;
    public AudioSource golfBallAudio;
    public AudioClip golfHitSound;
    public AudioClip golfBounce;
    private float speed;
    public float hitVolume;

    float backgroundMusicSlider;
    float soundEffectsSlider;

    public Slider backgroundMusicSliderObject;
    public Slider soundEffectsSliderObject;

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range (0, backGroundTracks.Length);
        backGroundAudioSource.PlayOneShot(backGroundTracks[index], 0.7f);

        backgroundMusicSlider = PlayerPrefs.GetFloat("backgroundMusicSlider");
        backgroundMusicSliderObject.value = backgroundMusicSlider;

        soundEffectsSlider = PlayerPrefs.GetFloat("soundEffectsSlider");
        soundEffectsSliderObject.value = soundEffectsSlider;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GolfBallHit()
    {
        golfBallAudio.pitch = Random.Range (0.8f, 1f);
        golfBallAudio.PlayOneShot(golfHitSound, 0.7f);
    }

    public void GolfBallBounce()
    {
        golfBallAudio.pitch = Random.Range (0.8f, 1f);
        speed = golfBallRigidBody.velocity.magnitude;
        golfBallAudio.PlayOneShot(golfBounce, speed * hitVolume);
    }

    public void SetMusicLevel (float sliderValue)
    {
        backgroundMusicSlider = sliderValue;
        backgroundmusic.SetFloat("MusicVolume", Mathf.Log10 (backgroundMusicSlider) * 20);
        PlayerPrefs.SetFloat("backgroundMusicSlider", backgroundMusicSlider);
        PlayerPrefs.Save();
    }

    public void SetSoundEffectLevel (float sliderValue)
    {
        soundEffectsSlider = sliderValue;
        soundEffects.SetFloat("SoundEffectsVolume", Mathf.Log10 (soundEffectsSlider) * 20);
        PlayerPrefs.SetFloat("soundEffectsSlider", soundEffectsSlider);
        PlayerPrefs.Save();
    }
}
