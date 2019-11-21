

using Newtonsoft.Json;

namespace ERPServer.DTO
{
    public class Result
    {
        public Result()
        {
            Message = "正常";
        }

        public Result(string jsonStr)
        {
            ToObject(jsonStr);
        }

        //0-正常，其他都不正常
        public int State
        { get; set; }

        public string Message
        { get; set; }

        public object Data
        { get; set; }

        private void ToObject(string jsonStr)
        {
            var tmp = JsonConvert.DeserializeObject<Result>(jsonStr);
            if (tmp != null)
            {
                this.State = tmp.State;
                this.Message = tmp.Message;
                this.Data = tmp.Data;
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}