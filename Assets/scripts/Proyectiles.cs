using UnityEngine;
using enemigos;

namespace Pistola
{
    public class Proyectiles : MonoBehaviour
    {
        public Camera camaraPrimeraPersona;
        public GameObject Bala;

        void Update()
        {
            disparos();
        }
        void disparos()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                //disparo de proyectiles
                GameObject pro;
                pro = Instantiate(Bala, ray.origin, transform.rotation);
                Rigidbody rb = pro.GetComponent<Rigidbody>();
                rb.AddForce(camaraPrimeraPersona.transform.forward * 15, ForceMode.Impulse);

                Destroy(pro, 2);

                //devuelve raycasting
                if ((Physics.Raycast(ray, out hit) == true) && hit.distance < 5)
                {
                    //Debug.Log("El rayo tocó al objeto: " + hit.collider.name);
                    if (hit.collider.name.Substring(0, 3) == "Bot")
                    {
                        GameObject objetoTocado = GameObject.Find(hit.transform.name);
                        ControlBot scriptObjetoTocado = (ControlBot)objetoTocado.GetComponent(typeof(ControlBot));
                        if (scriptObjetoTocado != null)
                        {
                            scriptObjetoTocado.recibirDaño();
                        }
                    }
                }
            }
        }
    }
}
