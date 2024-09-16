using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed = 2f;// Velocidad de movimiento
    public float detectionRange = 5f;// Rango de detección del jugador
    private Transform player;

    void Start()
    {
        // Buscar al jugador por su etiqueta
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Comprobar la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango, moverse hacia él
        if (distanceToPlayer < detectionRange)
        {
            // Moverse hacia la posición del jugador
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}



