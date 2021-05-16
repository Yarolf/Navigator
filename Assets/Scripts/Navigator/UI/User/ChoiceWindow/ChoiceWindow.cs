using UnityEngine;

public class ChoiceWindow : MonoBehaviour
{
    [SerializeField]
    private JSONUser jsonUser;

    public void SetIndicatorRoute()
    {
        int routeNumber = 0;
        Indicator.SetRoute(jsonUser.data.routes[routeNumber]); // выбирать в соответствии с выпадающем меню
        Debug.LogWarning($"Выбран путь {routeNumber}");
    }
}
