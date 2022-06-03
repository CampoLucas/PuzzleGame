using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Swap : MonoBehaviour
{
    private GameObject objSphere;
    private GameObject objCube;
    private GameObject objPiramid;
    public GameObject[] objst;
    public int[] id;
    public bool[] state;

    public StatsSO currentForm;

    public StatsSO[] form = new StatsSO[1];

    public int currentFormIndex = -1;

    public void SwapPlayer()
        {
        objSphere = FindInActiveObjectByName("Player_Sphere (1)");
        objCube = FindInActiveObjectByName("Player_Cube (1)");
        objPiramid = FindInActiveObjectByName("Player_Piramid (1)");


        for (int i=0; i < objst.Length; i++)
        {

            if (state[i])
            {

                objst[i].SetActive(false);
                state[i] = false;

                if (i == 0)
                {
                    objst[ 2 ].SetActive(true);
                    state[ 2 ] = true;
                }
                else
                {
                    objst[i - 1].SetActive(true);
                    state[i - 1] = true;
                    Debug.Log(objst[i - 1]);
                }
            }
        }

    }


    



    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    //private void Update()
    //{
    //    Physics.CheckBox()
    //}
}
