// MARIANO CODUTTI ALARCON
using UnityEngine;
using TMPro;

public class WavesUI : MonoBehaviour
{
    [SerializeField] private TMP_Text wavesText;

    private WaveSpawner waveSpawner;


    private void Start()
    {
        waveSpawner = FindAnyObjectByType<WaveSpawner>();
    }

    private void Update()
    {
        wavesText.text = PlayerStats.waves + "/" + waveSpawner.GetWavesAmount();
    }
}
