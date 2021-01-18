namespace ZabbixApi.Zabbix
{
    public class Response
    {
        public int Id { get; set; }
        public string JsonRpc { get; set; }
        public object Result { get; set; }
        public ZabbixError Error { get; set; }
    }
}