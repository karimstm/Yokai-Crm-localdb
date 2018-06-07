using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoxLearn.License;
using Telerik.Reporting.Processing;
using Telerik.WinControls.UI;

namespace Yokai.Crm.Logic
{
    public static class ProductManager
    {
        private const int productCode = 1;

        public static async Task<bool> Activate(string productId, string productKey)
        {
            KeyManager km = new KeyManager(productId);
            string productkey = productKey;

            if (km.ValidKey(ref productkey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productkey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productkey;
                    lic.FullName = "Yokai CRM";
                    using (IsolatedStorageFile isolatedStorageFile =
                        IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null,
                            null))
                    {

                        using (IsolatedStorageFileStream isolatedStorageFileStream =
                            new IsolatedStorageFileStream("setting.lic", System.IO.FileMode.Create,
                                isolatedStorageFile))
                        {
                            string value = StringCipher.Encrypt(lic.ProductKey, "moutik");
                            using (StreamWriter sw = new StreamWriter(isolatedStorageFileStream))
                            {
                                await sw.WriteLineAsync(value);
                            }
                        }
                    }

                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public static async Task<bool> IsActivated()
        {
            KeyManager km = new KeyManager(ComputerInfo.GetComputerId());
            LicenseInfo lic = new LicenseInfo();
            lic.FullName = "Yokai CRM";
            
            using (IsolatedStorageFile isolatedStorageFile =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null,
                    null))
            {
                try
                {
                    using (IsolatedStorageFileStream isolatedStorageFileStream =
                        new IsolatedStorageFileStream("setting.lic", System.IO.FileMode.Open,
                            isolatedStorageFile))
                    {
                        string value;
                        using (StreamReader sr = new StreamReader(isolatedStorageFileStream))
                        {
                            value = await sr.ReadLineAsync();
                        }
                        lic.ProductKey = StringCipher.Decrypt(value, "moutik");
                        string productKey = lic.ProductKey;
                        if (!km.ValidKey(ref productKey))
                        {
                            return false;
                            //new ActivationForm().ShowDialog();
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }

            }
        }

        public static string GetProductKey()
        {
            return ComputerInfo.GetComputerId();
        }

    }
}
