using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }
    private void Awake()
    {
        //ΩÃ±€≈Ê...¿∏∑Œ «ÿµµ µ .
        /*int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }*/

        if(Instance != null && Instance != this)
        {
            Destroy(this);         
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);

        }

    }
}
