using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPosicionManos : MonoBehaviour
{
    private ControladorManos controladorManos;
    [SerializeField] private FisicaMano fisicaDerecha;
    [SerializeField] private FisicaMano fisicaIzquierda;
    public Transform manoDerecha;
    public Transform manoIzquierda;
    private Transform objetoAMover;
    public Transform cabeza;

    private Action OnUpdate;
    private bool actualizando;
    private Vector3 derMenosObjeto;
    private Quaternion derQuaObjeto;

    private bool cajaPosicionada;

    private void Awake()
    {
        controladorManos = GetComponent<ControladorManos>();
        fisicaDerecha.OnHandReady += ActivarActualizacion;
        fisicaDerecha.OnHandNoReady += DesactivarActualizacion;

        fisicaIzquierda.OnHandReady += ActivarActualizacion;
        fisicaIzquierda.OnHandNoReady += DesactivarActualizacion;
    }

    private void Update()
    {
        if (!actualizando) return;
        if (OnUpdate != null) OnUpdate();
    }

    private void ActivarActualizacion(Transform objeto)
    {
        if (!cajaPosicionada)
        {
            objetoAMover = objeto;
            actualizando = true;
            objetoAMover.GetComponent<Rigidbody>().isKinematic = true;

            Quaternion rotacionCaja = objetoAMover.GetChild(0).rotation;
            objetoAMover.rotation = CalcularRotacionMedia();
            objetoAMover.GetChild(0).rotation = rotacionCaja;

            cajaPosicionada = true;

            Vector3 posicionCaja = objetoAMover.GetChild(0).position;
            objetoAMover.position = CalcularPuntoMedio();
            objetoAMover.GetChild(0).position = posicionCaja;

            OnUpdate += ActualizarPosicion;
            OnUpdate += ActualizarRotacion;

            //Fisica mano   mano.SetParent(transform.GetChild(0));
            //Luego de soltar el objeto organizar el hijo para qe quede en la posicion correcta
        }
    }

    private void DesactivarActualizacion()
    {
        if (cajaPosicionada)
        {
            actualizando = false;
            Vector3 posicion = objetoAMover.GetChild(0).position;
            Quaternion rotacion = objetoAMover.GetChild(0).rotation;
            objetoAMover.position = posicion;
            objetoAMover.rotation = rotacion;
            objetoAMover.GetChild(0).localPosition = Vector3.zero;
            objetoAMover.GetChild(0).localRotation = Quaternion.identity;
            objetoAMover.GetComponent<Rigidbody>().isKinematic = false;
            objetoAMover.GetComponent<Rigidbody>().velocity = controladorManos.inputDerecho.Controller.velocity;
            objetoAMover.GetComponent<Rigidbody>().angularVelocity = controladorManos.inputDerecho.Controller.angularVelocity;
            objetoAMover = null;
            cajaPosicionada = false;
            OnUpdate -= ActualizarPosicion;
            OnUpdate -= ActualizarRotacion;
        }
    }

    private void ActualizarPosicion()
    {
        objetoAMover.position = CalcularPuntoMedio();
    }

    private void ActualizarRotacion()
    {
        objetoAMover.rotation = CalcularRotacionMedia(); //* derQuaObjeto;
    }

    private Vector3 CalcularPuntoMedio()
    {
        Vector3 posDer = manoDerecha.position;
        Vector3 posIzq = manoIzquierda.position;

        float derX = posDer.x;
        float izqX = posIzq.x;

        float parcialX = Mathf.Lerp(Mathf.Min(derX, izqX), Mathf.Max(derX, izqX), 0.5f);

        float derY = posDer.y;
        float izqY = posIzq.y;

        float parcialY = Mathf.Lerp(Mathf.Min(derY, izqY), Mathf.Max(derY, izqY), 0.5f);

        float derZ = posDer.z;
        float izqZ = posIzq.z;

        float parcialZ = Mathf.Lerp(Mathf.Min(derZ, izqZ), Mathf.Max(derZ, izqZ), 0.5f);

        Vector3 posObjeto = new Vector3(parcialX, parcialY, parcialZ);
        return posObjeto;
    }

    private Quaternion CalcularRotacionMedia()
    {
        Quaternion rotDer = manoDerecha.rotation;
        Quaternion rotIzq = manoIzquierda.rotation;
        Quaternion rotCaja = objetoAMover.rotation;

        float derX = rotDer.x;
        float izqX = rotIzq.x;

        float parcialX = Mathf.Lerp(Mathf.Min(derX, izqX), Mathf.Max(derX, izqX), 0.5f);

        float derY = rotDer.y;
        float izqY = rotIzq.y;

        float parcialY = Mathf.Lerp(Mathf.Min(derY, izqY), Mathf.Max(derY, izqY), 0.5f);

        float derZ = rotDer.z;
        float izqZ = rotIzq.z;

        float parcialZ = Mathf.Lerp(Mathf.Min(derZ, izqZ), Mathf.Max(derZ, izqZ), 0.5f);

        float derW = rotDer.w;
        float izqW = rotIzq.w;

        float parcialW = Mathf.Lerp(Mathf.Min(derW, izqW), Mathf.Max(derW, izqW), 0.5f);

        Quaternion rotacion = new Quaternion(parcialX, parcialY, parcialZ, parcialW);
        
        return rotacion;
    }
}