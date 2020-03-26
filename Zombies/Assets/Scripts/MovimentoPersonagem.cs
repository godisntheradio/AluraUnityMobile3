using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody meuRigidbody;
    public Vector3 Direcao { get; protected set; }

    void Awake ()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }
    public void SetDirecao(Vector2 dir)
    {
        Direcao = new Vector3(dir.x, 0, dir.y);
    }
    public void SetDirecao(Vector3 dir)
    {
        Direcao = dir;
    }
    public void Movimentar ( float velocidade)
    {
        Vector3 dir;
        if (Direcao.magnitude > 1)
            dir = Direcao.normalized;
        else
            dir = Direcao;
        meuRigidbody.MovePosition(
                meuRigidbody.position +
                dir * velocidade * Time.deltaTime);
    }

    public void Rotacionar (Vector3 direcao)
    {
        if (direcao == Vector3.zero)
            return;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        meuRigidbody.MoveRotation(novaRotacao);
    }

    public void Morrer ()
    {
        meuRigidbody.constraints = RigidbodyConstraints.None;
        meuRigidbody.velocity = Vector3.zero;
        meuRigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = false;
    }
}
