using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Servingame.Controllers;
using SaveLoadSystem;
using System.IO;

namespace Servingame.Movements
{
    public class CameraMovement : MonoBehaviour
    {
        PlayerController playerController;
        Vector3 distance;
        float smoothSpeed = 0.125f;
        CameraData _cameraData = new CameraData();
        private void Awake()
        {
            if (!File.Exists(Application.persistentDataPath + "/Saves/" + "SaveData.sav"))
            {
                transform.position = new Vector3(-1.1265778f, 6.6f, -4.924f);
                transform.rotation = Quaternion.Euler(58.6061325f, -3f, 358.676636f);
                OnPause();
            }
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onPause += OnPause;
            CoreGameSignals.Instance.onQuit += OnQuit;
            OnPlay();
        }
        private void Start()
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            distance = transform.position - playerController.transform.position;
        }
        void Update()
        {
            FollowCamera();
        }

        void FollowCamera()
        {
            Vector3 smoothPosition = distance + playerController.transform.position;
            transform.position = Vector3.Lerp(transform.position, smoothPosition, smoothSpeed);
        }

        public void OnPlay()
        {
            SaveGameManager.LoadGame();
            _cameraData = SaveGameManager.CurrentSaveData.CameraData;
            transform.position = _cameraData.CameraPosition;
            transform.rotation = _cameraData.CameraRotation;
        }

        public void OnPause()
        {
            var transform1 = transform;
            _cameraData.CameraPosition = transform1.position;
            _cameraData.CameraRotation = transform1.rotation;
            SaveGameManager.CurrentSaveData.CameraData = _cameraData;
            SaveGameManager.SaveGame();
        }


        public void OnQuit()
        {
            var transform1 = transform;
            _cameraData.CameraPosition = transform1.position;
            _cameraData.CameraRotation = transform1.rotation;
            SaveGameManager.CurrentSaveData.CameraData = _cameraData;
            SaveGameManager.SaveGame();
        }

        private void OnApplicationQuit()
        {
            OnQuit();
        }
    }
    [System.Serializable]
    public struct CameraData
    {
        public Vector3 CameraPosition;
        public Quaternion CameraRotation;
    }

}

