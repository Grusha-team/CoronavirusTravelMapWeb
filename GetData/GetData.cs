using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace GetData
{
    public class GetDataa
    {
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        SheetsService service;
       

       
        public void Login()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
               
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            
           service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
        }
        public Dictionary<string, string> GetCountries()
        {
            Dictionary<string, string> Countries = new Dictionary<string, string>();
            String range = "A2:B120";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(CONST.SPREAD_SHEET_ID, range);
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {   if (row.Count != 0 )
                        if(row.Count > 1 )
                            Countries.Add(row[0].ToString(), row[1].ToString());
                        else
                            Countries.Add(row[0].ToString(), row[0].ToString());
                }
            }
            return Countries;
        }

        public List<Country> GetListOfCountries()
        {
            List<Country> countries = new List<Country>();
            String range = "A2:D120";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(CONST.SPREAD_SHEET_ID, range);
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    countries.Add(new Country (row[0].ToString(), row[2].ToString(), row[3].ToString()));
                
                }
            }
            return countries;

        }
    }
}
