using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpen : MonoBehaviour
{
    public GameObject appWindow;  // Arraste o painel da janela que você quer que o botão abra no Inspector

    public void OpenAppWindow()
    {
        if (appWindow != null)
        {
            appWindow.SetActive(true);  // Torna a janela visível

            // Coloca a janela no topo da visualização (última na hierarquia)
            appWindow.transform.SetAsLastSibling();
        }
    }

    public void CloseAppWindow()
    {
        if (appWindow != null)
        {
            appWindow.SetActive(false);  // Torna a janela invisível
        }
    }
}
