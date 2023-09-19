using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocita = 5.0f; // Velocità di movimento della sfera
    public float forzaSalto = 10.0f; // Forza del salto
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ottieni l'input dall'asse orizzontale (tasti freccia sinistra e destra)
        float movimentoOrizzontale = Input.GetAxis("Horizontal");

        // Calcola la forza da applicare per il movimento orizzontale
        Vector3 forzaMovimento = new Vector3(movimentoOrizzontale * velocita, 0, 0);

        float movimentoAvanti = Input.GetAxis("Vertical");

        Vector3 forzaAvanti = new Vector3(0, 0, movimentoAvanti * velocita);

        // Applica la forza al Rigidbody per il movimento orizzontale
        rb.AddForce(forzaMovimento);
        rb.AddForce(forzaAvanti);

        // Se il giocatore preme il tasto di salto (spazio), applica una forza verso l'alto
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * forzaSalto, ForceMode.Impulse);
        }
    }
}
