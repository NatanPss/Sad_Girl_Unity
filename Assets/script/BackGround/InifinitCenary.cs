using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InifinitCenary : MonoBehaviour
{
    private float CenarySpeed = 0.5f;
    [System.Serializable]
    public struct Cenary
    {
        public string nomeDoCenario;       // Nome identificador
        public GameObject cenary;          // O Prefab ou GameObject do cenário
        public Vector3 posicaoDeSpawn;     // Um vetor de posição para onde o jogador vai
        public bool estaDesbloqueado;      // Controle de progresso
    }
    void Start()
    {
        // Start is called before the first frame update
    }
    void Update()
    {
    }

    private void CenaryMoviment()
    {
        Vector2 deslocament = new Vector2(CenarySpeed * Time.deltaTime, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocament;

    }
    private void reset() {
        CenarySpeed = 0;
    }
}
