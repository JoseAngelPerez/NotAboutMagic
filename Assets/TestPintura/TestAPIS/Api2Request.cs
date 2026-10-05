using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Net;
using System.IO;


public class Api2Request : MonoBehaviour
{
    [SerializeField] private string url;

    void Start()
    {
        ConseguirInformacion();
    }

    public void ConseguirInformacion()
    {
        try
        {
            HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
            peticion.Method = "GET";

            HttpWebResponse respuesta = (HttpWebResponse)peticion.GetResponse();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                Stream respuestaStream = respuesta.GetResponseStream();

                StreamReader lector = new StreamReader(respuestaStream);

                string respuestaTexto = lector.ReadToEnd();

               Pernsonaje personaje = JsonUtility.FromJson<Pernsonaje>(respuestaTexto);
                Debug.Log(personaje.name);

            }

        }
        catch
        {

        }
    }
}
