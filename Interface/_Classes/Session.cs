using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interface._Interfaces;
using Interface.webapi;
using System.Security.Cryptography;

namespace Interface._Classes
{
    class Session:ISession
    {
        //POLA
        private AllegroWebApiService allegroService;
        private SHA256 sha;

        private string webAPIKey;
        string sessionHandle="";
        private long userId, serverTime, localVersion;
        private int countryId;

        //METODY
        public Session(string webAPIKey,int countryId)
        {
            allegroService = new AllegroWebApiService();

            this.countryId = countryId;
            this.webAPIKey = webAPIKey;

            allegroService.doQuerySysStatus(3, countryId, webAPIKey, out localVersion);//pobieranie versionKey
        }
        public void login(string login,string password)
        {
            //szyfrowanie hasla
            SHA256 sha = new SHA256Managed();
            byte[] byteArrayPassword = Encoding.ASCII.GetBytes(password);//konwersja na tablice bajtow
            byte[] passwordHash = sha.ComputeHash(byteArrayPassword);//produkcja haszu
            string encodedPassword = Convert.ToBase64String(passwordHash);//konwersja na string

            //logowanie
            try
            {
                sessionHandle = allegroService.doLoginEnc(
                    login,
                    encodedPassword,
                    countryId,
                    webAPIKey,
                    localVersion,
                    out userId,
                    out serverTime);
            }
            catch (Exception exc)
            {
                sessionHandle = "";
            }
        }

        //WLASCIWOSCI
        public string SESSIONHANDLE
        {
            get
            {
                return this.sessionHandle;
            }
            set { }
        }

    }
}
