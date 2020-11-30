using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpsIndex;
    public GameObject Screen;
    public GameObject Spawner;
    private bool IsCoroutineExecuting = false;

    void Start()
    {
        PlayerController.IsMoving = false;
        shooting.IsShooting = false;

    }


    void Update()
    {
        for(int i = 0;i < popUps.Length; i++)
        {
            if (i == popUpsIndex)
            {
                popUps[i].SetActive(true);
            }else {
                popUps[i].SetActive(false);
        }


        }
        if (popUpsIndex == 0)
        {
            StartCoroutine(ExecuteAfterTime(3));
        }
        else if (popUpsIndex == 1)
        {
            StartCoroutine(Moving(3));
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                Screen.SetActive(true);
                popUpsIndex++;
                PlayerController.IsMoving = false;
            }
        }
        else if (popUpsIndex == 2)
        {
            StartCoroutine(Shooting(3));
            if (Input.GetButtonDown("Fire1"))
            {
                Screen.SetActive(true);
                popUpsIndex++;
                shooting.IsShooting = false;
            }
        }
        else if (popUpsIndex == 3)
        {
            StartCoroutine(Moving(3));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Screen.SetActive(true);
                popUpsIndex++;
                PlayerController.IsMoving = false;
            }
        }
        else if(popUpsIndex == 4)
        {
            Screen.SetActive(true);
            StartCoroutine(ExecuteAfterTime(3));
        }
        else if(popUpsIndex == 5)
        {
            StartCoroutine(ExecuteAfterTime(3));
            
        }
        else if(popUpsIndex == 6)
        {
            StartCoroutine(ExecuteAfterTime(3));
        }
        else if(popUpsIndex == 7)
        {
            StartCoroutine(ExecuteAfterTime(3));
        }
        else if(popUpsIndex == 8)
        {
            StartCoroutine(ExecuteAfterTime(5));
        }
        else if(popUpsIndex == 9)
        {
            StartCoroutine(Shooting(5));
            PlayerController.IsMoving = true;
            Screen.SetActive(false);
            Spawner.SetActive(true);

        }
              
    }

    
    IEnumerator ExecuteAfterTime(float time)
    {
        if (IsCoroutineExecuting)
        {
            yield break;
        }
        IsCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        popUpsIndex++;
        IsCoroutineExecuting = false;
    }

    IEnumerator Shooting(float time)
    {
        if (IsCoroutineExecuting)
        {
            yield break;
        }

        IsCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        Screen.SetActive(false);
        shooting.IsShooting = true;
        IsCoroutineExecuting = false;
    }

    IEnumerator Moving(float time)
    {
        if (IsCoroutineExecuting)
        {
            yield break;
        }

        IsCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        Screen.SetActive(false);
        PlayerController.IsMoving = true;
        IsCoroutineExecuting = false;
    }

}
