using UnityEngine;

public class MakeRank : MonoBehaviour
{
    [SerializeField]
    private FanMeetingRank fanMeetingRank;

    private void OnEnable()
    {
        fanMeetingRank.Open();
    }
}
