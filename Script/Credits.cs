using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void Quit()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Menu");
    }
}
