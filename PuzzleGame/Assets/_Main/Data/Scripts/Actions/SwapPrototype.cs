using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwapPrototype : MonoBehaviour
{

    [SerializeField] private Player nextForm, previusForm;

    public UnityEvent onPlayerSwap = new UnityEvent();
    // idea que se subscriba de alguna manera todo los scripts que necesiten stats para cambiarse de stats, 4 statsSO el cuarto es currentData, SphereData, etc.
    // o que las stats no se guarden en variables dentro de los scripts y se tome como referencia a currentData cuando nesesitan stats.
    // Nesecito hacer esto haci soluciono el problema de que la caja se destruya y para poder respawnear al jugador...
    // porque no creo que sea posible de una manera sensilla guardarse la referencia del player o que el player se guarde la referencia del spawnpoint si se respawnea el mismo.

    public void ChangeNextForm()
    {
        Player O = Instantiate(nextForm, transform.parent);
        O.transform.position = transform.position;
        Object.Destroy(this.gameObject);
    }
    public void ChangePreviusForm()
    {
        Player O = Instantiate(previusForm, transform.parent);
        O.transform.position = transform.position;
        Object.Destroy(this.gameObject);
    }

}
