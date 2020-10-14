using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCollecter : MonoBehaviour
{
    SubCollector subCollector;
    TradeHammer tradeHammer;
    public int PointLevel1;
    public int PointLevel2;
    public int PointLevel3;
    public int PointLevel4;
    public int PointLevel5;
    public int totalpoint;
    //public bool GoodEnd = false;
    //public bool CanGetHammer = false;
    public Text EndingPoint;

    // Start is called before the first frame update
    void Start()
    {
        subCollector = GameObject.Find("CollectorManager").GetComponent<SubCollector>();
        tradeHammer = GameObject.Find("HammerTrade").GetComponent<TradeHammer>();
        PointLevel1 = PlayerPrefs.GetInt("HightScore" + 3.ToString());
        PointLevel2 = PlayerPrefs.GetInt("HightScore" + 4.ToString());
        PointLevel3 = PlayerPrefs.GetInt("HightScore" + 5.ToString());
        PointLevel4 = PlayerPrefs.GetInt("HightScore" + 6.ToString());

        /*PointLevel1 = 10;
        PointLevel2 = 10;
        PointLevel3 = 10;
        PointLevel4 = 10;*/
        //PointLevel5 = PlayerPrefs.GetInt("collectorPoint" + 5.ToString());
        //GoodEnd = false;

    }
    void endingOption()
    {
        if(totalpoint == 50)
        {
            //GoodEnd = true;
            //CanGetHammer = true;
            tradeHammer.HasEnoughItem = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        PointLevel5 = subCollector.collectorPoint;
        totalPoint();
        Debug.Log("totalpoint = " + totalpoint);
        endingOption();
        EndingPoint.text = totalpoint.ToString();
    }
    
    void totalPoint()
    {
        totalpoint = (PointLevel1 + PointLevel2 + PointLevel3 + PointLevel4 + PointLevel5);
    }
}
