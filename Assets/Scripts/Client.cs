using UnityEngine;
using System;
using WebSocketSharp;
using verifConnexion;
using walkingPlayer;
using walkingPlayer2;
using walkingPlayer3;
using walkingPlayer5;
using walkingPlayerAnimation;
using walkingPlayerAnimation2;
using walkingPlayerAnimation3;
using walkingPlayerAnimation5;
using ChoicePasseur;
using Dictionary;

namespace SocketEvent
{
    public static class Client
    {
        private static WebSocket _webSocket;

        private static object _json;
        private static string _jsonString;
        // private static RessourcesPlayer _ressourcesPlayer;
        public static int quantiteCristaux;
        public static int quantiteGraines;
        public static int quantiteFruits;
        public static int idPlayer;
        public static int sendPlayer;


        [RuntimeInitializeOnLoadMethod]
        private static void Start()
        {
            _webSocket = new WebSocket("ws://192.168.1.82:3600");
            // _webSocket = new WebSocket("ws://ostaraserver.herokuapp.com/:9000");
            ConnectClient();
        }

        private static void ConnectClient()
        {
            _webSocket.OnOpen += OnOpen;
            _webSocket.OnClose += OnClose;
            _webSocket.OnError += OnError;
            _webSocket.OnMessage += OnMessage;

            _webSocket.Connect();
        }

        private static void OnOpen(object sender, EventArgs e)
        {
            //Debug.Log("Client - OnOpen");
        }

        private static void OnClose(object sender, CloseEventArgs e)
        {
            //Debug.Log("Client - OnClose");

            _webSocket.OnOpen -= OnOpen;
            _webSocket.OnClose -= OnClose;
            _webSocket.OnError -= OnError;
            _webSocket.OnMessage -= OnMessage;
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            // Debug.Log($"Client - OnError : {e.Message}");
        }

        public static void OnMessage(object sender, MessageEventArgs e)
        {
            // Debug.Log(e.Data);

            string s1 = e.Data;
            string s2 = "RESSOURCES";
            bool b = s1.Contains(s2);
            if (b == true)
            {
                var ressourcesPlayer = JsonUtility.FromJson<RessourcesPlayer>(e.Data);
                quantiteCristaux = ressourcesPlayer.pierre;
                quantiteGraines = ressourcesPlayer.graine;
                quantiteFruits = ressourcesPlayer.fruit;
                idPlayer = ressourcesPlayer.id;
                sendPlayer = ressourcesPlayer.sendPlayer;
            }

            Connexion.ConnexionVerif(e.Data);
            PlayerMovement.Joystick(e.Data);
            PlayerMovement2.Joystick(e.Data);
            PlayerMovement3.Joystick(e.Data);
            PlayerMovement5.Joystick(e.Data);
            PlayerMovement.Jump(e.Data);
            PlayerMovement2.Jump(e.Data);
            PlayerMovement3.Jump(e.Data);
            PlayerMovement5.Jump(e.Data);
            PlayerMovement.Plante(e.Data);
            PlayerMovement2.Plante(e.Data);
            PlayerMovement3.Plante(e.Data);
            PlayerMovement5.Plante(e.Data);
            PlayerMovement.Recolte(e.Data);
            PlayerMovement2.Recolte(e.Data);
            PlayerMovement3.Recolte(e.Data);
            PlayerMovement5.Recolte(e.Data);
            PlayerMovement.PluieButton(e.Data);
            PlayerMovement2.PluieButton(e.Data);
            PlayerMovement3.PluieButton(e.Data);
            PlayerMovement5.PluieButton(e.Data);
            IsWalkingAnimation.JoystickAnimation(e.Data);
            IsWalkingAnimation2.JoystickAnimation(e.Data);
            IsWalkingAnimation3.JoystickAnimation(e.Data);
            IsWalkingAnimation5.JoystickAnimation(e.Data);
            IsWalkingAnimation.JumpAnimation(e.Data);
            IsWalkingAnimation2.JumpAnimation(e.Data);
            IsWalkingAnimation3.JumpAnimation(e.Data);
            IsWalkingAnimation5.JumpAnimation(e.Data);
            IsWalkingAnimation.PlanteAnimation(e.Data);
            IsWalkingAnimation2.PlanteAnimation(e.Data);
            IsWalkingAnimation3.PlanteAnimation(e.Data);
            IsWalkingAnimation5.PlanteAnimation(e.Data);
            IsWalkingAnimation.RecolteAnimation(e.Data);
            IsWalkingAnimation2.RecolteAnimation(e.Data);
            IsWalkingAnimation3.RecolteAnimation(e.Data);
            IsWalkingAnimation5.RecolteAnimation(e.Data);
            Choix.Voiture(e.Data);
            Choix.Rosalie(e.Data);
            SettingsMenu.Quit(e.Data);
            Jardinage.PluieButton(e.Data);
        }

        public static void sendMessage(string message)
        {
            _webSocket.Send(message);
        }

        public static string ConvertDataObject(object _testJson)
        {
            _json = new JSONObject(JsonUtility.ToJson(_testJson));
            _jsonString = _json.ToString();

            return _jsonString;
        }

        public static void UpdateGlobalData()
        {
            GameManager.Instance.quantiteCristaux = quantiteCristaux;
            GameManager.Instance.quantiteGraines = quantiteGraines;
            GameManager.Instance.quantiteFruits = quantiteFruits;
            GameManager.Instance.idPlayer = idPlayer;
            GameManager.Instance.sendPlayer = sendPlayer;

            // Debug.Log("graines: " + quantiteGraines + " pierre: " + quantiteCristaux + " fruit: " + quantiteFruits);
        }
    }
}