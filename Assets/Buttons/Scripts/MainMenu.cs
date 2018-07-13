using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int cont = 0;

    public void CliqueiNoButao()
    {
        print(cont++);
    }

    public void CliqueZero()
    {
        cont = 0;
		print(cont);
    }

	public void OnClickPlay()
	{
		SceneManager.LoadScene("Game");
	}

	public void OnClickSair()
	{
		SceneManager.LoadScene("Menu");
	}
}
