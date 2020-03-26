using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    [SerializeField]
    private AudioSource audio;
    public void StepSound()
    {
        audio.Play();
    }
    public void RotacaoJogador (LayerMask MascaraChao)
    {
       
        
        Vector3 posicaoMiraJogador = Direcao;

        posicaoMiraJogador.y = transform.position.y;

        Rotacionar(posicaoMiraJogador);
        
    }
}
