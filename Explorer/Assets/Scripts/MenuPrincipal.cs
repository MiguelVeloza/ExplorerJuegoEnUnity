using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour{

    public void empezar(string nombreNivel){
        SceneManager.LoadScene(nombreNivel);
    }

    public void salir(){
        Application.Quit();
    }
}
