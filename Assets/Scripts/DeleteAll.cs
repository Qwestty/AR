using nsDB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeleteAll : MonoBehaviour
{
    [SerializeField] private GameObject block;
    private Nucleus _nucleus;

    private void Start()
    {
        _nucleus = Nucleus.instance;

    }
        public void onClick()
        {
            _nucleus.DeleteAll();
            Destroy(block);
        }
}
