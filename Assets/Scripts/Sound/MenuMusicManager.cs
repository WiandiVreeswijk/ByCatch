using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    [Header("MenuMusic")]
    public EventReference SelectAudio;
    public new FMOD.Studio.EventInstance audio;
    private PARAMETER_ID menuMusicVolumeParameter;

    [Header("Volume Options")]
    [Range(0f, 1f)]
    public float volumeValue = 1f;

    private Tween menuMusicVolumeTween;

    private void Start()
    {
        audio = FMODUnity.RuntimeManager.CreateInstance(SelectAudio);

        FMOD.Studio.EventDescription volumeDescription;
        audio.getDescription(out volumeDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION volumeParameterDescription;
        volumeDescription.getParameterDescriptionByName("MusicVolume", out volumeParameterDescription);
        menuMusicVolumeParameter = volumeParameterDescription.id;

        FMOD.Studio.PLAYBACK_STATE PbState;
        audio.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            audio.start();
        }

    }
    private void FixedUpdate()
    {
        audio.setParameterByID(menuMusicVolumeParameter, volumeValue);
    }
    public void SetVolume(float volume)
    {
        volumeValue = volume;
        audio.setParameterByID(menuMusicVolumeParameter, volumeValue);
    }

    public float GetVolume()
    {
        float volume;
        audio.getParameterByID(menuMusicVolumeParameter, out volume);
        return volume;
    }

    public void FadeMenuMusicVolume(float volumeValue, float duration = 5f)
    {
        menuMusicVolumeTween?.Kill();
        if (duration == 0.0f)
        {
            SetVolume(volumeValue);
        }
        else
        {
            menuMusicVolumeTween = DOTween
                .To(() => GetVolume(), x => SetVolume(x), volumeValue, 1f)
                .SetEase(Ease.Linear);
        }
    }
}
