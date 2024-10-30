using UnityEngine;
using UnityEngine.Events;

namespace GameDevWithReece.Managers
{
    public class GameManager : MonoBehaviour
    {
        //By making the bool static and public, we can access the variable from anywhere without referencing
        //Be careful with using static, since it makes sense when there is only one istance of this object in the whole project!
        //For example, do not use static for the enemyHp variable, since there would be more than on!
        public static bool isGameOn = false;

        //Used to execute scrips at game start
        public UnityEvent gameStarted;
        public void GameIsOn()
        {
            isGameOn = true;

            //Invokes UnityEvent
            gameStarted.Invoke();
            Debug.Log(gameStarted);
        }

        public void GameIsOff()
        {
            isGameOn = false;
        }
    }
}