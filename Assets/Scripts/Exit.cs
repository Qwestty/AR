using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Exit : MonoBehaviour
    {
    [SerializeField] Material _NoneActiveMaterial; //создание полей, для спольозования объектов со сцены
    [SerializeField] GameObject _infoPanel; //создание полей, для спольозования объектов со сцены
    [SerializeField] GameObject Obj_info; //создание полей, для спольозования объектов со сцены

        public void onClick()
        {
            Obj_info.GetComponent<Renderer>().material = _NoneActiveMaterial; //нанесение неактивного материала
            Obj_info.transform.localPosition += new Vector3(0, -0.02f, 0); //изменение его позии по оси Y
            _infoPanel.SetActive(false); //скрытие информации региона
        }
}
