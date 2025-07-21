using UnityEngine;
public class TrocaDePainel : MonoBehaviour
{
public GameObject Panel1;
public GameObject Panel2;
public void MostrarPanel1()
{
Panel1.SetActive(true);
Panel2.SetActive(false);
}
}