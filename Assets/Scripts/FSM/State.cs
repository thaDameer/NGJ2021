using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class State 
    {
        private Actor actor;
    
        protected State(Actor actor)
        {
            this.actor = actor;
        }

        public virtual void OnEnterState()
        {
            actor._EnterState(this);
        }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
        public virtual void OnExitState() { }

        public virtual void OnCollisionEnter(Collision coll) { }
        public virtual void OnCollisionExit(Collision coll) { }
        public virtual void OnCollisitionStay(Collision coll) { }
        public virtual void OnTriggerEnter(Collider col) { }
        public virtual void OnTriggerExit(Collider col) { }
        public virtual void OnTriggerStay(Collider col) { }

        public virtual void StartStateCoroutine(IEnumerator theCoroutine)
        {
            actor.StartCoroutine(theCoroutine);
        }
    }

}
