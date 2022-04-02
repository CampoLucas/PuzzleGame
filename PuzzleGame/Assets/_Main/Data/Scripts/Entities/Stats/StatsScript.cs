using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public StatsSO Stats => _stats;
    [SerializeField] private StatsSO _stats;

    /*
    public void SetStats(StatsSO stats)
    {
        _stats = stats;
    }
    */
}
