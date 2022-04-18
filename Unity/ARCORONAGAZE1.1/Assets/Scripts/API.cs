using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour {

    const string ENDPOINT = "https://api.covid19api.com/summary";

    private void Start() {
        GetTimeData();
    }

    public void GetTimeData() {
        StartCoroutine(GetTimeDataRoutine());
    }

    IEnumerator GetTimeDataRoutine() {

        UnityWebRequest request = UnityWebRequest.Get(ENDPOINT);
        yield return request.SendWebRequest();

        if (request.isNetworkError) {
            Debug.Log("Network Error");
        } else {
            ParseData(request.downloadHandler.text);
        }
    }

    void ParseData(string data) {
        Debug.Log(data);
    }
}
