using UnityEngine;

public class EnemyProximityAudio : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float triggerDistance = 5000f; // Distância para acionar o áudio
    private AudioSource audioSource; // Referência ao componente AudioSource

    void Start()
    {
        // Obtém o componente AudioSource anexado ao inimigo
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calcula a distância entre o jogador e o inimigo
        float distance = Vector3.Distance(player.position, transform.position);

        // Verifica se a distância é menor ou igual à distância de acionamento
        if (distance <= triggerDistance)
        {
            // Toca o áudio se ainda não estiver tocando
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Para o áudio se o jogador se afastar
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
