using System.Collections.Generic;

/*这个类主要存储保存在内存的各项设置，也提供读取/写入数据的函数*/
namespace ChatAI.cs
{
    class settingschatai
    {
        static public string apikey = "sk-";
        static public string apiurl = "https://api.openai.com/";
        static public string model = "gpt-3.5-turbo";
        static public string yyinfo = "用代码表达言语的魅力，用代码书写山河的壮丽";
        static public int MaxToken = 500;
        const string GUIDCODE = "1548C561-AE3C-460A-BBD7-A77EF186E66D";
        static public string GUID = GUIDCODE;
        static public List<string> models = new List<string> {
            "gpt-3.5-turbo",
            "gpt-3.5-turbo-0301",
            "gpt-3.5-turbo-16k",
            "gpt-3.5-turbo-16k-0613",
            "gpt-3.5-turbo-0613",
            "gpt-3.5-turbo-1106",
            "gpt-3.5-turbo-0125",
            "gpt-3.5-turbo-Instruct",
            "gpt-4",
            "gpt-4-0314",
            "gpt-4-0613",
            "gpt-4-32k",
            "gpt-4-32k-0314",
            "gpt-4-32k-0613",
            "gpt-4-1106-preview",
            "gpt-4-0125-preview",
            "gpt-4-vision-preview",
            "gpt-4-turbo-preview",

        };
        static public void opensettings()
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Setting in a container
            Windows.Storage.ApplicationDataContainer container = localSettings.CreateContainer("SettingContainer", Windows.Storage.ApplicationDataCreateDisposition.Always);

            if (localSettings.Containers.ContainsKey("SettingContainer"))
            {
                localSettings.Containers["SettingContainer"].Values["apikey"] = "sk-";
                localSettings.Containers["SettingContainer"].Values["apiurl"] = "https://api.openai.com/";
                localSettings.Containers["SettingContainer"].Values["model"] = "gpt-3.5-turbo";
                localSettings.Containers["SettingContainer"].Values["MaxToken"] = "500";
            }
        }

        static public string GetSetting(string name)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Setting in a container
            Windows.Storage.ApplicationDataContainer container = localSettings.CreateContainer("SettingContainer", Windows.Storage.ApplicationDataCreateDisposition.Always);
            if (localSettings.Values.ContainsKey(name))
            {
                return localSettings.Values[name].ToString();
            }
            else
            {
                if (name == "apiurl")
                {
                    return "https://api.openai.com/";
                }
                else if (name == "apikey")
                {
                    return "sk-";
                }
                else if (name == "model")
                {
                    return "gpt-3.5-turbo";
                }
                else if (name == "MaxToken")
                {
                    return "500";
                }
                return "NULL";
            }
        }
        static public void SetSetting(string name, string value)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Setting in a container
            Windows.Storage.ApplicationDataContainer container = localSettings.CreateContainer("SettingContainer", Windows.Storage.ApplicationDataCreateDisposition.Always);
            localSettings.Values[name] = value;
        }

    }
}
