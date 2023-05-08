using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicManager : MonoBehaviour
{
    [Header("LevelMusic")]
    public EventReference SelectAudio;
    public new FMOD.Studio.EventInstance audio;
    private PARAMETER_ID levelMusicVolumeParameter;

    [Header("Volume Options")]
    [Range(0f, 1f)]
    public float volumeValue = 1f;

    private Tween levelMusicVolumeTween;

    private void Start()
    {
        audio = FMODUnity.RuntimeManager.CreateInstance(SelectAudio);

        FMOD.Studio.EventDescription volumeDescription;
        audio.getDescription(out volumeDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION volumeParameterDescription;
        volumeDescription.getParameterDescriptionByName("LevelMusicVolume", out volumeParameterDescription);
        levelMusicVolumeParameter = volumeParameterDescription.id;

        FMOD.Studio.PLAYBACK_STATE PbState;
        audio.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            audio.start();
        }

    }
    private void FixedUpdate()
    {
        audio.setParameterByID(levelMusicVolumeParameter, volumeValue);
    }
    public void SetVolume(float volume)
    {
        volumeValue = volume;
        audio.setParameterByID(levelMusicVolumeParameter, volumeValue);
    }

    public float GetVolume()
    {
        float volume;
        audio.getParameterByID(levelMusicVolumeParameter, out volume);
        return volume;
    }

    public void FadeLevelMusicVolume(float volumeValue, float duration = 5f)
    {
        levelMusicVolumeTween?.Kill();
        if (duration == 0.0f)
        {
            SetVolume(volumeValue);
        }
        else
        {
            levelMusicVolumeTween = DOTween
                .To(() => GetVolume(), x => SetVolume(x), volumeValue, 1f)
                .SetEase(Ease.Linear);
        }
    }
}
