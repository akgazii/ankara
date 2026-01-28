using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementlarprodur : MonoBehaviour
{
  private Oyuncular oyuncular;


    //BEN BİR İNPUTHEADLERIM MOVEMENT DEĞİL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
    //İNTUDER OLARAK İMPUTLARI "oyuncular" (yaram gibi isim) dan çekiyorum değiştirmeyin sikerim
    public void Awake()
    {
      oyuncular = new Oyuncular();
      oyuncular.Player.Enable ();
      oyuncular.Player.haraket.Enable();
    }
  public Vector2 Getmovementvectornormalized()
  {
      Vector2 inputVector = oyuncular.Player.haraket.ReadValue<Vector2>();
      return inputVector.normalized;
  }
  
    private void Update()
  {
    Debug.Log(Getmovementvectornormalized());
  }
  
}
