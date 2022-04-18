using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class HeartLogic : MonoBehaviour
{
    public GameObject destryableMap;
    public GameObject grid;
    private int count = 0;
    private PhotonView PV;
    public float remainingTime = 5;
    private bool willTp = true;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        Debug.Log("[[[[[[[[[[[[[[[[[[[[");
        Debug.Log(PV.IsMine);
        if (PhotonNetwork.IsMasterClient && PV.IsMine)
        {
            Debug.Log("Creatttttttttttttttttttttttttttttttttttttttttttttttttttttttt");
            Debug.Log("Creatttttttttttttttttttttttttttttttttttttttttttttttttttttttt");
            var map = PhotonNetwork.Instantiate(destryableMap.name, new Vector3(0, 0, 0), Quaternion.identity);
            PV.RPC("createTileMap", RpcTarget.All, map.GetComponent<PhotonView>().ViewID);
            Debug.Log("213122222222223");
            Debug.Log(count++);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0 && willTp)
        {

            SceneManager.LoadScene("liver");
            Debug.Log(++lungLogic.ownGameScore);
            Debug.Log(lungLogic.enemyGameScore);
            willTp = false;
        }
    }
    [PunRPC]
    void createTileMap(int viewID)
    {
        Debug.Log(viewID);
        Debug.Log("22222222222222222222222222------------------22");
        // Debug.Log(map);
        // GameObject.Find("Immue(Clone)/firepoint");
        PhotonView.Find(viewID).transform.SetParent(grid.transform);
        
    }
}
