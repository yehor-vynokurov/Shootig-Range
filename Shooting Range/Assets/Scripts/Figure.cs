using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryObjects
{
    public abstract class Figure : MonoBehaviour
    {

        public string name;
        public int reward;
        public bool isShooted = false;
        // Use this for initialization
        public void SetMaterial()
        {
            GetComponent<Renderer>().material = Resources.Load<Material>("Materials/" + name.Split(' ')[0]);
        }

        private void OnMouseDown()
        {
            if (!isShooted)
                Shoot();
        }

        public void AddToScoreAfterShoot()
        {
            GameObject.Find("GameController").GetComponent<GameController>().AddScore(reward);
        }

        virtual public void Shoot()
        {
            isShooted = true;
            AddToScoreAfterShoot();
        }
        virtual public IEnumerator DestroyAfterShoot(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}