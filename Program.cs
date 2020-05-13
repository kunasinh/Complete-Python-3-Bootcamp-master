using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Mvp.Xml;
using System.Runtime.Serialization.Formatters;
using Microsoft.Azure.DataLake.Store;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using System.Xml.Serialization;
using System.Drawing;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using PGPSnippet.Keys;
using PGPSnippet.PGPEncryption;
using Microsoft.Azure.KeyVault;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using com.unilever.ina;
using System.Security.Authentication;

namespace SOAPWebclient
{
    public class Program
    {
        public string CookieName { get; set; }
        public int TimeoutSeconds { get; set; }
        public string ErrorCode { get; set; }

        private static string clientSecret;
        private static string webApp_clientId;

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.InvokeService();
        }
        public void InvokeService()
        {
            //read_timeout, conn_timeout
            dynamic parameters = JsonConvert.DeserializeObject(File.ReadAllText("Parameters.json"));
            string adlsName = Convert.ToString(parameters.adlsName);
            string domain = Convert.ToString(parameters.domain);
            string key_vault = Convert.ToString(parameters.keyvault);
            string HawkEye_Payroll_EndPoint = Convert.ToString(parameters.HawkEye_Payroll_EndPoint);
            //string lakeFolder = Convert.ToString(parameters.adlsDestinationFolder);
            string OutPutFileName = Convert.ToString(parameters.OutPutFileName);
            string Request_Message = Convert.ToString(parameters.Request_Message);
            string Request_Message_user = Convert.ToString(parameters.Request_Message_user);
            List<string> nodeList = new List<string>();
            //       var Request_Message_user = "isu_wd_hawkeye_payroll@unilever";

            string Request_Message_user_secret = Convert.ToString(parameters.Request_Message_user_secret);

            nodeList.Add(Convert.ToString(parameters.node1));
            nodeList.Add(Convert.ToString(parameters.node2));
            nodeList.Add(Convert.ToString(parameters.node3));
           /* nodeList.Add(Convert.ToString(parameters.node4));
            nodeList.Add(Convert.ToString(parameters.node5));
            nodeList.Add(Convert.ToString(parameters.node6));
            nodeList.Add(Convert.ToString(parameters.node7));
            nodeList.Add(Convert.ToString(parameters.node8));
            nodeList.Add(Convert.ToString(parameters.node9));
            nodeList.Add(Convert.ToString(parameters.node10));
            nodeList.Add(Convert.ToString(parameters.node11));
            nodeList.Add(Convert.ToString(parameters.node12));
            nodeList.Add(Convert.ToString(parameters.node13));
            nodeList.Add(Convert.ToString(parameters.node14));
            nodeList.Add(Convert.ToString(parameters.node15));
            nodeList.Add(Convert.ToString(parameters.node16));
            nodeList.Add(Convert.ToString(parameters.node17));
            nodeList.Add(Convert.ToString(parameters.node18));
            nodeList.Add(Convert.ToString(parameters.node19));
            nodeList.Add(Convert.ToString(parameters.node20));
            nodeList.Add(Convert.ToString(parameters.node21));
            nodeList.Add(Convert.ToString(parameters.node22));
            nodeList.Add(Convert.ToString(parameters.node23));
            nodeList.Add(Convert.ToString(parameters.node24));
            nodeList.Add(Convert.ToString(parameters.node25));
            nodeList.Add(Convert.ToString(parameters.node26));
            nodeList.Add(Convert.ToString(parameters.node27));
            nodeList.Add(Convert.ToString(parameters.node28));
            nodeList.Add(Convert.ToString(parameters.node29));
            nodeList.Add(Convert.ToString(parameters.node30));
            nodeList.Add(Convert.ToString(parameters.node31));
            nodeList.Add(Convert.ToString(parameters.node32));
            nodeList.Add(Convert.ToString(parameters.node33));
            nodeList.Add(Convert.ToString(parameters.node34));
            nodeList.Add(Convert.ToString(parameters.node35));
            nodeList.Add(Convert.ToString(parameters.node36));
            nodeList.Add(Convert.ToString(parameters.node37));
            nodeList.Add(Convert.ToString(parameters.node38));
            nodeList.Add(Convert.ToString(parameters.node39));
            nodeList.Add(Convert.ToString(parameters.node40));
            nodeList.Add(Convert.ToString(parameters.node41));
            nodeList.Add(Convert.ToString(parameters.node42));
            nodeList.Add(Convert.ToString(parameters.node43));
            nodeList.Add(Convert.ToString(parameters.node44));
            nodeList.Add(Convert.ToString(parameters.node45));
            nodeList.Add(Convert.ToString(parameters.node46));
            nodeList.Add(Convert.ToString(parameters.node47));
            nodeList.Add(Convert.ToString(parameters.node48));
            nodeList.Add(Convert.ToString(parameters.node49));
            nodeList.Add(Convert.ToString(parameters.node50));
            nodeList.Add(Convert.ToString(parameters.node51));
            nodeList.Add(Convert.ToString(parameters.node52));
            nodeList.Add(Convert.ToString(parameters.node53));
            nodeList.Add(Convert.ToString(parameters.node54));
            nodeList.Add(Convert.ToString(parameters.node55));
            nodeList.Add(Convert.ToString(parameters.node56));
            nodeList.Add(Convert.ToString(parameters.node57));
            nodeList.Add(Convert.ToString(parameters.node58));
            nodeList.Add(Convert.ToString(parameters.node59));
            nodeList.Add(Convert.ToString(parameters.node60));
            nodeList.Add(Convert.ToString(parameters.node61));
            nodeList.Add(Convert.ToString(parameters.node62));
            nodeList.Add(Convert.ToString(parameters.node63));
            nodeList.Add(Convert.ToString(parameters.node64));
            nodeList.Add(Convert.ToString(parameters.node65));
            nodeList.Add(Convert.ToString(parameters.node66));
            nodeList.Add(Convert.ToString(parameters.node67));
            nodeList.Add(Convert.ToString(parameters.node68));
            nodeList.Add(Convert.ToString(parameters.node69));
            nodeList.Add(Convert.ToString(parameters.node70));
            nodeList.Add(Convert.ToString(parameters.node71));
            nodeList.Add(Convert.ToString(parameters.node72));
            nodeList.Add(Convert.ToString(parameters.node73));
            nodeList.Add(Convert.ToString(parameters.node74));
            nodeList.Add(Convert.ToString(parameters.node75));
            nodeList.Add(Convert.ToString(parameters.node76));
            nodeList.Add(Convert.ToString(parameters.node77));
            nodeList.Add(Convert.ToString(parameters.node78));
            nodeList.Add(Convert.ToString(parameters.node79));
            nodeList.Add(Convert.ToString(parameters.node80));
            nodeList.Add(Convert.ToString(parameters.node81));
            nodeList.Add(Convert.ToString(parameters.node82));
            nodeList.Add(Convert.ToString(parameters.node83));
            nodeList.Add(Convert.ToString(parameters.node84));
            nodeList.Add(Convert.ToString(parameters.node85));
            nodeList.Add(Convert.ToString(parameters.node86));
            nodeList.Add(Convert.ToString(parameters.node87));
            nodeList.Add(Convert.ToString(parameters.node88));
            nodeList.Add(Convert.ToString(parameters.node89));
            nodeList.Add(Convert.ToString(parameters.node90));
            nodeList.Add(Convert.ToString(parameters.node91));
            nodeList.Add(Convert.ToString(parameters.node92));
            nodeList.Add(Convert.ToString(parameters.node93));
            nodeList.Add(Convert.ToString(parameters.node94));
            nodeList.Add(Convert.ToString(parameters.node95));
            nodeList.Add(Convert.ToString(parameters.node96));
            nodeList.Add(Convert.ToString(parameters.node97));
            nodeList.Add(Convert.ToString(parameters.node98));
            nodeList.Add(Convert.ToString(parameters.node99));
            nodeList.Add(Convert.ToString(parameters.node100));
            nodeList.Add(Convert.ToString(parameters.node101));
            nodeList.Add(Convert.ToString(parameters.node102));
            nodeList.Add(Convert.ToString(parameters.node103));
            nodeList.Add(Convert.ToString(parameters.node104));
            nodeList.Add(Convert.ToString(parameters.node105));
            nodeList.Add(Convert.ToString(parameters.node106));
            nodeList.Add(Convert.ToString(parameters.node107));
            nodeList.Add(Convert.ToString(parameters.node108));
            nodeList.Add(Convert.ToString(parameters.node109));
            nodeList.Add(Convert.ToString(parameters.node110));
            nodeList.Add(Convert.ToString(parameters.node111));
            nodeList.Add(Convert.ToString(parameters.node112));
            nodeList.Add(Convert.ToString(parameters.node113));
            nodeList.Add(Convert.ToString(parameters.node114));
            nodeList.Add(Convert.ToString(parameters.node115));*/


            string PGPPublicKey = Convert.ToString(parameters.PGPPublicKey);
            string PGPPrivateKey = Convert.ToString(parameters.PGPPrivateKey);
            Int32 read_timeout = Convert.ToInt32(parameters.read_timeout);
            Int32 conn_timeout = Convert.ToInt32(parameters.conn_timeout);
            Int16 extract_date_minus_days = Convert.ToInt16(parameters.extract_date_minus_days);
            string lakeFolder = Convert.ToString(parameters.adlsDestinationFolder);

            string extactdate = DateTime.Today.AddDays(extract_date_minus_days).ToString("yyyy-MM-dd");

            string applicationid = Convert.ToString(parameters.applicationid);
            var pfxthumbprint = Convert.ToString(parameters.pfxthumbprint);

            KeyVaultHelper client = new KeyVaultHelper(key_vault, applicationid, pfxthumbprint);

            var Request_Message_user_secret_value = client.RetrieveSecretAsync(Request_Message_user_secret).Result;

            //var Request_Message_user_secret_value = "Workday@123";

            string PGPPublicKey_string = client.RetrieveSecretAsync(PGPPublicKey).Result;

            //secret = client.GetSecretAsync(key_vault, PGPPrivateKey).Result;
            //string PGPPrivateKey_string = secret.Value;
            string PGPPrivateKey_string = client.RetrieveSecretAsync(PGPPrivateKey).Result;


            var csv = new StringBuilder();

            var newLine = string.Format
                 (

                  "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|{36}|{37}|{38}|{39}|{40}|{41}|{42}|{43}|{44}|{45}|{46}|{47}|{48}|{49}|{50}|{51}|{52}|{53}|{54}|{55}|{56}|{57}|{58}|{59}|{60}|{61}|{62}|{63}|{64}|{65}|{66}|{67}|{68}|{69}|{70}|{71}|{72}|{73}|{74}|{75}",
                  "EMPLOYEE_ID", "WORK_LOCATION_CODE_DESC", "WORK_LOCATION_WID",//3
"WORK_LOCATION_CODE", "WU_ID_DESC", "WU_ID_WID", "WU_ID_ORGANIZATION_REFERENCE_ID", "WU_ID_CUSTOM_ORGANIZATION_REFERENCE_ID",//5
"BLUE_COLLAR", "COST_CENTER_DESC", "COST_CENTER_WID", "COST_CENTER_ORGANIZATION_REFERENCE_ID", "COST_CENTER_CUSTOM_ORGANIZATION_REFERENCE_ID",//5
"BASE_SALARY", "SALARY_EFF_DATE", "SALARY_CURRENCY_DESC", "SALARY_CURRENCY_WID", "CURRENCY_ID", "CURRENCY_NUMERIC_CODE", "SALARY_BASIS_DESC", "SALARY_BASIS_WID",//8
"FREQUENCY_ID", "PAYGROUP_DESC", "PAYGROUP_WID", "PAYGROUP_ORGANIZATION_REFERENCE_ID", "WORK_LEVEL_DESC",//5
"WORK_LEVEL_WID", "JOB_LEVEL_ID", "JOINING_DATE", "STANDARD_JOB_CODE_DESC", "STANDARD_JOB_CODE_WID",//5
"JOB_PROFILE_ID", "EMPLOYEE_TYPE_DESC", "EMPLOYEE_TYPE_WID", "EMPLOYEE_TYPE_ID", "EMPLOYEE_STATUS",//5
"ISO_COUNTRY_CODE", "COMPENSATION_GRADE_FLAG", "NATIONALITY_FLAG", "ADDRESS_LINE_3_FLAG", "PRIMARY_EMAIL_FLAG", "EARNING_DEDUCTION_FLAG", "NATIONAL_ID_FLAG",//7
"TERMINATION_DATE", "PCI_DATE", "PCO_DATE", "TRANSFERRED_FROM", "TRANSFERRED_TO", "COST_CENTER_EFF_DATE", "PAYGROUP_EFF_DATE", "MARITAL_STATUS", "CITIZENSHIP", "PROFESSIONAL_CATEGORY",//7
"COMPANY_CODE", "CONTRACT_TYPE", "COMPENSATION_GRADE", "FTE_PERCENT", "COLLECTIVE_AGREEMENT", "CONTINUOUS_SERVICE_DATE", "SOCIAL_SECURITY_ID", "NO_OF_DEPENDENTS", "DEPENDENT_WT_SS_ID", "LOGICAL_LOCATION", "LOGICAL_LOCATION_REFERENCE_ID",//8
"UNPAID_LEAVE_STATUS", "UNPAID_LEAVE_FLAG", "END_EMPLOYMENT_DATE", "CONTRACT_TYPE_INFORMATION", "HR_LEGACY_EMPLOYEE_ID", "SHIFT_ALLOWANCE", "GRAND_FATHERED_EMPLOYEE", "PERSONAL_ALLOWANCE", "PRIMARY_HOME_ADDRESS", "ALL_HOME_ADDRESSES_FULL_WITH_COUNTRY", "ETHNICITY_FLAG", "PAYROLL_ID_FLAG"//12
                 );
            csv.AppendLine(newLine);

            foreach (string node in nodeList)
            {


                XmlDocument SOAPReqBody = new XmlDocument();

                HttpWebRequest request = CreateSOAPWebRequest(HawkEye_Payroll_EndPoint, read_timeout, conn_timeout);

                //string xmlSoapRequestFile  = Path.Combine(Directory.GetCurrentDirectory(), "Request_Message.xml");
                string xmlSoapRequestFile = Path.Combine(Directory.GetCurrentDirectory(), Request_Message);
                string varXML = System.IO.File.ReadAllText(xmlSoapRequestFile);

                varXML = varXML.Replace("{0}", Request_Message_user);
                varXML = varXML.Replace("{1}", Request_Message_user_secret_value);
                varXML = varXML.Replace("{2}", node);


                SOAPReqBody.LoadXml(varXML);
                using (Stream stream = request.GetRequestStream())
                {
                    SOAPReqBody.Save(stream);
                }
                //Geting response from request  

                try
                {

                    //using (WebResponse Serviceres = request.GetResponse())
                    using (WebResponse Serviceres = request.GetResponse())


                    {
                        using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                        {

                            var ServiceResult = rd.ReadToEnd();

                            var doc = XElement.Parse(ServiceResult);
                            var new_doc = RemoveAllNamespaces(doc).ToString();


                            //File.WriteAllText("hawkeyenode.xml", new_doc.ToString());

                            XmlDocument xdoc = new XmlDocument();
                            XmlDocument xdocLeaves = new XmlDocument();

                            xdoc.LoadXml(new_doc);

                            XmlNodeList entry_nodes = xdoc.SelectNodes("/Envelope/Body/Report_Data/Report_Entry");
                            XmlNodeList dependent_nodes;


                            foreach (XmlNode entry_node in entry_nodes)
                            {

                                string EMPLOYEE_ID = entry_node["EMPLOYEE_ID"].InnerText;
                                string WORK_LOCATION_CODE = "";
                                if (entry_node["WORK_LOCATION_CODE"] != null)
                                {
                                    WORK_LOCATION_CODE = entry_node["WORK_LOCATION_CODE"].InnerText;
                                };
                                string WORK_LOCATION_CODE_DESC = "";
                                if (entry_node["WORK_LOCATION_CODE_DESC"] != null)
                                {
                                    WORK_LOCATION_CODE_DESC = entry_node["WORK_LOCATION_CODE_DESC"].InnerText;
                                };
                                string WORK_LOCATION_WID = "";
                                if (entry_node["WORK_LOCATION_WID"] != null)
                                {
                                    WORK_LOCATION_WID = entry_node["WORK_LOCATION_WID"].InnerText;
                                };

                                string BLUE_COLLAR = "";
                                if (entry_node["BLUE_COLLAR"] != null)
                                {
                                    BLUE_COLLAR = entry_node["BLUE_COLLAR"].InnerText;
                                };

                                string BASE_SALARY = "";
                                if (entry_node["BASE_SALARY"] != null)
                                {
                                    BASE_SALARY = entry_node["BASE_SALARY"].InnerText;
                                };
                                string SALARY_EFF_DATE = "";
                                if (entry_node["SALARY_EFF_DATE"] != null)
                                {
                                    SALARY_EFF_DATE = entry_node["SALARY_EFF_DATE"].InnerText;
                                };
                                string JOINING_DATE = "";
                                if (entry_node["JOINING_DATE"] != null)
                                {
                                    JOINING_DATE = entry_node["JOINING_DATE"].InnerText;
                                };

                                string EMPLOYEE_STATUS = "";
                                if (entry_node["EMPLOYEE_STATUS"] != null)
                                {
                                    EMPLOYEE_STATUS = entry_node["EMPLOYEE_STATUS"].InnerText;
                                };

                                string ISO_COUNTRY_CODE = "";
                                if (entry_node["ISO_COUNTRY_CODE"] != null)
                                {
                                    ISO_COUNTRY_CODE = entry_node["ISO_COUNTRY_CODE"].InnerText;
                                };

                                string COMPENSATION_GRADE_FLAG = "";
                                if (entry_node["COMPENSATION_GRADE_FLAG"] != null)
                                {
                                    COMPENSATION_GRADE_FLAG = entry_node["COMPENSATION_GRADE_FLAG"].InnerText;
                                };
                                string NATIONALITY_FLAG = "";
                                if (entry_node["NATIONALITY_FLAG"] != null)
                                {
                                    NATIONALITY_FLAG = entry_node["NATIONALITY_FLAG"].InnerText;
                                };
                                string ADDRESS_LINE_3_FLAG = "";
                                if (entry_node["ADDRESS_LINE_3_FLAG"] != null)
                                {
                                    ADDRESS_LINE_3_FLAG = entry_node["ADDRESS_LINE_3_FLAG"].InnerText;
                                };
                                string PRIMARY_EMAIL_FLAG = "";
                                if (entry_node["PRIMARY_EMAIL_FLAG"] != null)
                                {
                                    PRIMARY_EMAIL_FLAG = entry_node["PRIMARY_EMAIL_FLAG"].InnerText;
                                };
                                string EARNING_DEDUCTION_FLAG = "";
                                if (entry_node["EARNING_DEDUCTION_FLAG"] != null)
                                {
                                    EARNING_DEDUCTION_FLAG = entry_node["EARNING_DEDUCTION_FLAG"].InnerText;
                                };

                                string NATIONAL_ID_FLAG = "";
                                if (entry_node["NATIONAL_ID_FLAG"] != null)
                                {
                                    NATIONAL_ID_FLAG = entry_node["NATIONAL_ID_FLAG"].InnerText;
                                };

                                string TERMINATION_DATE = "";
                                if (entry_node["TERMINATION_DATE"] != null)
                                {
                                    TERMINATION_DATE = entry_node["TERMINATION_DATE"].InnerText;
                                };
                                string PCI_DATE = "";
                                if (entry_node["PCI_DATE"] != null)
                                {
                                    PCI_DATE = entry_node["PCI_DATE"].InnerText;
                                };
                                string PCO_DATE = "";
                                if (entry_node["PCO_DATE"] != null)
                                {
                                    PCO_DATE = entry_node["PCO_DATE"].InnerText;
                                };
                                string TRANSFERRED_FROM = "";
                                if (entry_node["TRANSFERRED_FROM"] != null)
                                {
                                    TRANSFERRED_FROM = entry_node["TRANSFERRED_FROM"].InnerText;
                                };
                                string TRANSFERRED_TO = "";
                                if (entry_node["TRANSFERRED_TO"] != null)
                                {
                                    TRANSFERRED_TO = entry_node["TRANSFERRED_TO"].InnerText;
                                };
                                string COST_CENTER_EFF_DATE = "";
                                if (entry_node["COST_CENTER_EFF_DATE"] != null)
                                {
                                    COST_CENTER_EFF_DATE = entry_node["COST_CENTER_EFF_DATE"].InnerText;
                                };
                                string PAYGROUP_EFF_DATE = "";
                                if (entry_node["PAYGROUP_EFF_DATE "] != null)
                                {
                                    PAYGROUP_EFF_DATE = entry_node["PAYGROUP_EFF_DATE "].InnerText;
                                };

                                string WU_ID_DESC = "";
                                if (entry_node["WU_ID"] != null)
                                {
                                    WU_ID_DESC = entry_node["WU_ID"].Attributes[0].Value;
                                };

                                string WU_ID_WID = "";
                                if (entry_node["WU_ID"] != null)
                                {
                                    WU_ID_WID = entry_node["WU_ID"].ChildNodes[0].InnerText;
                                };
                                string WU_ID_ORGANIZATION_REFERENCE_ID = "";
                                if (entry_node["WU_ID"] != null)
                                {
                                    WU_ID_ORGANIZATION_REFERENCE_ID = entry_node["WU_ID"].ChildNodes[1].InnerText;
                                };
                                string WU_ID_CUSTOM_ORGANIZATION_REFERENCE_ID = "";
                                if (entry_node["WU_ID"] != null)
                                {
                                    WU_ID_CUSTOM_ORGANIZATION_REFERENCE_ID = entry_node["WU_ID"].ChildNodes[2].InnerText;
                                };
                                string COST_CENTER_DESC = "";
                                if (entry_node["COST_CENTER"] != null)
                                {
                                    COST_CENTER_DESC = entry_node["COST_CENTER"].Attributes[0].Value;
                                };
                                string COST_CENTER_WID = "";
                                if (entry_node["COST_CENTER"] != null)
                                {
                                    COST_CENTER_WID = entry_node["COST_CENTER"].ChildNodes[0].InnerText;
                                };
                                string COST_CENTER_ORGANIZATION_REFERENCE_ID = "";
                                if (entry_node["COST_CENTER"] != null)
                                {
                                    COST_CENTER_ORGANIZATION_REFERENCE_ID = entry_node["COST_CENTER"].ChildNodes[1].InnerText;
                                };
                                string COST_CENTER_CUSTOM_ORGANIZATION_REFERENCE_ID = "";
                                if (entry_node["COST_CENTER"] != null)
                                {
                                    COST_CENTER_CUSTOM_ORGANIZATION_REFERENCE_ID = entry_node["COST_CENTER"].ChildNodes[2].InnerText;
                                };

                                string SALARY_CURRENCY_DESC = "";
                                if (entry_node["SALARY_CURRENCY"] != null)
                                {
                                    SALARY_CURRENCY_DESC = entry_node["SALARY_CURRENCY"].Attributes[0].Value;
                                };
                                string SALARY_CURRENCY_WID = "";
                                if (entry_node["SALARY_CURRENCY"] != null)
                                {
                                    SALARY_CURRENCY_WID = entry_node["SALARY_CURRENCY"].ChildNodes[0].InnerText;
                                };
                                string CURRENCY_ID = "";
                                if (entry_node["SALARY_CURRENCY"] != null)
                                {
                                    CURRENCY_ID = entry_node["SALARY_CURRENCY"].ChildNodes[1].InnerText;
                                };
                                string CURRENCY_NUMERIC_CODE = "";
                                if (entry_node["SALARY_CURRENCY"] != null)
                                {
                                    CURRENCY_NUMERIC_CODE = entry_node["SALARY_CURRENCY"].ChildNodes[2].InnerText;
                                };

                                string SALARY_BASIS_DESC = "";
                                if (entry_node["SALARY_BASIS"] != null)
                                {
                                    SALARY_BASIS_DESC = entry_node["SALARY_BASIS"].Attributes[0].Value;
                                };
                                string SALARY_BASIS_WID = "";
                                if (entry_node["SALARY_BASIS"] != null)
                                {
                                    SALARY_BASIS_WID = entry_node["SALARY_BASIS"].ChildNodes[0].InnerText;
                                };
                                string FREQUENCY_ID = "";
                                if (entry_node["SALARY_BASIS"] != null)
                                {
                                    FREQUENCY_ID = entry_node["SALARY_BASIS"].ChildNodes[1].InnerText;
                                };
                                string PAYGROUP_DESC = "";
                                if (entry_node["PAYGROUP"] != null)
                                {
                                    PAYGROUP_DESC = entry_node["PAYGROUP"].Attributes[0].Value;
                                };
                                string PAYGROUP_WID = "";
                                if (entry_node["PAYGROUP"] != null)
                                {
                                    PAYGROUP_WID = entry_node["PAYGROUP"].ChildNodes[0].InnerText;
                                };
                                string PAYGROUP_ORGANIZATION_REFERENCE_ID = "";
                                if (entry_node["PAYGROUP"] != null)
                                {
                                    PAYGROUP_ORGANIZATION_REFERENCE_ID = entry_node["PAYGROUP"].ChildNodes[1].InnerText;
                                };
                                string WORK_LEVEL_DESC = "";
                                if (entry_node["WORK_LEVEL"] != null)
                                {
                                    WORK_LEVEL_DESC = entry_node["WORK_LEVEL"].Attributes[0].Value;
                                };

                                string WORK_LEVEL_WID = "";
                                if (entry_node["WORK_LEVEL"] != null)
                                {
                                    WORK_LEVEL_WID = entry_node["WORK_LEVEL"].ChildNodes[0].InnerText;
                                };
                                string JOB_LEVEL_ID = "";
                                if (entry_node["WORK_LEVEL"] != null)
                                {
                                    JOB_LEVEL_ID = entry_node["WORK_LEVEL"].ChildNodes[1].InnerText;
                                };
                                string STANDARD_JOB_CODE_DESC = "";
                                if (entry_node["STANDARD_JOB_CODE"] != null)
                                {
                                    STANDARD_JOB_CODE_DESC = entry_node["STANDARD_JOB_CODE"].Attributes[0].Value;
                                };
                                string STANDARD_JOB_CODE_WID = "";
                                if (entry_node["STANDARD_JOB_CODE"] != null)
                                {
                                    STANDARD_JOB_CODE_WID = entry_node["STANDARD_JOB_CODE"].ChildNodes[0].InnerText;
                                };
                                string JOB_PROFILE_ID = "";
                                if (entry_node["STANDARD_JOB_CODE"] != null)
                                {
                                    JOB_PROFILE_ID = entry_node["STANDARD_JOB_CODE"].ChildNodes[1].InnerText;
                                };
                                string EMPLOYEE_TYPE_DESC = "";
                                if (entry_node["EMPLOYEE_TYPE"] != null)
                                {
                                    EMPLOYEE_TYPE_DESC = entry_node["EMPLOYEE_TYPE"].Attributes[0].Value;
                                };

                                string EMPLOYEE_TYPE_WID = "";
                                if (entry_node["EMPLOYEE_TYPE"] != null)
                                {
                                    EMPLOYEE_TYPE_WID = entry_node["EMPLOYEE_TYPE"].ChildNodes[0].InnerText;
                                };
                                string EMPLOYEE_TYPE_ID = "";
                                if (entry_node["EMPLOYEE_TYPE"] != null)
                                {
                                    EMPLOYEE_TYPE_ID = entry_node["EMPLOYEE_TYPE"].ChildNodes[1].InnerText;
                                };
                                string MARITAL_STATUS = "";
                                if (entry_node["Marital_Status"] != null)
                                {
                                    MARITAL_STATUS = entry_node["Marital_Status"].InnerText;
                                };
                                string CITIZENSHIP = "";
                                if (entry_node["Citizenship"] != null)
                                {
                                    CITIZENSHIP = entry_node["Citizenship"].InnerText;
                                };
                                string PROFESSIONAL_CATEGORY = "";
                                if (entry_node["Professional_Category"] != null)
                                {
                                    PROFESSIONAL_CATEGORY = entry_node["Professional_Category"].InnerText;
                                };
                                string COMPANY_CODE = "";
                                if (entry_node["Company_Code"] != null)
                                {
                                    COMPANY_CODE = entry_node["Company_Code"].InnerText;
                                };
                                string CONTRACT_TYPE = "";
                                if (entry_node["Contract_Type"] != null)
                                {
                                    CONTRACT_TYPE = entry_node["Contract_Type"].InnerText;
                                };
                                string COMPENSATION_GRADE = "";
                                if (entry_node["Compensation_Grade"] != null)
                                {
                                    COMPENSATION_GRADE = entry_node["Compensation_Grade"].InnerText;
                                };
                                string FTE_PERCENT = "";
                                if (entry_node["FTE_Percent"] != null)
                                {
                                    FTE_PERCENT = entry_node["FTE_Percent"].InnerText;
                                };
                                string COLLECTIVE_AGREEMENT = "";
                                if (entry_node["Collective_Agreement"] != null)
                                {
                                    COLLECTIVE_AGREEMENT = entry_node["Collective_Agreement"].InnerText;
                                };
                                string CONTINUOUS_SERVICE_DATE = "";
                                if (entry_node["Continuous_Service_Date"] != null)
                                {
                                    CONTINUOUS_SERVICE_DATE = entry_node["Continuous_Service_Date"].InnerText;
                                };
                                string SOCIAL_SECURITY_ID = "";
                                if (entry_node["Social_Security_ID"] != null)
                                {
                                    SOCIAL_SECURITY_ID = entry_node["Social_Security_ID"].InnerText;
                                };

                                dependent_nodes = entry_node.SelectNodes("Dependents_group");
                                int NO_OF_DEPENDENTS = 0;
                                NO_OF_DEPENDENTS = dependent_nodes.Count;

                                int DEPENDENT_WT_SS_ID = 0;
                                for (int i = 0; i < dependent_nodes.Count; i++)
                                {

                                    if (dependent_nodes[i]["Dependents_Social_Security_ID"].InnerText == "N")
                                    {
                                        DEPENDENT_WT_SS_ID += 1;
                                    };

                                };

                                string LOGICAL_LOCATION = "";
                                if (entry_node["Logical_Location"] != null)
                                {
                                    LOGICAL_LOCATION = entry_node["Logical_Location"].InnerText;
                                };

                                string LOGICAL_LOCATION_REFERENCE_ID = "";
                                if (entry_node["Logical_Location_Reference_ID"] != null)
                                {
                                    LOGICAL_LOCATION_REFERENCE_ID = entry_node["Logical_Location_Reference_ID"].InnerText;
                                };

                                // Hawekeye Wave2A additional Columns code
                                string UNPAID_LEAVE_STATUS = "";
                                if (entry_node["Unpaid_Leave_Status"] != null)
                                {
                                    UNPAID_LEAVE_STATUS = entry_node["Unpaid_Leave_Status"].InnerText;
                                };

                                string UNPAID_LEAVE_FLAG = "";
                                if (entry_node["Unpaid_Leave_Flag"] != null)
                                {
                                    UNPAID_LEAVE_FLAG = entry_node["Unpaid_Leave_Flag"].InnerText;
                                };

                                string END_EMPLOYMENT_DATE = "";
                                if (entry_node["End_Employment_Date"] != null)
                                {
                                    END_EMPLOYMENT_DATE = entry_node["End_Employment_Date"].InnerText;
                                };

                                string CONTRACT_TYPE_INFORMATION = "";
                                if (entry_node["CF_LRV_Worker_Contract_Type_Text1"] != null)
                                {
                                    CONTRACT_TYPE_INFORMATION = entry_node["CF_LRV_Worker_Contract_Type_Text1"].InnerText;
                                };

                                string HR_LEGACY_EMPLOYEE_ID = "";
                                if (entry_node["CF_INT111_ESI_HR_Legacy_ID"] != null)
                                {
                                    HR_LEGACY_EMPLOYEE_ID = entry_node["CF_INT111_ESI_HR_Legacy_ID"].Attributes[0].Value;
                                };

                                string SHIFT_ALLOWANCE = "";
                                if (entry_node["CF_INT088_Shift_Annual_Allowance_LRV"] != null)
                                {
                                    SHIFT_ALLOWANCE = entry_node["CF_INT088_Shift_Annual_Allowance_LRV"].InnerText;
                                };

                                string GRAND_FATHERED_EMPLOYEE = "";
                                if (entry_node["grandfatheredEmployee"] != null)
                                {
                                    GRAND_FATHERED_EMPLOYEE = entry_node["grandfatheredEmployee"].InnerText;
                                };

                                string PERSONAL_ALLOWANCE = "";
                                if (entry_node["CF_Personal_Allowance_LRV"] != null)
                                {
                                    PERSONAL_ALLOWANCE = entry_node["CF_Personal_Allowance_LRV"].InnerText;
                                };

                                string PRIMARY_HOME_ADDRESS = "";
                                if (entry_node["CF_CT_Worker_Primary_Home_Address"] != null)
                                {
                                    PRIMARY_HOME_ADDRESS = entry_node["CF_CT_Worker_Primary_Home_Address"].InnerText;
                                };

                                string ALL_HOME_ADDRESSES_FULL_WITH_COUNTRY = "";
                                if (entry_node["All_Home_Addresses_-_Full_with_Country"] != null)
                                {
                                    ALL_HOME_ADDRESSES_FULL_WITH_COUNTRY = entry_node["All_Home_Addresses_-_Full_with_Country"].InnerText;
                                };

                                string ETHNICITY_FLAG = "";
                                if (entry_node["CF_INT200D_Ethnicity_Flag_EE"] != null)
                                {
                                    ETHNICITY_FLAG = entry_node["CF_INT200D_Ethnicity_Flag_EE"].InnerText;
                                };

                                string PAYROLL_ID_FLAG = "";
                                if (entry_node["CF_INT200D_Payroll_ID_Flag"] != null)
                                {
                                    PAYROLL_ID_FLAG = entry_node["CF_INT200D_Payroll_ID_Flag"].InnerText;
                                };

                                newLine = string.Format(

                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|{36}|{37}|{38}|{39}|{40}|{41}|{42}|{43}|{44}|{45}|{46}|{47}|{48}|{49}|{50}|{51}|{52}|{53}|{54}|{55}|{56}|{57}|{58}|{59}|{60}|{61}|{62}|{63}|{64}|{65}|{66}|{67}|{68}|{69}|{70}|{71}|{72}|{73}|{74}|{75}",
                                EMPLOYEE_ID, WORK_LOCATION_CODE_DESC, WORK_LOCATION_WID,  //3
                                WORK_LOCATION_CODE, WU_ID_DESC, WU_ID_WID, WU_ID_ORGANIZATION_REFERENCE_ID, WU_ID_CUSTOM_ORGANIZATION_REFERENCE_ID,  //5
                                BLUE_COLLAR, COST_CENTER_DESC, COST_CENTER_WID, COST_CENTER_ORGANIZATION_REFERENCE_ID, COST_CENTER_CUSTOM_ORGANIZATION_REFERENCE_ID, //5
                                BASE_SALARY, SALARY_EFF_DATE, SALARY_CURRENCY_DESC, SALARY_CURRENCY_WID, CURRENCY_ID, CURRENCY_NUMERIC_CODE, SALARY_BASIS_DESC, SALARY_BASIS_WID,  //8
                                FREQUENCY_ID, PAYGROUP_DESC, PAYGROUP_WID, PAYGROUP_ORGANIZATION_REFERENCE_ID, WORK_LEVEL_DESC, //5
                                WORK_LEVEL_WID, JOB_LEVEL_ID, JOINING_DATE, STANDARD_JOB_CODE_DESC, STANDARD_JOB_CODE_WID, //5
                                JOB_PROFILE_ID, EMPLOYEE_TYPE_DESC, //2
                                EMPLOYEE_TYPE_WID, EMPLOYEE_TYPE_ID, EMPLOYEE_STATUS, //3
                                ISO_COUNTRY_CODE, COMPENSATION_GRADE_FLAG, NATIONALITY_FLAG, //3
                                ADDRESS_LINE_3_FLAG, PRIMARY_EMAIL_FLAG, EARNING_DEDUCTION_FLAG, NATIONAL_ID_FLAG, //4
                                TERMINATION_DATE, PCI_DATE, PCO_DATE, TRANSFERRED_FROM, TRANSFERRED_TO, COST_CENTER_EFF_DATE, PAYGROUP_EFF_DATE, MARITAL_STATUS, CITIZENSHIP, PROFESSIONAL_CATEGORY,//7
                                COMPANY_CODE, CONTRACT_TYPE, COMPENSATION_GRADE, FTE_PERCENT, COLLECTIVE_AGREEMENT, CONTINUOUS_SERVICE_DATE, SOCIAL_SECURITY_ID, NO_OF_DEPENDENTS, DEPENDENT_WT_SS_ID, LOGICAL_LOCATION, LOGICAL_LOCATION_REFERENCE_ID, //8
                                UNPAID_LEAVE_STATUS, UNPAID_LEAVE_FLAG, END_EMPLOYMENT_DATE, CONTRACT_TYPE_INFORMATION, HR_LEGACY_EMPLOYEE_ID, SHIFT_ALLOWANCE, GRAND_FATHERED_EMPLOYEE, PERSONAL_ALLOWANCE, PRIMARY_HOME_ADDRESS, ALL_HOME_ADDRESSES_FULL_WITH_COUNTRY, ETHNICITY_FLAG, PAYROLL_ID_FLAG//12
                                );
                                csv.AppendLine(newLine);

                            }

                        }

                    } //using Web Response

                } // Try
                catch (Exception ex)
                {
                    Console.Write("No Data for " + node);
                }
            }

            string localFolderPath = Directory.GetCurrentDirectory();
            string workerFileName = OutPutFileName + ".csv";
            string workerFileNamePGP = OutPutFileName + ".csv.pgp";

            string WorkerFileCSVpath = Path.Combine(localFolderPath, workerFileName);
            string WorkerFileCSVpathPGP = Path.Combine(localFolderPath, workerFileNamePGP);

            File.WriteAllText(WorkerFileCSVpath, csv.ToString().Trim());


            // Encrypt the file

            FileInfo fi = new FileInfo(WorkerFileCSVpath);

            using (FileStream outputStream = fi.OpenRead())
            {

                FileStream str = new FileStream(WorkerFileCSVpathPGP, FileMode.Create);
                Stream ULPublicKeyStream = new MemoryStream(Encoding.UTF8.GetBytes(PGPPublicKey_string));
                Stream ULPrivateKeyStream = new MemoryStream(Encoding.UTF8.GetBytes(PGPPrivateKey_string));
                PgpEncryptionKeys encryptionKeys = new PgpEncryptionKeys(ULPublicKeyStream, ULPrivateKeyStream, "");
                PgpEncrypt objPgpEncrypt = new PgpEncrypt(encryptionKeys);
                objPgpEncrypt.EncryptAndSign(str, fi);
                str.Close();
            }

            webApp_clientId = Convert.ToString(parameters.applicationid);
            clientSecret = client.RetrieveSecretAsync(webApp_clientId).Result;



            var clientCredential = new ClientCredential(webApp_clientId, clientSecret);
            var creds = ApplicationTokenProvider.LoginSilentAsync(domain, clientCredential).Result;

            var adlsClient = new DataLakeStoreAccountManagementClient(creds) { SubscriptionId = "_subId" };

            var adlsFileSystemClient = new DataLakeStoreFileSystemManagementClient(creds);
            string destinationdataLakeStoreFolderPath1 = "/" + lakeFolder;
            string destinationdataLakeStoreFilePath1 = Path.Combine(destinationdataLakeStoreFolderPath1, Path.GetFileName(workerFileNamePGP));
            var FileExists = adlsFileSystemClient.FileSystem.PathExists(adlsName, destinationdataLakeStoreFilePath1);



            if (FileExists == true)
            {
                adlsFileSystemClient.FileSystem.Delete(adlsName, destinationdataLakeStoreFilePath1);
            }
            adlsFileSystemClient.FileSystem.UploadFile(adlsName, WorkerFileCSVpathPGP, destinationdataLakeStoreFilePath1);
            if (System.IO.File.Exists(WorkerFileCSVpath))
            {
                System.IO.File.Delete(WorkerFileCSVpath);

            }

            if (System.IO.File.Exists(WorkerFileCSVpathPGP))
            {
                System.IO.File.Delete(WorkerFileCSVpathPGP);

            }



            //    }
            //  }




        }

        public HttpWebRequest CreateSOAPWebRequest(string HawkEye_Payroll_EndPoint, Int32 read_timeout, Int32 conn_timeout)
        {

            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            //Making Web Request  
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(HawkEye_Payroll_EndPoint);

            //SOAPAction  
            Req.Headers.Add(@"SOAP:Action");
            //Content_type  
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method  
            Req.Method = "POST";

            Req.Timeout = conn_timeout;
            Req.ContinueTimeout = read_timeout;
            Req.ReadWriteTimeout = read_timeout;

            //return HttpWebRequest  
            return Req;
        }
        public static XElement RemoveAllNamespaces(XElement e)
        {
            return new XElement(e.Name.LocalName,
               (from n in e.Nodes()
                select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
               (e.HasAttributes) ? (from a in e.Attributes()
                                    where (!a.IsNamespaceDeclaration)
                                    select new XAttribute(a.Name.LocalName, a.Value)) : null);
        }



        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }



    }
}
