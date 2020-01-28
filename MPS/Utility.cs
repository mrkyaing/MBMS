using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS {
    public class Utility {
        /// <summary>
        /// Decrypt the input string ( Eg: EncryptString("ABC", string.Empty); )  
        /// </summary>
        public static string EncryptString(string PlainText, string EncryptKey) {
            byte[] Results;
            UTF8Encoding UTF8 = new UTF8Encoding();
            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(EncryptKey));
            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(PlainText);
            // Step 5.Attempt to encrypt the string
            try {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }


        /// <summary>
        /// Decrypt the input string ( Eg: DecryptString("LoBCnf0JCg8=", string.Empty); )  
        /// </summary>
        public static string DecryptString(string PlainText, string EncryptKey) {
            byte[] Results;
            UTF8Encoding UTF8 = new UTF8Encoding();
            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(EncryptKey));
            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(PlainText);
            // Step 5. Attempt to decrypt the string
            try {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }
        public static void BindShop(ComboBox cboCompanyName, bool includeALL = false)
        {
            if (includeALL)
            {
                MBMSEntities entity = new MBMSEntities();
                List<CompanyProfile> companyProfileList = new List<CompanyProfile>();

               CompanyProfile companyProfile = new CompanyProfile();
                companyProfile.CompanyName = "ALL";
                companyProfile.CompanyProfileID = null;

                var companys = entity.CompanyProfiles.ToList();
                companyProfileList.Add(companyProfile);
                companyProfileList.AddRange(companys);
                cboCompanyName.DataSource = companyProfileList;
                cboCompanyName.DisplayMember = "CompanyName";
                cboCompanyName.ValueMember = "CompanyProfileID";

                cboCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboCompanyName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                MBMSEntities entity = new MBMSEntities();
                List<CompanyProfile> companyProfileList = new List<CompanyProfile>();
                cboCompanyName.DataSource = companyProfileList;
                cboCompanyName.DisplayMember = "CompanyName";
                cboCompanyName.ValueMember = "CompanyProfileID";

                cboCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboCompanyName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

        }
        public static class SettingController
        {
            public static CompanyProfile defaultCompanyProfile
            {
                get
                {
                    MBMSEntities mbmsentity = new MBMSEntities();
                    CompanyProfile companyProfile = mbmsentity.CompanyProfiles.Where(x => x.Active == true).FirstOrDefault();
                    return companyProfile;
                }
            }
            public static int DefaultNoOfCopies
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "default_noOfCopies");
                    if (currentSet != null)
                    {
                        return Convert.ToInt32(currentSet.Value);
                    }

                    return 1;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "default_noOfCopies");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "default_noOfCopies";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string CompanyName
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_name");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_name");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_name";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static string PhoneNo
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "phone_number");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "phone_number");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "phone_number";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string CompanyEmail
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_email");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_email");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_email";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static string CompanyWebsite
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_website");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_website");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_website";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static string CompanyAddress
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_address");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_address");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_address";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static int StreetLightFees
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "StreetLightFees");
                    if (currentSet != null)
                    {
                        return Convert.ToInt32(currentSet.Value);
                    }

                    return 0;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "StreetLightFees");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "StreetLightFees";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static string ExpireDate
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "ExpireDate");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }
                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "ExpireDate");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "ExpireDate";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
        }

        public static class DefaultPrinter {
        public static string A4Printer
        {
            get
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                if (currentSet == null)
                {
                    currentSet = new Setting();
                    currentSet.Key = "a4_printer";
                    currentSet.Value = value.ToString();
                    mbmsEntities.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                mbmsEntities.SaveChanges();
            }
        }
    }

    }
    }
