using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public StatsSO Data => _stats;
    [SerializeField] protected StatsSO _stats;
}
