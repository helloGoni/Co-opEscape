using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon

public class MasterPlayer : MonoBehaviour {
    //점프하면 모든 플레이어 태그를 찾아서 점프하게 만드러요
    public Rigidbody2D RB2D;
    public Animator AM;
    //public PhotonView PV;
    public SpriteRenderer SR;

    bool isGround;
    Vector3 curPos;

    void Update() {

    }


}
