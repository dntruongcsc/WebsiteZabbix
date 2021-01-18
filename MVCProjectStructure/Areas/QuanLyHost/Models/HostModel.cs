using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectStructure.Areas.QuanLyHost.Models
{
    public class HostModel
    {
        public class Input
        {
            public class DocDanhSach : CommonModel.Zabbix.Param
            {
                public Fitler fitler { set; get; }
                public class Fitler
                {
                    public string value { set; get; }
                    public string[] host { set; get; }
                }
            }



            public class Them
            {
                public string host { get; set; }
                public List<Interface> interfaces { get; set; }
                public List<Group> groups { get; set; }
                //public List<Tag> tags { get; set; }
                //public List<Template> templates { get; set; }
                //public List<Macro> macros { get; set; }
                public int inventory_mode { get; set; }
                //public Inventory inventory { get; set; }
            }


            public class Inventory
            {
                public string macaddress_a { get; set; }
                public string macaddress_b { get; set; }
            }

            public class Interface
            {
                public int type { get; set; }
                public int main { get; set; }
                public int useip { get; set; }
                public string ip { get; set; }
                public string dns { get; set; }
                public string port { get; set; }
            }

            public class Group
            {
                public string groupid { get; set; }
            }

            public class Tag
            {
                public string tag { get; set; }
                public string value { get; set; }
            }

            public class Template
            {
                public string templateid { get; set; }
            }

            public class Macro
            {
                public string macro { get; set; }
                public string value { get; set; }
                public string description { get; set; }
            }


        }
        public class Output
        {
            //public class ThongTin
            //{
            //    public string hostid { get; set; }
            //    public string host { get; set; }
            //}



        }





        public class ThongTin
        {
            public string hostid { get; set; }
            public string proxy_hostid { get; set; }
            public string host { get; set; }
            public int status { get; set; }
            public string disable_until { get; set; }
            public string error { get; set; }
            public string available { get; set; }
            public string errors_from { get; set; }
            public string lastaccess { get; set; }
            public string ipmi_authtype { get; set; }
            public string ipmi_privilege { get; set; }
            public string ipmi_username { get; set; }
            public string ipmi_password { get; set; }
            public string ipmi_disable_until { get; set; }
            public string ipmi_available { get; set; }
            public string snmp_disable_until { get; set; }
            public string snmp_available { get; set; }
            public string maintenanceid { get; set; }
            public string maintenance_status { get; set; }
            public string maintenance_type { get; set; }
            public string maintenance_from { get; set; }
            public string ipmi_errors_from { get; set; }
            public string snmp_errors_from { get; set; }
            public string ipmi_error { get; set; }
            public string snmp_error { get; set; }
            public string jmx_disable_until { get; set; }
            public string jmx_available { get; set; }
            public string jmx_errors_from { get; set; }
            public string jmx_error { get; set; }
            public string name { get; set; }
            public string flags { get; set; }
            public string templateid { get; set; }
            public string description { get; set; }
            public string tls_connect { get; set; }
            public string tls_accept { get; set; }
            public string tls_issuer { get; set; }
            public string tls_subject { get; set; }
            public string tls_psk_identity { get; set; }
            public string tls_psk { get; set; }
            public string proxy_address { get; set; }
            public string auto_compress { get; set; }
            public string inventory_mode { get; set; }
            public List<Group> groups { get; set; }
            public List<Item> items { get; set; }
            public List<Discovery> discoveries { get; set; }
            public List<Trigger> triggers { get; set; }
            public List<Graph> graphs { get; set; }
            public List<Application> applications { get; set; }
            public List<Interface> interfaces { get; set; }
        }

        public class Group
        {
            public string groupid { get; set; }
            public string name { get; set; }
            public string _internal { get; set; }
            public string flags { get; set; }
        }

        public class Item
        {
            public string itemid { get; set; }
            public string type { get; set; }
            public string snmp_community { get; set; }
            public string snmp_oid { get; set; }
            public string hostid { get; set; }
            public string name { get; set; }
            public string key_ { get; set; }
            public string delay { get; set; }
            public string history { get; set; }
            public string trends { get; set; }
            public string status { get; set; }
            public string value_type { get; set; }
            public string trapper_hosts { get; set; }
            public string units { get; set; }
            public string snmpv3_securityname { get; set; }
            public string snmpv3_securitylevel { get; set; }
            public string snmpv3_authpassphrase { get; set; }
            public string snmpv3_privpassphrase { get; set; }
            public string formula { get; set; }
            public string logtimefmt { get; set; }
            public string templateid { get; set; }
            public string valuemapid { get; set; }
            public string _params { get; set; }
            public string ipmi_sensor { get; set; }
            public string authtype { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string publickey { get; set; }
            public string privatekey { get; set; }
            public string flags { get; set; }
            public string interfaceid { get; set; }
            public string port { get; set; }
            public string description { get; set; }
            public string inventory_link { get; set; }
            public string lifetime { get; set; }
            public string snmpv3_authprotocol { get; set; }
            public string snmpv3_privprotocol { get; set; }
            public string snmpv3_contextname { get; set; }
            public string evaltype { get; set; }
            public string jmx_endpoint { get; set; }
            public string master_itemid { get; set; }
            public string timeout { get; set; }
            public string url { get; set; }
            public object[] query_fields { get; set; }
            public string posts { get; set; }
            public string status_codes { get; set; }
            public string follow_redirects { get; set; }
            public string post_type { get; set; }
            public string http_proxy { get; set; }
            public object[] headers { get; set; }
            public string retrieve_mode { get; set; }
            public string request_method { get; set; }
            public string output_format { get; set; }
            public string ssl_cert_file { get; set; }
            public string ssl_key_file { get; set; }
            public string ssl_key_password { get; set; }
            public string verify_peer { get; set; }
            public string verify_host { get; set; }
            public string allow_traps { get; set; }
            public string state { get; set; }
            public string error { get; set; }
            public string lastclock { get; set; }
            public string lastns { get; set; }
            public string lastvalue { get; set; }
            public string prevvalue { get; set; }
        }

        public class Discovery
        {
            public string itemid { get; set; }
            public string type { get; set; }
            public string snmp_community { get; set; }
            public string snmp_oid { get; set; }
            public string hostid { get; set; }
            public string name { get; set; }
            public string key_ { get; set; }
            public string delay { get; set; }
            public string history { get; set; }
            public string trends { get; set; }
            public string status { get; set; }
            public string value_type { get; set; }
            public string trapper_hosts { get; set; }
            public string units { get; set; }
            public string snmpv3_securityname { get; set; }
            public string snmpv3_securitylevel { get; set; }
            public string snmpv3_authpassphrase { get; set; }
            public string snmpv3_privpassphrase { get; set; }
            public string logtimefmt { get; set; }
            public string templateid { get; set; }
            public string valuemapid { get; set; }
            public string _params { get; set; }
            public string ipmi_sensor { get; set; }
            public string authtype { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string publickey { get; set; }
            public string privatekey { get; set; }
            public string flags { get; set; }
            public string interfaceid { get; set; }
            public string port { get; set; }
            public string description { get; set; }
            public string inventory_link { get; set; }
            public string lifetime { get; set; }
            public string snmpv3_authprotocol { get; set; }
            public string snmpv3_privprotocol { get; set; }
            public string snmpv3_contextname { get; set; }
            public string jmx_endpoint { get; set; }
            public string master_itemid { get; set; }
            public string timeout { get; set; }
            public string url { get; set; }
            public object[] query_fields { get; set; }
            public string posts { get; set; }
            public string status_codes { get; set; }
            public string follow_redirects { get; set; }
            public string post_type { get; set; }
            public string http_proxy { get; set; }
            public object[] headers { get; set; }
            public string retrieve_mode { get; set; }
            public string request_method { get; set; }
            public string ssl_cert_file { get; set; }
            public string ssl_key_file { get; set; }
            public string ssl_key_password { get; set; }
            public string verify_peer { get; set; }
            public string verify_host { get; set; }
            public string allow_traps { get; set; }
            public string state { get; set; }
            public string error { get; set; }
        }

        public class Trigger
        {
            public string triggerid { get; set; }
            public string expression { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string status { get; set; }
            public string value { get; set; }
            public string priority { get; set; }
            public string lastchange { get; set; }
            public string comments { get; set; }
            public string error { get; set; }
            public string templateid { get; set; }
            public string type { get; set; }
            public string state { get; set; }
            public string flags { get; set; }
            public string recovery_mode { get; set; }
            public string recovery_expression { get; set; }
            public string correlation_mode { get; set; }
            public string correlation_tag { get; set; }
            public string manual_close { get; set; }
            public string opdata { get; set; }
        }

        public class Graph
        {
            public string graphid { get; set; }
            public string name { get; set; }
            public string width { get; set; }
            public string height { get; set; }
            public string yaxismin { get; set; }
            public string yaxismax { get; set; }
            public string templateid { get; set; }
            public string show_work_period { get; set; }
            public string show_triggers { get; set; }
            public string graphtype { get; set; }
            public string show_legend { get; set; }
            public string show_3d { get; set; }
            public string percent_left { get; set; }
            public string percent_right { get; set; }
            public string ymin_type { get; set; }
            public string ymax_type { get; set; }
            public string ymin_itemid { get; set; }
            public string ymax_itemid { get; set; }
            public string flags { get; set; }
        }

        

        public class Template
        {
            public string proxy_hostid { get; set; }
            public string host { get; set; }
            public string status { get; set; }
            public string disable_until { get; set; }
            public string error { get; set; }
            public string available { get; set; }
            public string errors_from { get; set; }
            public string lastaccess { get; set; }
            public string ipmi_authtype { get; set; }
            public string ipmi_privilege { get; set; }
            public string ipmi_username { get; set; }
            public string ipmi_password { get; set; }
            public string ipmi_disable_until { get; set; }
            public string ipmi_available { get; set; }
            public string snmp_disable_until { get; set; }
            public string snmp_available { get; set; }
            public string maintenanceid { get; set; }
            public string maintenance_status { get; set; }
            public string maintenance_type { get; set; }
            public string maintenance_from { get; set; }
            public string ipmi_errors_from { get; set; }
            public string snmp_errors_from { get; set; }
            public string ipmi_error { get; set; }
            public string snmp_error { get; set; }
            public string jmx_disable_until { get; set; }
            public string jmx_available { get; set; }
            public string jmx_errors_from { get; set; }
            public string jmx_error { get; set; }
            public string name { get; set; }
            public string flags { get; set; }
            public string templateid { get; set; }
            public string description { get; set; }
            public string tls_connect { get; set; }
            public string tls_accept { get; set; }
            public string tls_issuer { get; set; }
            public string tls_subject { get; set; }
            public string tls_psk_identity { get; set; }
            public string tls_psk { get; set; }
        }

        public class Application
        {
            public string applicationid { get; set; }
            public string hostid { get; set; }
            public string name { get; set; }
            public string flags { get; set; }
            public string[] templateids { get; set; }
        }

        public class Interface
        {
            public string interfaceid { get; set; }
            public string hostid { get; set; }
            public string main { get; set; }
            public int type { get; set; }
            public string useip { get; set; }
            public string ip { get; set; }
            public string dns { get; set; }
            public string port { get; set; }
            public string bulk { get; set; }
        }




    }

}