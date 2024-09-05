using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;

    [Header("Music Info")]
    [SerializeField]
    private bool isMusicPaused = false;

    public AudioClip[] songs;
    private AudioSource audioSourceComponent;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        audioSourceComponent = GetComponent<AudioSource>();

    }

    public static MusicManager Instance
    {
        get
        {
            if (!_instance)
            {
                var gameManagerPrefab = Resources.Load<GameObject>("Tools/_MusicManager");
                var gameManagerObject = Instantiate<GameObject>(gameManagerPrefab);

                _instance = gameManagerObject.GetComponentInChildren<MusicManager>();

                if (!_instance)
                {
                    _instance = gameManagerObject.AddComponent<MusicManager>();
                }

                DontDestroyOnLoad(_instance.transform.root.gameObject);
            }
            return _instance;
        }
    }

    public void PlayARandomSong()
    {
        audioSourceComponent.clip = songs.First();
        audioSourceComponent.Play();
    }

    public void PlayVictoryFanfare()
    {
        audioSourceComponent.clip = songs.Last();
        audioSourceComponent.Play();
    }
}
