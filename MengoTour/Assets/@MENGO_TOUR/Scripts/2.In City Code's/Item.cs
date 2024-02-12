using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MENGO_TOUR.CITY
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected float increaseValue;

        protected abstract void OnTriggerEnter(Collider other);
        protected abstract void OnTriggerStay(Collider other);
        protected abstract void OnTriggerExit(Collider other);
    }
}


