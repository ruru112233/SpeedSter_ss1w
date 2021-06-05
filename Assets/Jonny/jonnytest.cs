using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jonnytest : MonoBehaviour
{
    public GameObject[] pref;

    public void Bad()
    {
        Instantiate(pref[0], transform.position, transform.rotation);
    }

    public void Miss()
    {
        Instantiate(pref[1], transform.position, transform.rotation);
    }

    public void Good()
    {
        Instantiate(pref[2], transform.position, transform.rotation);
    }

    public void Great()
    {
        Instantiate(pref[3], transform.position, transform.rotation);
    }

    public void Perfect()
    {
        Instantiate(pref[4], transform.position, transform.rotation);
    }
}
