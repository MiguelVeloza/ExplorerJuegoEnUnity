using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Codigo_Pausa : MonoBehaviour
{
    public GameObject objetoMenuPausa;
    public bool pausa = true;
    public GameObject menuSalir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa == false)
            {
                objetoMenuPausa.SetActive(true);
                pausa = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

                for(int i =0; i<sonidos.Length;i++)
                {
                    sonidos[i].Pause();
                }

            }
            else if(pausa == true)
            {
                resumir();
            }
        }
    }
    public void resumir()
    {
        objetoMenuPausa.SetActive(false);
        menuSalir.SetActive(false);
        pausa = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

                for(int i =0; i<sonidos.Length;i++)
                {
                    sonidos[i].Play();
                }
    }

    public void irAlMenu(string nombreMenu)
    {
        SceneManager.LoadScene(nombreMenu);
    }

    public void salirDelJuego()
    {
        Application.Quit();
    }
}
